using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MathServiceLibrary;
using System.ServiceModel;

namespace MathWindowsServiceHost
{
    public partial class MathWinService : ServiceBase
    {
        private ServiceHost _myHost;
        public MathWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_myHost != null)
            {
                _myHost.Close();
            }
            // Create the host and specify a URL for an HTTP binding.
            _myHost = new ServiceHost(typeof(MathService),
                new Uri("http://localhost:8080/MathServiceLibrary"));
            // Opt in for the default endpoints!
            _myHost.AddDefaultEndpoints();
            // Open the host.
            _myHost.Open();
        }

        protected override void OnStop()
        {
            if (_myHost != null)
            {
                _myHost.Close();
            }
        }
    }
}
