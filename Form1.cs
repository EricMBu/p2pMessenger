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

namespace Messenger
{
    public partial class Form1 : Form
    {
        public string uname { get; private set; }
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

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void DisplayMessage(string uname, string message)
        {
            int selStart = chatWindow.Text.Length;
            chatWindow.Text += $"{uname}: {message} \n";
            chatWindow.SelectionStart = selStart;
            chatWindow.SelectionLength = uname.Length;
            chatWindow.SelectionColor = Color.Blue;
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
                DisplayMessage(uname, message);
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
    }
}
