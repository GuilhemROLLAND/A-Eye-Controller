using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEye
{
    public class SubProcess
    {
        public void RunEncod()
        {
            //if (Program.Ip == null)
            //{
            //    MessageBox.Show("Set IP first");
            //    return;
            //}
            //run_cmd(".\\CommunicationModule\\client.py", "-i " + Program.Ip.ToString() + " -p 64000");
        }
        public void RunDecod()
        {
            MessageBox.Show("In RunDecod");
        }

        private void run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            Process? process = Process.Start(start);
            if (process == null)
            {
                Program.log += "[ERROR][RUN_CMD] Cannot start " + cmd + " process\n";
                return;
            }
            else
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Program.log += "[PYTHON][" + cmd + "] " + result + "\n";
                }
            }
        }

        internal void ClientPythonLaunch(object? obj)
        {
            while (Program.Ip == null)
            {
                //MessageBox.Show("Set IP first");
                //return;
            }
            Program.log += "[INFO] Run Python Client\n";
            run_cmd(".\\A-Eye_CommunicationModule\\client.py", "-i " + Program.Ip.ToString() + " -p 64000");
        }

        public void PipeServer_Run()
        {
            NamedPipeServerStream serverStream = new NamedPipeServerStream("CSServer", PipeDirection.In);
            string line;
            while (true)
            {
                serverStream.WaitForConnection();
                StreamReader reader = new StreamReader(serverStream);
                while ((line = reader.ReadLine()) != null)
                {
                    Program.log += "[INFO][From Python pipe] " + line + "\n";
                    if (line.Contains("Image"))
                    {
                        Program.controller.refresh_img();
                        if (line.Contains("Manual"))
                        {
                            run_cmd("StockagePC/run_stockage.py", "-f temp.bmp -m M");
                        }
                        else
                        {
                            run_cmd("StockagePC/run_stockage.py", "-f temp.bmp");
                        }
                    }
                }
                serverStream.Disconnect();
            }
        }
    }
}
