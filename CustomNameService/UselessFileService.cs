using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomNameService
{
    public partial class UselessFileService : ServiceBase
    {
        private Timer Timer { get; set; }
        public UselessFileService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Timer = new Timer(UselessCallback, null, 0, 60000);
        }

        private void UselessCallback(object state)
        {
            string path = @"c:\temp\MyTest.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Hello World");
                sw.WriteLine("Welcome");
            }
        }

        protected override void OnStop()
        {
            Timer.Dispose();
        }
    }
}
