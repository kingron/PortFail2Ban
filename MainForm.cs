using System;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

namespace PortFail2Ban
{
    public partial class MainForm : Form
    {
        private CoreModule core = new CoreModule();
        private WhiteListForm FrmWhiteList;

        public MainForm()
        {
            InitializeComponent();
            tbPort.Text = core.Port.ToString();
            tbGate.Text = core.Gate.ToString();
            tbBanDuration.Text = core.BanDuration.ToString();
            tbClean.Text = core.CleanInterval.ToString();
            bool exist = ServiceIsExisted("PortFail2Ban");
            tbInstall.Enabled = !exist;
            tbUninstall.Enabled = exist;
        }

        private void UpdateUI(bool start)
        {
            btnStart.Enabled = !start;
            btnStop.Enabled = start;
        }

        private bool ServiceIsExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                core.Port = int.Parse(tbPort.Text.Trim());
                core.BanDuration = int.Parse(tbBanDuration.Text.Trim());
                core.CleanInterval = int.Parse(tbClean.Text.Trim());
                core.Gate = int.Parse(tbGate.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("参数错误: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            core.Start();
            tmrUI.Enabled = true;
            UpdateUI(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrUI.Enabled = false;
            core.Stop();
            UpdateUI(false);
        }

        private void tmrUI_Tick(object sender, EventArgs e)
        {
            try
            {
                lvData.VirtualListSize = core.BanItems.Count;
                lvData.Invalidate();
            }
            catch (Exception)
            {
            }
        }

        private void lvData_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex > core.BanItems.Count - 1) return;

            try
            {
                var item = core.BanItems.ElementAt(e.ItemIndex);
                e.Item = new ListViewItem();
                BanItem banItem = item.Value;
                e.Item.ImageIndex = banItem.status;
                e.Item.Text = "";
                e.Item.SubItems.Add(banItem.IP);
                e.Item.SubItems.Add(banItem.count.ToString());
                e.Item.SubItems.Add(banItem.StartTime.ToString());
                e.Item.SubItems.Add(banItem.lastActive.ToString());
                e.Item.SubItems.Add(banItem.status == 1 ? banItem.BanTime.ToString() : "");
                e.Item.SubItems.Add(banItem.lastPorts);
            }
            catch (Exception ex)
            {
                e.Item = new ListViewItem();
                e.Item.Text = "-";
                e.Item.SubItems.Add("-");
                e.Item.SubItems.Add("-");
                e.Item.SubItems.Add("-");
                e.Item.SubItems.Add("-");
                e.Item.SubItems.Add("-");
                e.Item.SubItems.Add(ex.Message);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            chPorts.Width = -2;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStop.PerformClick();
        }

        private void tbInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cmdline = { };
                string serviceFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                TransactedInstaller transactedInstaller = new TransactedInstaller();
                AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);
                transactedInstaller.Installers.Add(assemblyInstaller);
                transactedInstaller.Install(new System.Collections.Hashtable());
                MessageBox.Show("Install success.\r\n\r\n please close application and start service by Windows services manager or reboot system.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbInstall.Enabled = false;
                tbUninstall.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Install error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                core.cmd("net stop PortFail2Ban");
                string[] cmdline = { };
                string serviceFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                TransactedInstaller transactedInstaller = new TransactedInstaller();
                AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);
                transactedInstaller.Installers.Add(assemblyInstaller);
                transactedInstaller.Uninstall(null);
                MessageBox.Show("Uninstall success.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbInstall.Enabled = true;
                tbUninstall.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uninstall error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbWhiteList_Click(object sender, EventArgs e)
        {
            if (FrmWhiteList == null) FrmWhiteList = new WhiteListForm();

            FrmWhiteList.tbIPs.Text = core.WhiteList.Replace(";", "\r\n");
            if (FrmWhiteList.ShowDialog() == DialogResult.OK)
            {
                core.WhiteList = FrmWhiteList.tbIPs.Text.Trim().Replace("\r\n", ";");
            }
        }

        private void tbAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeah, Delphi/OOP 10x better than VS/C#\r\n\r\nHappy coding~", "Fuck CCP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
