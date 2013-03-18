using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using CellNetixApps.Source.Path.Forms;

namespace CellNetixApps.Source.Classes
{

    class cNetworkListener
    {
        TcpListener tcpListener;
        Thread listenThread;
        DevExpress.XtraEditors.XtraForm frm;
        public cNetworkListener(DevExpress.XtraEditors.XtraForm frm)
        {
            this.frm = frm;
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, Program.PORT_NUMBER);
                listenThread = new Thread(listenForClients);
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listenForClients()
        {
            try
            {
                tcpListener.Start();
            }
            catch (Exception)
            {

             MessageBox.Show("Application did not shut down correctly last time. Need to restart computer to use Telepathology.");
                return;
            }

            while (true)
            {
                try
                {
                    TcpClient client = this.tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(handleClientCommunication));
                    clientThread.Start(client);
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                }

            }

        }

        private void handleClientCommunication(object tcpclient)
        {
            TcpClient client = (TcpClient)tcpclient;
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] msg = new byte[4096];
                int bytesRead;
                while (true)
                {
                    bytesRead = 0;
                    try
                    {
                        bytesRead = stream.Read(msg, 0, 4096);
                    }
                    catch
                    {
                        break;
                    }

                    if (bytesRead == 0)
                        break;

                    ASCIIEncoding encoder = new ASCIIEncoding();
                    string totalMsg = encoder.GetString(msg, 0, bytesRead);
                    string name = totalMsg.Split(',')[0];
                    DialogResult dr = MessageBox.Show(name + " would like to start a telapathology session", "Telepathology", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        string code = totalMsg.Substring(name.Length + 1, totalMsg.Length - name.Length - 1);
                        //MessageBox.Show(code);

                        Program.frmPath.Invoke(new MethodInvoker(delegate
                        {
                            frmScreen frmS = new frmScreen(code);
                            frmS.ShowDialog();
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        public void Stop()
        {
            try
            {
                //  listenThread.Abort();
                tcpListener.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
