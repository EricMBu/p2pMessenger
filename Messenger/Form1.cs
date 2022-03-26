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

        private void changePort_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string portIn = Interaction.InputBox("Change port number", "Port:");
        }
    }
}
