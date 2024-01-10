using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Messenger
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

/*            int port = 49200;
            IPAddress address = IPAddress.Parse("127.0.0.1");

            TcpListener server = new TcpListener(address, port);

            server.Start();

            Form1 frm1 = new Form1();
            Byte[] bytes = new Byte[256];
            String data = null;

            while (true)
            {
                frm1.setConnectionStatus("Waiting");

                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;

                NetworkStream stream = client.GetStream();

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    
                }
            }*/
        }
    }
}
