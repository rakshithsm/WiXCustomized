using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using Microsoft.Deployment.WindowsInstaller;
using Newtonsoft.Json;

namespace ServiceNameCustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ShowServiceNameCustomDialog(Session session)
        {
            session.Log("Begin ShowServiceNameCustomDialog");

            var formServiceName = new FormServiceName();
            if (formServiceName.ShowDialog() == DialogResult.Cancel)
            {
                return ActionResult.UserExit;
            }

            var serviceName = formServiceName.ServiceName;

            session["SERVICENAME"] = serviceName;

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult UninstallServiceCustomAction(Session session)
        {
            session.Log("Begin UninstallServiceCustomAction");

            try
            {
                var formServiceName = new FormServiceName();
                if (formServiceName.ShowDialog() == DialogResult.Cancel)
                {
                    return ActionResult.UserExit;
                }

                var serviceName = formServiceName.ServiceName;

                var strCmdText = $"/C sc delete \"{serviceName}\"";

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "CMD.exe",
                    Arguments = strCmdText
                };
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception e)
            {
                string path = @"c:\temp\MyTest.txt";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(e));
                }
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }
    }
}
