﻿namespace PortFail2Ban
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbTop = new System.Windows.Forms.ToolStrip();
            this.lblPort = new System.Windows.Forms.ToolStripLabel();
            this.tbPort = new System.Windows.Forms.ToolStripTextBox();
            this.lblGate = new System.Windows.Forms.ToolStripLabel();
            this.tbGate = new System.Windows.Forms.ToolStripTextBox();
            this.lblBanDuration = new System.Windows.Forms.ToolStripLabel();
            this.tbBanDuration = new System.Windows.Forms.ToolStripTextBox();
            this.lblClean = new System.Windows.Forms.ToolStripLabel();
            this.tbClean = new System.Windows.Forms.ToolStripTextBox();
            this.tbWhiteList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbInstall = new System.Windows.Forms.ToolStripButton();
            this.tbUninstall = new System.Windows.Forms.ToolStripButton();
            this.ilList = new System.Windows.Forms.ImageList(this.components);
            this.lvData = new System.Windows.Forms.ListView();
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPorts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrUI = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAbout = new System.Windows.Forms.ToolStripButton();
            this.tbTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTop
            // 
            this.tbTop.BackColor = System.Drawing.Color.Transparent;
            this.tbTop.GripMargin = new System.Windows.Forms.Padding(0);
            this.tbTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPort,
            this.tbPort,
            this.lblGate,
            this.tbGate,
            this.lblBanDuration,
            this.tbBanDuration,
            this.lblClean,
            this.tbClean,
            this.tbWhiteList,
            this.toolStripSeparator1,
            this.btnStart,
            this.btnStop,
            this.toolStripSeparator2,
            this.tbInstall,
            this.tbUninstall,
            this.toolStripSeparator3,
            this.tbAbout});
            this.tbTop.Location = new System.Drawing.Point(0, 0);
            this.tbTop.Name = "tbTop";
            this.tbTop.Padding = new System.Windows.Forms.Padding(0);
            this.tbTop.Size = new System.Drawing.Size(1146, 40);
            this.tbTop.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 37);
            this.lblPort.Text = "Port";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(50, 40);
            this.tbPort.Text = "3389";
            this.tbPort.ToolTipText = "The port number will be protect, for remote desktop is 3389.\r\n待保护的端口，默认远程桌面3389端口" +
    "";
            // 
            // lblGate
            // 
            this.lblGate.Name = "lblGate";
            this.lblGate.Size = new System.Drawing.Size(35, 37);
            this.lblGate.Text = "Limit";
            // 
            // tbGate
            // 
            this.tbGate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tbGate.Name = "tbGate";
            this.tbGate.Size = new System.Drawing.Size(40, 40);
            this.tbGate.Text = "4";
            this.tbGate.ToolTipText = "How many connections allow before block.\r\n黑客连接多少次后自动封锁对应IP。";
            // 
            // lblBanDuration
            // 
            this.lblBanDuration.Name = "lblBanDuration";
            this.lblBanDuration.Size = new System.Drawing.Size(112, 37);
            this.lblBanDuration.Text = "Block duration(m)";
            // 
            // tbBanDuration
            // 
            this.tbBanDuration.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tbBanDuration.Name = "tbBanDuration";
            this.tbBanDuration.Size = new System.Drawing.Size(40, 40);
            this.tbBanDuration.Text = "120";
            this.tbBanDuration.ToolTipText = "封锁后，多久解封该IP";
            // 
            // lblClean
            // 
            this.lblClean.Name = "lblClean";
            this.lblClean.Size = new System.Drawing.Size(102, 37);
            this.lblClean.Text = "Clean period(m)";
            // 
            // tbClean
            // 
            this.tbClean.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tbClean.Name = "tbClean";
            this.tbClean.Size = new System.Drawing.Size(40, 40);
            this.tbClean.Text = "10";
            this.tbClean.ToolTipText = "Reset IP connection info after given period(minute)\r\n对于正常连接的IP，多久后复位连接信息，单位分钟。";
            // 
            // tbWhiteList
            // 
            this.tbWhiteList.Image = ((System.Drawing.Image)(resources.GetObject("tbWhiteList.Image")));
            this.tbWhiteList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbWhiteList.Name = "tbWhiteList";
            this.tbWhiteList.Size = new System.Drawing.Size(43, 37);
            this.tbWhiteList.Text = "&Allow";
            this.tbWhiteList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbWhiteList.ToolTipText = "White list IP for incoming connections";
            this.tbWhiteList.Click += new System.EventHandler(this.tbWhiteList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(39, 37);
            this.btnStart.Text = "&Start";
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(39, 37);
            this.btnStop.Text = "S&top";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tbInstall
            // 
            this.tbInstall.Image = ((System.Drawing.Image)(resources.GetObject("tbInstall.Image")));
            this.tbInstall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbInstall.Name = "tbInstall";
            this.tbInstall.Size = new System.Drawing.Size(46, 37);
            this.tbInstall.Text = "&Install";
            this.tbInstall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbInstall.ToolTipText = "Install as Windows service\r\nOnce installed success, please close window and \r\nsta" +
    "rt service by Windows services manager or reboot system";
            this.tbInstall.Click += new System.EventHandler(this.tbInstall_Click);
            // 
            // tbUninstall
            // 
            this.tbUninstall.Image = ((System.Drawing.Image)(resources.GetObject("tbUninstall.Image")));
            this.tbUninstall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUninstall.Name = "tbUninstall";
            this.tbUninstall.Size = new System.Drawing.Size(44, 37);
            this.tbUninstall.Text = "&Unin..";
            this.tbUninstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbUninstall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbUninstall.ToolTipText = "Uninstall Windows service";
            this.tbUninstall.Click += new System.EventHandler(this.tbUninstall_Click);
            // 
            // ilList
            // 
            this.ilList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilList.ImageStream")));
            this.ilList.TransparentColor = System.Drawing.Color.Transparent;
            this.ilList.Images.SetKeyName(0, "Connect_16x.png");
            this.ilList.Images.SetKeyName(1, "StatusInvalid_16x.png");
            this.ilList.Images.SetKeyName(2, "EnableLog_16x.png");
            // 
            // lvData
            // 
            this.lvData.AutoArrange = false;
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chStatus,
            this.chIP,
            this.chCount,
            this.chStartTime,
            this.chLastActive,
            this.chTime,
            this.chPorts});
            this.lvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvData.FullRowSelect = true;
            this.lvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(0, 40);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(1146, 520);
            this.lvData.SmallImageList = this.ilList;
            this.lvData.TabIndex = 3;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            this.lvData.VirtualMode = true;
            this.lvData.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvData_RetrieveVirtualItem);
            // 
            // chStatus
            // 
            this.chStatus.Text = "";
            this.chStatus.Width = 20;
            // 
            // chIP
            // 
            this.chIP.Text = "IP Address";
            this.chIP.Width = 120;
            // 
            // chCount
            // 
            this.chCount.Text = "Count";
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "First Time";
            this.chStartTime.Width = 120;
            // 
            // chLastActive
            // 
            this.chLastActive.Text = "Last Active";
            this.chLastActive.Width = 120;
            // 
            // chTime
            // 
            this.chTime.Text = "Block at";
            this.chTime.Width = 120;
            // 
            // chPorts
            // 
            this.chPorts.Text = "Ports history";
            this.chPorts.Width = 542;
            // 
            // tmrUI
            // 
            this.tmrUI.Interval = 1000;
            this.tmrUI.Tick += new System.EventHandler(this.tmrUI_Tick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // tbAbout
            // 
            this.tbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tbAbout.Image")));
            this.tbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.Size = new System.Drawing.Size(46, 37);
            this.tbAbout.Text = "&Eww...";
            this.tbAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbAbout.Click += new System.EventHandler(this.tbAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 560);
            this.Controls.Add(this.lvData);
            this.Controls.Add(this.tbTop);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Port Fail2Ban";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.tbTop.ResumeLayout(false);
            this.tbTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.ToolStrip tbTop;
		private System.Windows.Forms.ToolStripLabel lblPort;
		private System.Windows.Forms.ToolStripTextBox tbPort;
		private System.Windows.Forms.ToolStripButton btnStart;
		private System.Windows.Forms.ToolStripButton btnStop;
		private System.Windows.Forms.ImageList ilList;
		private System.Windows.Forms.ToolStripLabel lblBanDuration;
		private System.Windows.Forms.ToolStripTextBox tbBanDuration;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ListView lvData;
		private System.Windows.Forms.ColumnHeader chStatus;
		private System.Windows.Forms.ColumnHeader chIP;
		private System.Windows.Forms.ColumnHeader chTime;
		private System.Windows.Forms.ColumnHeader chCount;
		private System.Windows.Forms.Timer tmrUI;
		private System.Windows.Forms.ColumnHeader chStartTime;
        private System.Windows.Forms.ColumnHeader chPorts;
        private System.Windows.Forms.ColumnHeader chLastActive;
        private System.Windows.Forms.ToolStripLabel lblClean;
        private System.Windows.Forms.ToolStripTextBox tbClean;
        private System.Windows.Forms.ToolStripLabel lblGate;
        private System.Windows.Forms.ToolStripTextBox tbGate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbInstall;
        private System.Windows.Forms.ToolStripButton tbUninstall;
        private System.Windows.Forms.ToolStripButton tbWhiteList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbAbout;
    }
}