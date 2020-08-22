using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PortFail2Ban
{
    public partial class PortFail2Ban : ServiceBase
    {
        CoreModule core = new CoreModule();
        public PortFail2Ban()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            core.Start();
        }

        protected override void OnStop()
        {
            core.Stop();
        }
    }
}
