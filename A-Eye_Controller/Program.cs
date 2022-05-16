using System.Diagnostics;
using System.Net;

namespace AEye
{
    internal static class Program
    {
        public static Trigger trigger = new Trigger();

        public static IPAddress? Ip;

        public static Controller controller = new Controller();

        public static string log = "";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Thread run_thr = new Thread(RunThread);
            run_thr.Start();
            Application.Run(controller);
            Environment.Exit(0);
        }

        static void RunThread()
        {
            SubProcess subProcess = new SubProcess();
            Thread pipe = new Thread(subProcess.PipeServer_Run);
            pipe.Start();
            Thread clientTCP = new Thread(subProcess.ClientPythonLaunch);
            clientTCP.Start();

            while (true)
            {
                if (trigger.EncodeTC)
                {
                    trigger.EncodeTC = false;
                    Thread encod_thr = new Thread(subProcess.RunEncod);
                    encod_thr.Start();
                }
                if (trigger.DecodeTC)
                {
                    trigger.DecodeTC = false;
                    Thread decod_thr = new Thread(subProcess.RunDecod);
                    decod_thr.Start();
                }
                Thread.Sleep(10);
            }
        }
    }
}