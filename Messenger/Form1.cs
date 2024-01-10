using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace Messenger
{
    public partial class Form1 : Form
    {
        public static UdpClient udpCli;
        public static string uname { get; private set; }
        public static int port = 15500;
        public static IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        public Thread receiveThread;

        //TODO: Add error handling when all this makes sense
        private static void SendMessage(string message, IPAddress addr)
        {
            udpCli = new UdpClient();
            byte[] data = Encoding.Unicode.GetBytes(uname + ":" + message);
            udpCli.Send(data, data.Length, addr.ToString(), port);
        }
        private static void RecieveMessages(object form)
        {
            UdpClient listener = new UdpClient();
            IPEndPoint remoteEP = new IPEndPoint(localAddr, port);
            Form1 formCast = (Form1)form;
            listener.Client.Bind(remoteEP);
            while (true)
            {
                byte[] recData = listener.Receive(ref remoteEP);
                string rawMessage = Encoding.Unicode.GetString(recData);
                Match m = Regex.Match(rawMessage, "^([^:]{1,}):(.{1,})$");
                if (m.Success)
                {
                    Action display = delegate { DisplayMessage(m.Groups[1].Value, m.Groups[2].Value, formCast); };
                    formCast.Invoke(display);
                }
            }
        }
        public void setConnectionStatus(string status)
        {
            connectionStatus.Text = status;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            receiveThread = new Thread(new ParameterizedThreadStart(RecieveMessages));
            receiveThread.Start(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private static void DisplayMessage(string uname, string message, Form1 form)
        {
            int selStart = form.chatWindow.Text.Length;
            form.chatWindow.Text += $"{uname}: {message} \n";
            form.chatWindow.SelectionStart = selStart;
            form.chatWindow.SelectionLength = uname.Length;
            form.chatWindow.SelectionColor = Color.Blue;
        }
        private void changePort_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetPort();
        }
        private void SetPort()
        {
            try
            {
                string portIn = Interaction.InputBox("Change port number", "Port:");
                if (portIn.Length != 0)
                {
                    int portNum = Convert.ToInt16(portIn);
                }
                lblPortNum.Text = portIn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid port number", "Port error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetPort();
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(msgBox.Text.Length > 0)
            {
                string message = msgBox.Text;
                //DisplayMessage(uname, message);
                SendMessage(message, localAddr);
            }
            msgBox.Text = "";
        }

        private void btnNameset_Click(object sender, EventArgs e)
        {
            if(txtUName.Text.Length > 0)
            {
                uname = txtUName.Text.Trim();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            receiveThread.Abort();
        }
    }
}
