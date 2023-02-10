using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace FileShare
{
    class ShareFile
    {
        private static System.Windows.Forms.Form progressForm = new Form();
        private static System.Windows.Forms.ProgressBar progressBar = new ProgressBar();
        private static System.Windows.Forms.Label label1 = new Label();
        private static System.Windows.Forms.Label label2 = new Label();
        private static System.Windows.Forms.Label label3 = new Label();
        private static System.Windows.Forms.Label label4 = new Label();
        public static void SendFile(NetworkStream ns,string filepath)
        {
            FileInfo file;
            FileStream fileStream;
            try
            {
                file = new FileInfo(filepath);
                fileStream = file.OpenRead();
            }
            catch
            {
                MessageBox.Show("Error opening file");
                return;
            }

            // Send file info
            {
                byte[] fileName = ASCIIEncoding.ASCII.GetBytes(file.Name);
                byte[] fileNameLength = BitConverter.GetBytes(fileName.Length);
                byte[] fileLength = BitConverter.GetBytes(file.Length);
                ns.Write(fileLength, 0, fileLength.Length);
                ns.Write(fileNameLength, 0, fileNameLength.Length);
                ns.Write(fileName, 0, fileName.Length);
            }
            /*
            {
                byte[] permission = new byte[1];
                await ns.ReadAsync(permission, 0, 1);
                if (permission[0] != 1)
                {
                    MessageBox.Show("Permission denied");
                    return;
                }
            }*/
            // Sending
            int read;
            int totalWritten = 0;
            byte[] buffer = new byte[32 * 1024]; // 32k chunks
            while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ns.Write(buffer, 0, read);
                totalWritten += read;
                //progressBar1.Value = (int)((100d * totalWritten) / file.Length);
            }

            fileStream.Dispose();
            fileStream.Close();
        }
        public static void RecieveFile(NetworkStream ns)
        {
            long fileLength;
            string fileName;
            {
                byte[] fileNameBytes;
                byte[] fileNameLengthBytes = new byte[4]; //int32
                byte[] fileLengthBytes = new byte[8]; //int64

                ns.Read(fileLengthBytes, 0, 8); // int64
                ns.Read(fileNameLengthBytes, 0, 4); // int32
                fileNameBytes = new byte[BitConverter.ToInt32(fileNameLengthBytes, 0)];
                ns.Read(fileNameBytes, 0, fileNameBytes.Length);

                fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
                fileName = ASCIIEncoding.ASCII.GetString(fileNameBytes);
            }

            /*
            if (MessageBox.Show(String.Format("Requesting permission to receive file:\r\n\r\n{0}\r\n{1} bytes long", fileName, fileLength), "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            */
            // Set save location
            
            FileStream fileStream = File.Open(@"C:/Bunifu/" + fileName, FileMode.Create);

            // Receive
            int read;
            int totalRead = 0;
            byte[] buffer = new byte[32 * 1024];
            // 32k chunks
            
            //Transfer Progress
            {
                //ProgressBar
                progressBar.Location = new System.Drawing.Point(12, 90);
                progressBar.Name = "progressBar1";
                progressBar.Size = new System.Drawing.Size(260, 23);
                progressBar.TabIndex = 0;
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 0;
                progressForm.Controls.Add(progressBar);
                // label1
                // 
                label1.AutoSize = true;
                label1.Location = new System.Drawing.Point(12, 22);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(35, 13);
                label1.TabIndex = 1;
                label1.Text = "Name : ";
                // 
                // label2
                // 
                label2.AutoSize = true;
                label2.Location = new System.Drawing.Point(12, 58);
                label2.Name = "label2";
                label2.Size = new System.Drawing.Size(27, 13);
                label2.TabIndex = 2;
                label2.Text = "Size : ";
                // 
                // label3
                // 
                label3.AutoSize = true;
                label3.Location = new System.Drawing.Point(72, 22);
                label3.Name = "label3";
                label3.Size = new System.Drawing.Size(35, 13);
                label3.TabIndex = 3;
                label3.Text = fileName;
                // 
                // label4
                // 
                label4.AutoSize = true;
                label4.Location = new System.Drawing.Point(72, 58);
                label4.Name = "label4";
                label4.Size = new System.Drawing.Size(35, 13);
                label4.TabIndex = 4;
                label4.Text = String.Format("{0} bytes", fileLength);
                //Progress Form
                progressForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                progressForm.ClientSize = new System.Drawing.Size(284, 125);
                progressForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                progressForm.Controls.Add(progressBar);
                progressForm.Controls.Add(label1);
                progressForm.Controls.Add(label2);
                progressForm.Controls.Add(label3);
                progressForm.Controls.Add(label4);
                progressForm.Activate();
                progressForm.ShowDialog();
            }


            while((read = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, read);
                totalRead += read;
                if(totalRead >= fileLength)
                {
                    return;
                    
                }
                //progressBar.Value = (int)((100d * totalRead) / fileLength);
            }

            // Get file info
            
        }
    }
}
