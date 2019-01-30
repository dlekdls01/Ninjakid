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
using System.Diagnostics;
using System.IO;

namespace project_ninjakid_server_03
{
    public partial class Form1 : Form
    {
        Listener listener;
        List<Client> clientList; // 클라이언트 목록
        int nClient = 0;

        Random rand = new Random();
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();

            int port = 2002; // 포트 넘버 (고정)
            // 멤버변수 생성
            listener = new Listener(port);
            clientList = new List<Client>();

            // 현재 폼에 이벤트핸들러 추가
            listener.SocketAccepted += new Listener.SocketAcceptedHandler(listener_SocketAccepted);
            Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string tcpServerIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            listener.Start(tcpServerIP);
        }

        private void listener_SocketAccepted(Socket e)
        {
            Client client = new Client(e);
            // 클라이언트 객체 connection 핸들러 추가
            client.Received += new Client.ClientReceivedHandler(client_Received);
            client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);

            Invoke((MethodInvoker)delegate
            {
                ListViewItem i = new ListViewItem();
                i.Text = (lstClient.Items.Count+1).ToString();
                i.SubItems.Add(client.GUID);
                i.SubItems.Add(" ");
                i.SubItems.Add(" ");
                i.SubItems.Add("None");
                i.SubItems.Add("None");
                i.Tag = client;
                lstClient.Items.Add(i);
            });
            nClient++;
            clientList.Add(client);
            client.Send(Encoding.UTF8.GetBytes("user:" + lstClient.Items.Count));
        }

        void client_Disconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < lstClient.Items.Count; i++)
                {
                    Client client = lstClient.Items[i].Tag as Client;

                    if (client.GUID == sender.GUID)
                    {
                        lstClient.Items.RemoveAt(i);
                        clientList.Remove(client);
                        nClient--;
                        if(nClient > 0)
                            clientList[0].Send(Encoding.UTF8.GetBytes("info:" + ""));
                        break;
                    }
                }
            });
        }

        void client_Received(Client sender, byte[] data)
        {
            string str = Encoding.UTF8.GetString(data);
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < lstClient.Items.Count; i++)
                {
                    Client client = lstClient.Items[i].Tag as Client;

                    if(client.GUID == sender.GUID)
                    {
                        if (str.StartsWith("info"))
                        {
                            int splitPoint = str.IndexOf(',');
                            lstClient.Items[i].SubItems[2].Text = str.Substring(5, splitPoint - 5);
                            lstClient.Items[i].SubItems[3].Text = str.Substring(splitPoint + 1, str.Length - splitPoint - 1);
                            if (nClient == 2)
                            {
                                clientList[0].Send(Encoding.UTF8.GetBytes("info:" + lstClient.Items[1].SubItems[2].Text));
                                clientList[1].Send(Encoding.UTF8.GetBytes("info:" + lstClient.Items[0].SubItems[2].Text));
                            }
                        }
                        else if(str.Substring(1, 4).Equals("turn"))
                        {
                            lstClient.Items[i].SubItems[4].Text = str;
                            foreach (Client c in clientList)
                                c.Send(Encoding.UTF8.GetBytes(str));
                            turnCount++;
                            if(turnCount == 4) // 아이템
                            {
                                int x = rand.Next(2, 7);
                                int y = rand.Next(2, 7);
                                Thread.Sleep(1000);
                                foreach (Client c in clientList)
                                    c.Send(Encoding.UTF8.GetBytes("item:" + x + "," + y));
                                
                                turnCount = 0;
                            }
                        }
                        else
                        {
                            lstClient.Items[i].SubItems[4].Text = str;
                            foreach (Client c in clientList)
                                c.Send(Encoding.UTF8.GetBytes(str));
                        }
                        lstClient.Items[i].SubItems[5].Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        return;
                    }
                }
            });
        }
    }
}
