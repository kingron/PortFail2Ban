namespace PortFail2Ban
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.spiProject = new System.ServiceProcess.ServiceProcessInstaller();
            this.Installer = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiProject
            // 
            this.spiProject.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiProject.Password = null;
            this.spiProject.Username = null;
            // 
            // Installer
            // 
            this.Installer.Description = "Serivce Installer";
            this.Installer.DisplayName = "Service and desktop demo";
            this.Installer.ServiceName = "Service and desktop demo";
            this.Installer.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiProject,
            this.Installer});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiProject;
        private System.ServiceProcess.ServiceInstaller Installer;
    }
}