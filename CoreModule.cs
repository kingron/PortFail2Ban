using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Configuration;
using System.Drawing.Text;
using System.Text.RegularExpressions;

/// <summary>
/// PortFail2Ban
/// 根据连接端口的频率次数自动封禁IP
/// 特别适合保护远程桌面3389，SSH 22等低密度连接数端口的保护
/// 不适合WWW等高密度连接端口的保护
/// </summary>
namespace PortFail2Ban
{
    class BanItem
    {
        public DateTime BanTime { get; set; }  // 封禁时刻
        public DateTime StartTime { get; set; } // 发现时刻
        public DateTime lastActive { get; set; } // 最后活跃时刻
        public string IP { get; set; }  // IP地址
        [DefaultValue(0)]
        public int status { get; set; }  // 状态: 0 = 发现， 1 = 封禁
        [DefaultValue(0)]
        public string lastPorts   // 最近连接的端口列表
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (int key in ports.Keys)
                {
                    sb.Append(key.ToString() + ",");
                }
                return sb.ToString();
            }
        }
        [DefaultValue(0)]
        public int count // 最近连接的次数
        {
            get
            {
                return ports.Count;
            }
        }

        public Dictionary<ushort, int> ports = new Dictionary<ushort, int>();
        public override string ToString()
        {
            return string.Format("{0}, First time: {2}, Ban time: {3}, Count: {4}, Ports: {1}", IP, lastPorts, StartTime, BanTime, count);
        }
    }

    class CoreModule
    {
        const string S_PORT = "port";
        const string S_GATE = "limit";
        const string S_DURATION = "duration";
        const string S_CLEAN = "clean";
        const string S_WHITE = "allow";

        const string LOG_TAG = "Application";
        const string RULE_NAME = "PortFail2Ban";

        private string[] mWhiteList;
        public int Gate { get; set; }  // 连续连接次数
        public int BanDuration { get; set; } // IP封锁分钟数
        public int CleanInterval { get; set; }  // 清理周期，单位分钟，正常的IP会在该周期后清理
        public Thread thread;
        public int Port { get; set; }           // 需要保护的端口
        public string WhiteList                 // 白名单
        {
            get
            {
                return string.Join(";", mWhiteList);
            }

            set
            {
                mWhiteList = value.Split(';');
                foreach (var x in BanItems)
                {
                    var v = x.Value;
                    v.status = IsWhiteIP(v.IP) ? 2 : (v.status == 1 ? 1 : 0);
                }
                updateRules();
            }
        }

        public Dictionary<string, BanItem> BanItems = new Dictionary<String, BanItem>();

        private void AddOrSaveConfig<T>(Configuration configuration, string Key, T Value)
        {
            if (configuration.AppSettings.Settings.AllKeys.Contains(Key))
                configuration.AppSettings.Settings[Key].Value = Value.ToString();
            else
                configuration.AppSettings.Settings.Add(Key, Value.ToString());
        }

        private void SaveConfig()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AddOrSaveConfig(configuration, S_PORT, Port);
            AddOrSaveConfig(configuration, S_GATE, Gate);
            AddOrSaveConfig(configuration, S_DURATION, BanDuration);
            AddOrSaveConfig(configuration, S_CLEAN, CleanInterval);
            AddOrSaveConfig(configuration, S_WHITE, WhiteList);
            configuration.Save();
        }

        private void LoadConfig()
        {
            this.Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings[S_PORT] ?? "3389");
            this.Gate = int.Parse(System.Configuration.ConfigurationManager.AppSettings[S_GATE] ?? "3");
            this.BanDuration = int.Parse(System.Configuration.ConfigurationManager.AppSettings[S_DURATION] ?? "1440");
            this.CleanInterval = int.Parse(System.Configuration.ConfigurationManager.AppSettings[S_CLEAN] ?? "30");
            this.WhiteList = System.Configuration.ConfigurationManager.AppSettings[S_WHITE] ?? "127.0.0.1;::1;192.168.*.*;172.16.*.*;";
        }

        public CoreModule()
        {
            LoadConfig();
        }

        ~CoreModule()
        {
            SaveConfig();
        }


        public void LogE(string message)
        {
            EventLog.WriteEntry(LOG_TAG, message, EventLogEntryType.Error, 888);
        }

        public void LogI(string message)
        {
            EventLog.WriteEntry(LOG_TAG, message, EventLogEntryType.Information, 888);
        }


        public void Start()
        {
            cmd(string.Format("netsh advfirewall firewall add rule name={0} dir=in localport={1} protocol=TCP action=block remoteip=8.8.8.8", RULE_NAME, Port));
            thread = new Thread(ThreadRun);
            thread.Start();
            LogI(RULE_NAME + " started.");
        }


        private void ThreadRun()
        {
            while (true)
                try
                {
                    Thread.Sleep(50);
                    bool needUpdateRule = false;
                    var ip = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
                    foreach (var tcp in ip.GetActiveTcpConnections())
                    {
                        if (tcp.LocalEndPoint.Port == Port)
                        {
                            BanItem item = null;
                            bool ok = BanItems.TryGetValue(tcp.RemoteEndPoint.Address.ToString(), out item);
                            if (!ok)
                            {
                                item = new BanItem();
                                item.IP = tcp.RemoteEndPoint.Address.ToString();
                                item.StartTime = DateTime.Now;
                                item.status = IsWhiteIP(item.IP) ? 2 : 0;
                            }
                            item.lastActive = DateTime.Now;
                            if (item.count >= Gate && !item.ports.ContainsKey((ushort)tcp.RemoteEndPoint.Port) && item.status == 0)
                                needUpdateRule = true;
                            item.ports[(ushort)tcp.RemoteEndPoint.Port] = 0;
                            BanItems[tcp.RemoteEndPoint.Address.ToString()] = item;
                        }
                    }

                    foreach (var x in BanItems.ToArray())
                    {
                        BanItem banItem = x.Value;
                        TimeSpan ts = DateTime.Now - banItem.BanTime;
                        if (banItem.status == 1 && ts.TotalMinutes > BanDuration)
                        {
                            BanItems.Remove(x.Key);
                            needUpdateRule = true;
                        }

                        // 如果超过10分钟，次数都很少，属于比较正常的连接请求，则在最后一次活跃连接10分钟后清理
                        TimeSpan ts2 = DateTime.Now - banItem.lastActive;
                        if (banItem.status != 1 && ts2.TotalMinutes > CleanInterval)
                        {
                            BanItems.Remove(x.Key);
                            LogI(RULE_NAME + " clean " + banItem.ToString());
                        }
                    }
                    if (needUpdateRule)
                    {
                        updateRules();
                    }
                }
                catch (Exception e)
                {
                    LogE(RULE_NAME + " error occure: " + e.Message);
                }

        }

        private void updateRules()
        {
            String ips = GetBanIPs();
            cmd(string.Format("netsh advfirewall firewall set rule name={0} new remoteip={1}", RULE_NAME, GetBanIPs()));
            LogI(RULE_NAME + " update firewall banned IPs: " + ips);
        }

        /// <summary>
        /// 通配符转正则 处理 ? *
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static String WildCardToRegex(string rex)
        {
            return "^" + Regex.Escape(rex).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }

        private bool IsWhiteIP(string ip)
        {
            if (mWhiteList == null) return false;
            foreach (string s in mWhiteList)
            {
                var rex = WildCardToRegex(s);
                if (Regex.IsMatch(ip, rex)) return true;
            }
            return false;
        }

        private string GetBanIPs()
        {
            StringBuilder sb = new StringBuilder("8.8.8.8");

            foreach (var kv in BanItems)
            {
                BanItem item = kv.Value;
                if (IsWhiteIP(item.IP)) continue;

                if (item.count >= Gate)
                {
                    if (item.status == 0)
                        item.BanTime = DateTime.Now;
                    item.status = 1;
                    sb.Append("," + item.IP);
                }
            }
            return sb.ToString();
        }

        public void Stop()
        {
            cmd("netsh advfirewall firewall delete rule name=" + RULE_NAME);
            if (thread != null)
            {
                thread.Abort();
            }
            LogI(RULE_NAME + " stopped.");
        }

        public void exec(string cmd)
        {
            Process.Start(cmd);
        }

        public void cmd(string cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.Arguments = "/c " + cmd;
            p.Start();
            p.WaitForExit();
            p.Close();
        }
    }
}
