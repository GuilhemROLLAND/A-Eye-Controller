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
            Thread pipe_thr = new Thread(subProcess.PipeServer_Run);
            pipe_thr.Start();
            Thread clientTCP_thr = new Thread(subProcess.ClientPythonLaunch);
            clientTCP_thr.Start();
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}