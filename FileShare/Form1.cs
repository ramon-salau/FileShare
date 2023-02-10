using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileShare
{
    public partial class Main : Form
    {
        static int PORT = 1723;
        TcpListener listener;
        NetworkStream ns;
        public Main()
        {
            InitializeComponent();
            {
                bool isAdmin;
                try
                {
                    WindowsIdentity user = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(user);
                    isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                catch (UnauthorizedAccessException)
                {
                    isAdmin = false;
                }
                catch (Exception)
                {
                    isAdmin = false;
                }
                isAdmin = true;
            }
        }
        private void create_button_Click(object sender, EventArgs e)
        {
            if(((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText == "CREATE")
            {
                try
                {
                    if (Network.CreateConnection() == Network.Connection.Created)
                    {
                        try
                        {
                            status.Text = "Waiting for connection";
                            listener = TcpListener.Create(PORT);
                            listener.Start();
                            TcpClient client = listener.AcceptTcpClient();
                            ns = client.GetStream();
                            status.Text = "Connected";
                            create_button.ButtonText = "CHOOSE FILE";
                            join_button.Visible = false;
                            Task.Factory.StartNew(() => {
                                while (true)
                                {
                                    if (ns.DataAvailable)
                                    {
                                        ShareFile.RecieveFile(ns);
                                    }
                                }
                            });

                        }
                        catch (Exception se)
                        {
                            MessageBox.Show(se.Message);
                        }
                    }
                }
                catch(Exception conerror)
                {
                    status.Text = conerror.Message;
                }
                
            }
            else if(((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText == "CHOOSE FILE")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Choose File";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ShareFile.SendFile(ns,ofd.FileName);
                    ns.Flush();
                }
            }
            
        }

        private void join_button_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect("127.0.0.1", PORT);
                ns = client.GetStream();
                status.Text = "Connected";
                create_button.ButtonText = "CHOOSE FILE";
                join_button.Visible = false;
                Task.Factory.StartNew(() => {
                    while (true)
                    {
                        if (ns.DataAvailable)
                        {
                            ShareFile.RecieveFile(ns);
                        }
                    } });
            }
            catch
            {
                status.Text = "Error connecting...";
            }
            
        }
        public void CreateListener()
        {
            // Listen
            try
            {
                listener = TcpListener.Create(PORT);
                status.Text = "Waiting for connection";
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                ns = client.GetStream();
            }
            catch(Exception e)
            {
                status.Text = e.Message;
            }
            
            
            /*Task.Factory.StartNew(() => {
                while (true)
                {
                    if (ns.DataAvailable)
                    {
                        ShareFile.RecieveFile(ns);
                    }
                }
            });*/
            join_button.Visible = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
