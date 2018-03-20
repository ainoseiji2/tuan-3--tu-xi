using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace Tuxi
{
    public partial class Form1 : Form
    {
        Socket server, client;
        EndPoint remote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint gui = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            remote = (EndPoint)gui;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bua";
            byte[] sendData = Encoding.ASCII.GetBytes("0");
            server.SendTo(sendData, remote);
            byte[] receivedata = new byte[20];
            server.ReceiveFrom(receivedata, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(receivedata);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Keo";
            byte[] sendData = Encoding.ASCII.GetBytes("1");
            server.SendTo(sendData, remote);
            byte[] receivedata = new byte[20];
            server.ReceiveFrom(receivedata, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(receivedata);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            byte[] sendData = Encoding.ASCII.GetBytes("2");
            server.SendTo(sendData, remote);
            byte[] receivedata = new byte[20];
            server.ReceiveFrom(receivedata, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(receivedata);
        }
    }
}
