using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace project_ninjakid_client_03
{
    public partial class client : Form
    {
        Socket sck;
        Thread receiveThread; // 항상 정보 받는 thread
        public client()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ServerIP = "192.168.135.1"; // IP (고정)
            string Port = "2002"; // 포트 넘버 (고정)

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ServerIP), Convert.ToInt32(Port));
            try
            {
                // 소켓 연결
                sck.Connect(remoteEP);

                // ID/PW 전송
                sck.Send(Encoding.UTF8.GetBytes("info:"+tbID.Text+"/"+tbPW.Text));
                this.Invoke(new MethodInvoker(delegate ()
                {
                    tbClientLog.AppendText("connected\n");
                }));
            }
            catch
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    tbClientLog.AppendText("connection failed\n");
                }));
                return;
            }
            // 정보 받기 thread 생성/시작
            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //int s = sck.Send(Encoding.UTF8.GetBytes("data:"+textBox1.Text)); // s = bytes 수
            int s = 0;
            if (comboBox1.SelectedIndex == 0) // 이동
                s = sck.Send(Encoding.UTF8.GetBytes("move:" + textBox1.Text));
            else if(comboBox1.SelectedIndex == 1) // 공격
                s = sck.Send(Encoding.UTF8.GetBytes("attc:" + textBox1.Text));
            else if(comboBox1.SelectedIndex == 2) // 체력
                s = sck.Send(Encoding.UTF8.GetBytes("heal:" + textBox1.Text));

            if (s > 0)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    tbClientLog.AppendText("\n");
                    tbClientLog.AppendText(s.ToString() + " bytes data sent\n");
                }));
            }
        }

        private void Receive()
        {
            while (sck.Connected)
            {
                byte[] buffer = new byte[1024 * 4];
                int r = sck.Receive(buffer, 0);
                if (r > 0)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        tbClientLog.AppendText("\n");
                        tbClientLog.AppendText("return : " + Encoding.UTF8.GetString(buffer) + "\n");
                    }));
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                tbClientLog.AppendText("not connected...\n");
            }));
            sck.Close();
            sck.Dispose();
            Close();
        }
    }
}
