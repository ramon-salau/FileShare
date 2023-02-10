using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Net;
using System.Windows.Forms;
namespace FileShare
{
    class Network
    {
        static Process newprocess = new Process();
        public enum Connection
        {
            Created,
            NotCreated
        }
        public static Connection CreateConnection()
        {
            newprocess.StartInfo.UseShellExecute = false;
            newprocess.StartInfo.CreateNoWindow = true;
            newprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process_Start_1();
            
            return Connection.Created;
        }
        public static void Process_Start_1()
        {
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan stop hostednetwork";
            try
            {
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    Process_Start_2();
                }
            }
            catch { }
        }
        static void Process_Start_2()
        {
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan set hostednetwork ssid=FileShare key=fileshare";
            try
            {
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                    Process_Start_3();
                }
            }
            catch { }
        }
        static void Process_Start_3()
        {
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan start hostednetwork";
            try
            {

                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                }
            }
            catch { }
        }
        public static void Process_Stop()
        {
            newprocess.StartInfo.FileName = "netsh";
            newprocess.StartInfo.Arguments = "wlan stop hostednetwork";
            try
            {
                using (Process execute = Process.Start(newprocess.StartInfo))
                {
                    execute.WaitForExit();
                }
            }
            catch { }
        }
        /*
        private void Play_Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            if ((String)Play_Stop_Button.Content == "Send")
            {
                Process_Start_1();
            }
            else if ((String) == "Start")
            {

                Process_Stop();
            }
        }*/
        
    }
}
