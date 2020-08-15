using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortFail2Ban
{
    public partial class MainForm : Form
    {
        private CoreModule core = new CoreModule();

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateUI(bool start)
        {
            btnStart.Enabled = !start;
            btnStop.Enabled = start;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            core.port = int.Parse(tbPort.Text.Trim());
            core.BanDuration = int.Parse(tbBanDuration.Text.Trim());
            core.CleanInterval = int.Parse(tbClean.Text.Trim());
            core.Gate = int.Parse(tbGate.Text.Trim());
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
                e.Item.Text = banItem.status == 0 ? "" : "Blocked";
                e.Item.SubItems.Add(banItem.IP);
                e.Item.SubItems.Add(banItem.count.ToString());
                e.Item.SubItems.Add(banItem.StartTime.ToString());
                e.Item.SubItems.Add(banItem.lastActive.ToString());
                e.Item.SubItems.Add(banItem.status == 0 ? "" : banItem.BanTime.ToString());
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
    }
}
