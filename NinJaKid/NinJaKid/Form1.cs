using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace NinJaKid
{

    public partial class Form1 : Form
    {
        public string id;
        private string pw;
        public string idOther;

        bool canMove = false;
        bool canAttack = false;
        int canStart = 0;   //0:시작전 1:시작 2:게임중
        int moveRange = 1;
        int attackCount = 1;

        int[][] isDoor = new int[9][];  //0:창문있는거 1:창문깨진거
        int[][] isItem = new int[9][];  //0:아이템없는거 1:아이템있는거
        int[][] isUser = new int[9][];  //0:없는거 1:red있는거 2:blue있는거
        int[][] allseethrough = new int[9][];
        Button[][] door = new Button[9][];
        Button[] itemButton = new Button[10];
        int curX = 2, curY = 2;
        int turnTime = 30;  //공격+이동 10초
        int turnCount = 0;  //공격++, 이동++ ->2되면은 turnTime10
        Random rand = new Random();
        int attackItemCount = 3;
        int defenceItemCount = 0;
        int multiAttack = 0;
        bool doubleAttack = false;
        bool seethroughItem = false;
        bool allseethroughItem = false;
        int seethroughI;
        int seethroughJ;
        int seethroughTimer = 3;
        int[] itemNumber = new int[6];
        bool teleport = false;
        bool moreMove = false;
        int allseethroughTimer = 5;
        Image imgTimer;

        // Members for Network //
        Socket socket;
        Thread receiveThread;
        Form2 form2;

        // user / other //
        Image char_user, char_other;
        Image door1_user, door2_user, door3_user;
        Image door1_other, door2_other, door3_other;
        int userTurn=-1, otherTurn=-1, start_cnt=0;   //-1:턴종료 1:턴중 8:시작
        int userNum, otherNum;

        public Form1(Form2 _form2)
        {
            form2 = _form2;
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            imgTimer = pictureBox_timer.Image;
        }

        private void Receive()
        {
            while (socket.Connected)
            {
                byte[] buffer = new byte[1024 * 4];
                try
                {
                    int r = socket.Receive(buffer, 0);
                }
                catch
                {
                    socket = null;
                    return;
                }
                string str = Encoding.UTF8.GetString(buffer);
                string[] orders = str.Split('/');
                this.Invoke(new MethodInvoker(delegate ()
                {
                    foreach (string s in orders)
                        OrderParsing(s);
                }));
            }
        }

        private void OrderParsing(string str)
        {
            if (str.StartsWith("user"))
            {
                if (str.Substring(5, 1).Equals("1"))
                {
                    userNum = 1;
                    otherNum = 2;
                    label_1pID.Text = id;
                }
                else if (str.Substring(5, 1).Equals("2"))
                {
                    userNum = 2;
                    otherNum = 1;
                    label_2pID.Text = id;
                }
                else
                    textBox_chat1.AppendText(str);
            }
            else if (str.StartsWith("chat"))
            {
                textBox_chat1.AppendText(str.Substring(5, str.Length - 5) + "\n");
            }
            else if (str.StartsWith("info"))
            {
                idOther = str.Substring(5, str.Length - 5);
                if (userNum == 1)
                    label_2pID.Text = idOther;
                else if (userNum == 2)
                    label_1pID.Text = idOther;
                button_start.Enabled = true;
            }
            else if (str.StartsWith("item"))
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    label_log.Text = "아이템 생성중...";
                }));

                pictureBox_bird.Left = 706;
                timer_bird.Start();

                int splitPoint = str.IndexOf(',');
                int x = Int32.Parse(str.Substring(5, splitPoint - 5));
                int y = Int32.Parse(str.Substring(splitPoint + 1, str.Length - splitPoint - 1));

                if (isDoor[x][y] != 1)
                    isItem[x][y] = 1;
                else if (isDoor[x][y] == 1)
                {
                    if ((isUser[x][y] == 1) || (isUser[x][y] == 2)) // 
                    {
                        isItem[x][y] = 0;
                        ateItem(x, y);
                    }
                    else
                    {
                        door[x][y].BackgroundImage = Properties.Resources.item;
                        isItem[x][y] = 1;
                    }
                }
            }
            else if (str.StartsWith("eati"))
            {
                int splitPoint = str.IndexOf(',');
                int x = Int32.Parse(str.Substring(5, splitPoint - 5));
                int y = Int32.Parse(str.Substring(splitPoint + 1, str.Length - splitPoint - 1));

                if (isDoor[x][y] == 1)
                {
                    if ((isUser[x][y] == 1) || (isUser[x][y] == 2))
                        ;
                    else
                        door[x][y].BackgroundImage = null;
                }
                isItem[x][y] = 0;
            }

            else if (str.StartsWith("fini"))
            {
                reset();
            }
            else if (str.StartsWith("heal"))
            {
                //  socket.Send(Encoding.UTF8.GetBytes("heal:" + value.ToString() + "-" + "/"));
                if (str.Substring(5, 1).Equals("1"))
                {
                    if (str.Substring(6, 1).Equals("-"))
                        HPbar1.PerformStep();
                    else
                        HPbar1.Value += 20;

                    if (HPbar1.Value >= 50)
                    {
                        if(userNum ==1)
                            char_user = Properties.Resources.Red;
                        else if(userNum == 2)
                            char_other = Properties.Resources.Red;
                    }
                    else
                    {
                        if (userNum == 1)
                            char_user = Properties.Resources.Red2;
                        else if (userNum == 2)
                            char_other = Properties.Resources.Red2;
                    }

                    if (HPbar1.Value == 0)
                    {
                        MessageBox.Show("2P win !!!");
                        socket.Send(Encoding.UTF8.GetBytes("fini:"));
                    }
                }
                else
                {
                    if (str.Substring(6, 1).Equals("-"))
                        HPbar.PerformStep();
                    else
                        HPbar.Value += 20;

                    if (HPbar.Value >= 50)
                    {
                        if (userNum == 2)
                            char_user = Properties.Resources.blue;
                        else if (userNum == 1)
                            char_other = Properties.Resources.blue;
                    }
                    else
                    {
                        if (userNum == 2)
                            char_user = Properties.Resources.blue2;
                        else if (userNum == 1)
                            char_other = Properties.Resources.blue2;
                    }

                    if (HPbar.Value == 0)
                    {
                        MessageBox.Show("1P win !!!");
                        socket.Send(Encoding.UTF8.GetBytes("fini:"));
                    }

                }
            }
            else if (str.StartsWith(userNum.ToString()))
            {
                if (str.Substring(1, 4).Equals("turn"))
                {
                    int num = Int32.Parse(str.Substring(6, str.Length - 6));
                    if (num == 8)
                    {
                        start_cnt++;
                        if (start_cnt == 2)
                        {
                            label_log.Text = "";
                            timer1.Start();
                            button_attack.Enabled = true;
                            button_move.Enabled = true;
                            socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "turn:" + "1" + "/"));
                        }
                        else if (start_cnt == 1)
                            label_log.Text = "상대방이 시작버튼을 누를 때 까지 기다려 주세요.";
                    }
                }
                else
                {
                    ;
                }
            }
            else
            {
                if (str.Substring(1, 4).Equals("move"))
                {
                    int splitPoint = str.IndexOf(',');
                    int x = Int32.Parse(str.Substring(6, splitPoint - 6));
                    int y = Int32.Parse(str.Substring(splitPoint + 1, str.Length - splitPoint - 1));

                    for (int i = 2; i < 7; i++)
                    {
                        for (int j = 2; j < 7; j++)
                        {
                            if (isUser[i][j] == otherNum)
                            {
                                isUser[i][j] = 0;
                                if (isDoor[i][j] != 1)
                                {
                                    if (i == 2)
                                        door[i][j].BackgroundImage = Properties.Resources.door1;
                                    else if (i == 3 || i == 4)
                                        door[i][j].BackgroundImage = Properties.Resources.door2;
                                    else
                                        door[i][j].BackgroundImage = Properties.Resources.door3;
                                }
                                else if (isDoor[i][j] == 1)
                                    door[i][j].BackgroundImage = null;
                            }
                        }
                    }
                    isUser[x][y] = otherNum;
                    if (isDoor[x][y] == 1)
                        door[x][y].BackgroundImage = char_other;

                }
                else if (str.Substring(1, 4).Equals("attc"))
                {
                    int splitPoint = str.IndexOf(',');
                    int x = Int32.Parse(str.Substring(6, splitPoint - 6));
                    int y = Int32.Parse(str.Substring(splitPoint + 1, str.Length - splitPoint - 1));

                    isDoor[x][y] = 1;
                    if (isUser[x][y] == userNum)
                        door[x][y].BackgroundImage = char_user;
                    else if (isUser[x][y] == otherNum)
                        door[x][y].BackgroundImage = char_other;
                    else
                    {
                        if (isItem[x][y] == 1)
                            door[x][y].BackgroundImage = Properties.Resources.item;
                        else
                            door[x][y].BackgroundImage = null;
                    }

                }
                // socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "turn:" + "8")); // ***
                else if (str.Substring(1, 4).Equals("turn"))  // 상대방 턴 상대  num:8 시작  num:1 턴시작 num:-1 턴종료
                {

                    int num = Int32.Parse(str.Substring(6, str.Length - 6));
                    if (num == 8)
                    {
                        start_cnt++;
                        if (start_cnt == 2)
                        {
                            canStart = 2;
                            timer1.Start();
                            button_attack.Enabled = true;
                            button_move.Enabled = true;
                        }
                    }
                    else if (num == 1)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            label_log.Text = "상대방이 선택 중입니다...";
                        }));
                        button_attack.Enabled = false;
                        button_move.Enabled = false;
                        timer1.Stop();
                        label_timer.Text = "0";


                    }
                    else if (num == -1)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            label_log.Text = "";
                        }));
                        turnTime = 30;
                        turnCount = 0;
                        button_move.Text = "이동";
                        canMove = false;
                        button_attack.Text = "공격";
                        canAttack = false;
                        button_move.Enabled = true;
                        button_attack.Enabled = true;
                        timer1.Start();

                        socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "turn:" + "1" + "/"));  //자신시작을알림
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostByName(Dns.GetHostName());
            string ServerIP = ipHost.AddressList[0].ToString(); // IP (고정)
            int Port = 2002; // 포트 넘버 (고정)

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ServerIP), Port);
            try
            {
                // 소켓 연결
                socket.Connect(remoteEP);

                // ID/PW 전송
                //id = "test";
                pw = "pw";
                socket.Send(Encoding.UTF8.GetBytes("info:" + id + "," + pw + "/"));
                this.Invoke(new MethodInvoker(delegate ()
                {
                    //MessageBox.Show("connected\n");
                }));
            }
            catch
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    MessageBox.Show("connection failed\n");
                }));
                if (socket != null)
                    socket.Close();
                this.Close();
                return;
            }
            // 정보 받기 thread 생성/시작
            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.Start();

            // --------------------------------------- //

            for (int i = 0; i < 9; i++)
            {
                allseethrough[i] = new int[9];
                door[i] = new Button[9];
                isDoor[i] = new int[9];
                isItem[i] = new int[9];
                isUser[i] = new int[9];
            }

            door[2][2] = door0;
            door[2][3] = door1;
            door[2][4] = door2;
            door[2][5] = door3;
            door[2][6] = door4;
            door[3][2] = door5;
            door[3][3] = door6;
            door[3][4] = door7;
            door[3][5] = door8;
            door[3][6] = door9;
            door[4][2] = door10;
            door[4][3] = door11;
            door[4][4] = door12;
            door[4][5] = door13;
            door[4][6] = door14;
            door[5][2] = door15;
            door[5][3] = door16;
            door[5][4] = door17;
            door[5][5] = door18;
            door[5][6] = door19;
            door[6][2] = door20;
            door[6][3] = door21;
            door[6][4] = door22;
            door[6][5] = door23;
            door[6][6] = door24;

            itemButton[0] = item1;
            itemButton[1] = item2;
            itemButton[2] = item3;
            itemButton[3] = item4;
            itemButton[4] = item5;
            itemButton[5] = item6;
            itemButton[6] = item7;
            itemButton[7] = item8;
            itemButton[8] = item9;
            

            button_attack.Font = new Font(button_attack.Font, FontStyle.Bold);
            button_move.Font = new Font(button_move.Font, FontStyle.Bold);
            button_start.Font = new Font(button_start.Font, FontStyle.Bold);
            button_start.ForeColor = Color.Red;
            button_도움말.Font = new Font(button_도움말.Font, FontStyle.Bold);

            timer1.Stop();

            Invoke(new MethodInvoker(delegate ()
            {
                label_log.Text = "닌자키드 게임에 오신 걸 환영합니다!";
            }));
        }

        private void door_Click(object sender, EventArgs e)
        {
            int sendLength = 0; // **
            /////////////////////////////////////처음선택///////////////////////
            int i = 1, j = 1;
            if (canStart == 1)
            {
                for (i = 2; i < 7; i++)
                {
                    for (j = 2; j < 7; j++)
                    {
                        if (door[i][j] == sender)
                        {
                            curX = i;
                            curY = j;
                            if (i == 2)
                                door[i][j].BackgroundImage = door1_user;
                            else if (i == 3 || i == 4)
                                door[i][j].BackgroundImage = door2_user;
                            else if (i == 5 || i == 6)
                                door[i][j].BackgroundImage = door3_user;
                            isUser[curX][curY] = userNum;
                            canStart = 2;

                            sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "turn:" + "8" + "/")); // ***
                            Thread.Sleep(1);
                            sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "move:" + i + "," + j + "/")); // ***
                            return;
                        }
                    }
                }
            }
            //////////////////////////////////////////////////////////////////// 더블공격 /////////////////
            if (multiAttack > 0 || doubleAttack == true)
            {
                for (i = 2; i < 7; i++)
                {
                    for (j = 2; j < 7; j++)
                    {
                        if (door[i][j] == sender)
                        {
                            if (isDoor[i][j] != 1 && isUser[i][j] == userNum) //창문있고 유저존재
                            {
                                door[i][j].BackgroundImage = char_user;
                                attacked(userNum);
                                if (doubleAttack == true)
                                {
                                    attacked(userNum);
                                    attacked(userNum);
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                }
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                isDoor[i][j] = 1;
                            }
                            else if (isDoor[i][j] != 1 && isUser[i][j] == otherNum)
                            {
                                door[i][j].BackgroundImage = char_other;
                                attacked(otherNum);
                                if (doubleAttack == true)
                                {
                                    attacked(otherNum);
                                    attacked(otherNum);
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                }
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                isDoor[i][j] = 1;
                            }
                            else if (isDoor[i][j] != 1 && isUser[i][j] != otherNum && isUser[i][j] != userNum)
                            {
                                door[i][j].BackgroundImage = null;
                                if (doubleAttack == true)
                                {
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                }
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                isDoor[i][j] = 1;
                            }


                            else if (isDoor[i][j] == 1 && isItem[i][j] != 1) //문이깨져있고 아이템이없을때
                            {
                                if (isUser[i][j] == userNum)        //문이깨져있고 아이템이 없고 자신이있을때자신에게공격
                                {
                                    if (doubleAttack == true)
                                    {
                                        attacked(userNum); //문이깨져있고 유저가 있을 때 공격당함
                                        attacked(userNum);
                                        sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/"));
                                        Thread.Sleep(1);
                                        sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/"));
                                        break;
                                    }
                                    else if (doubleAttack != true)
                                    {
                                        attacked(userNum);
                                        sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/"));
                                        if (!(multiAttack > 0))
                                            break;
                                    }
                                }
                                else if (isUser[i][j] == otherNum)
                                {
                                    if (doubleAttack == true)
                                    {
                                        attacked(otherNum); //문이깨져있고 유저가 있을 때 공격당함
                                        attacked(otherNum);
                                        sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/"));
                                        Thread.Sleep(1);
                                        sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/"));
                                        break;
                                    }
                                    else if (doubleAttack != true)
                                    {
                                        attacked(otherNum);
                                        sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/"));
                                        if (!(multiAttack > 0))
                                            break;
                                    }
                                    //else
                                    //    return;
                                }
                            }
                            else if (isDoor[i][j] == 1 && isItem[i][j] == 1)     //문이깨져있고 아이템이있을때
                            {
                                door[i][j].BackgroundImage = null;
                                isItem[i][j] = 0;
                                ateItem(i, j);
                                isDoor[i][j] = 1;
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }
                            else if (isDoor[i][j] != 1 && isItem[i][j] == 1)     //문이있고 아이템이있을때
                            {
                                door[i][j].BackgroundImage = Properties.Resources.item;
                                isDoor[i][j] = 1;
                                if (doubleAttack == true)
                                {
                                    door[i][j].BackgroundImage = null;
                                    isItem[i][j] = 0;
                                    ateItem(i, j);
                                }
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }
                            else if (isDoor[i][j] != 1 && isItem[i][j] != 1)    //문이있고 아이템이 없을때
                            {
                                door[i][j].BackgroundImage = null;
                                isDoor[i][j] = 1;
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }
                        }
                    }
                }
                doubleAttack = false;
                --multiAttack;
            }


            if (seethroughItem == true)
            {
                for (i = 2; i < 7; i++)
                {
                    for (j = 2; j < 7; j++)
                    {
                        if (door[i][j] == sender)
                        {
                            seethroughI = i;
                            seethroughJ = j;
                            timer_seethrough.Start();
                        }
                    }
                }
                seethroughItem = false;
            }
            /////////////////////////////////////공격///////////////////////////
            if (canAttack == true)
            {
                for (i = 2; i < 7; i++)
                {
                    for (j = 2; j < 7; j++)
                    {
                        if (door[i][j] == sender)
                        {
                            if (isDoor[i][j] != 1 && isUser[i][j] == userNum)       //문이있고자신이있을때
                            {
                                door[i][j].BackgroundImage = char_user;
                                attacked(userNum);
                                isDoor[i][j] = 1;
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }
                            else if (isDoor[i][j] != 1 && isUser[i][j] == otherNum)  //문이있고상대가있을때
                            {
                                door[i][j].BackgroundImage = char_other;
                                attacked(otherNum);
                                isDoor[i][j] = 1;
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }

                            else if (isDoor[i][j] == 1 && isItem[i][j] != 1) //문이깨져있고 아이템이없을때
                            {
                                if (isUser[i][j] == userNum)        //문이깨져있고 아이템이 없고 자신이있을때자신에게공격
                                {
                                    attacked(userNum);
                                    isDoor[i][j] = 1;
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                    break;
                                }
                                else if (isUser[i][j] == otherNum)   //문이깨져있고 아이템이 없고 상대가있을때공격
                                {
                                    attacked(otherNum);
                                    isDoor[i][j] = 1;
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (isDoor[i][j] == 1 && isItem[i][j] == 1)     //문이깨져있고 아이템이있을때
                            {
                                door[i][j].BackgroundImage = null;
                                isItem[i][j] = 0;
                                ateItem(i, j);
                                isDoor[i][j] = 1;
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }
                            else if (isDoor[i][j] != 1 && isItem[i][j] == 1)     //문이있고 아이템이있을때
                            {
                                door[i][j].BackgroundImage = Properties.Resources.item;
                                isDoor[i][j] = 1;
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }
                            else if (isDoor[i][j] != 1 && isItem[i][j] != 1)    //문이있고 아이템이 없을때
                            {
                                door[i][j].BackgroundImage = null;
                                isDoor[i][j] = 1;
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "attc:" + i + "," + j + "/")); // ***
                                break;
                            }

                        }
                    }
                }
                canAttack = false;
                button_attack.Text = "공격";
                button_attack.Enabled = false;
                turnChange();
            }

            ///////////////////////////////////이동///////////////////////////
            if (teleport == true)
            {
                for (i = 2; i < 7; i++)
                {
                    for (j = 2; j < 7; j++)
                    {
                        if (door[i][j] == sender)
                        {
                            if (isDoor[i][j] != 1)                                  //이동할door
                            {
                                if (i == 2)
                                    door[i][j].BackgroundImage = door1_user;
                                else if (i == 3 || i == 4)
                                    door[i][j].BackgroundImage = door2_user;
                                else if (i == 5 || i == 6)
                                    door[i][j].BackgroundImage = door3_user;

                                if (isItem[i][j] == 1)
                                {
                                    isItem[i][j] = 0;
                                    ateItem(i, j);
                                }
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "move:" + i + "," + j + "/")); // ***
                            }
                            else if (isDoor[i][j] == 1)
                            {
                                door[i][j].BackgroundImage = char_user;
                                if (isItem[i][j] == 1)
                                {
                                    isItem[i][j] = 0;
                                    ateItem(i, j);
                                }
                                sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "move:" + i + "," + j + "/")); // ***
                            }

                            if (isDoor[curX][curY] != 1)                         //현재의door
                            {
                                if (curX == 2)
                                    door[curX][curY].BackgroundImage = Properties.Resources.door1;
                                else if (curX == 3 || curX == 4)
                                    door[curX][curY].BackgroundImage = Properties.Resources.door2;
                                else if (curX == 5 || curX == 6)
                                    door[curX][curY].BackgroundImage = Properties.Resources.door3;
                            }
                            else if (isDoor[curX][curY] == 1)
                            {
                                door[curX][curY].BackgroundImage = null;
                            }

                            isUser[i][j] = userNum;
                            isUser[curX][curY] = 0;
                            curX = i;
                            curY = j;
                        }
                    }
                }
                teleport = false;
            }

            if (moreMove == true)
            {
                moveRange = 2;
                if ((sender == door[curX + moveRange][curY]) || (sender == door[curX - moveRange][curY])
                   || (sender == door[curX][curY + moveRange]) || (sender == door[curX][curY - moveRange])
                   || (sender == door[curX + moveRange][curY + moveRange]) || (sender == door[curX + moveRange][curY - moveRange])
                   || (sender == door[curX - moveRange][curY + moveRange]) || (sender == door[curX - moveRange][curY - moveRange])

                   || (sender == door[curX + moveRange - 1][curY]) || (sender == door[curX - moveRange + 1][curY])
                   || (sender == door[curX][curY + moveRange - 1]) || (sender == door[curX][curY - moveRange + 1])
                   || (sender == door[curX + moveRange - 1][curY + moveRange - 1]) || (sender == door[curX + moveRange - 1][curY - moveRange + 1])
                   || (sender == door[curX - moveRange + 1][curY + moveRange - 1]) || (sender == door[curX - moveRange + 1][curY - moveRange + 1])

                   || (sender == door[curX + moveRange - 1][curY + moveRange]) || (sender == door[curX + moveRange - 1][curY - moveRange])
                   || (sender == door[curX - moveRange + 1][curY + moveRange]) || (sender == door[curX - moveRange + 1][curY - moveRange])
                   || (sender == door[curX + moveRange][curY + moveRange - 1]) || (sender == door[curX + moveRange][curY - moveRange + 1])
                   || (sender == door[curX - moveRange][curY + moveRange - 1]) || (sender == door[curX - moveRange][curY - moveRange + 1])
                   )
                {
                    for (i = 2; i < 7; i++)
                    {
                        for (j = 2; j < 7; j++)
                        {
                            if (door[i][j] == sender)
                            {
                                if (isDoor[i][j] != 1)                                  //이동할door
                                {
                                    if (i == 2)
                                        door[i][j].BackgroundImage = door1_user;
                                    else if (i == 3 || i == 4)
                                        door[i][j].BackgroundImage = door2_user;
                                    else if (i == 5 || i == 6)
                                        door[i][j].BackgroundImage = door3_user;

                                    if (isItem[i][j] == 1)
                                    {
                                        isItem[i][j] = 0;
                                        ateItem(i, j);
                                    }
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "move:" + i + "," + j + "/")); // ***

                                }
                                else if (isDoor[i][j] == 1)
                                {
                                    door[i][j].BackgroundImage = char_user;
                                    if (isItem[i][j] == 1)
                                    {
                                        isItem[i][j] = 0;
                                        ateItem(i, j);
                                    }
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "move:" + i + "," + j + "/")); // ***
                                }

                                if (isDoor[curX][curY] != 1)                         //현재의door
                                {
                                    if (curX == 2)
                                        door[curX][curY].BackgroundImage = Properties.Resources.door1;
                                    else if (curX == 3 || curX == 4)
                                        door[curX][curY].BackgroundImage = Properties.Resources.door2;
                                    else if (curX == 5 || curX == 6)
                                        door[curX][curY].BackgroundImage = Properties.Resources.door3;
                                }
                                else if (isDoor[curX][curY] == 1)
                                {
                                    door[curX][curY].BackgroundImage = null;
                                }

                                isUser[i][j] = userNum;
                                isUser[curX][curY] = 0;
                                curX = i;
                                curY = j;
                            }
                        }
                    }
                    //canMoveEnd();
                    moveRange = 1;
                    moreMove = false;
                }
            }
            if (canMove == true)
            {
                if ((sender == door[curX + moveRange][curY]) || (sender == door[curX - moveRange][curY])
                    || (sender == door[curX][curY + moveRange]) || (sender == door[curX][curY - moveRange])
                    || (sender == door[curX + moveRange][curY + moveRange]) || (sender == door[curX + moveRange][curY - moveRange])
                    || (sender == door[curX - moveRange][curY + moveRange]) || (sender == door[curX - moveRange][curY - moveRange]))
                {
                    for (i = 2; i < 7; i++)
                    {
                        for (j = 2; j < 7; j++)
                        {
                            if (door[i][j] == sender)
                            {
                                if (isDoor[i][j] != 1)                                  //이동할door
                                {
                                    if (i == 2)
                                        door[i][j].BackgroundImage = door1_user;
                                    else if (i == 3 || i == 4)
                                        door[i][j].BackgroundImage = door2_user;
                                    else if (i == 5 || i == 6)
                                        door[i][j].BackgroundImage = door3_user;

                                    if (isItem[i][j] == 1)
                                    {
                                        isItem[i][j] = 0;
                                        ateItem(i, j);
                                    }
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "move:" + i + "," + j + "/")); // ***

                                }
                                else if (isDoor[i][j] == 1)
                                {
                                    door[i][j].BackgroundImage = char_user;
                                    if (isItem[i][j] == 1)
                                    {
                                        isItem[i][j] = 0;
                                        ateItem(i, j);
                                    }
                                    sendLength = socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "move:" + i + "," + j + "/")); // ***
                                }

                                if (isDoor[curX][curY] != 1)                         //현재의door
                                {
                                    if (curX == 2)
                                        door[curX][curY].BackgroundImage = Properties.Resources.door1;
                                    else if (curX == 3 || curX == 4)
                                        door[curX][curY].BackgroundImage = Properties.Resources.door2;
                                    else if (curX == 5 || curX == 6)
                                        door[curX][curY].BackgroundImage = Properties.Resources.door3;
                                }
                                else if (isDoor[curX][curY] == 1)
                                {
                                    door[curX][curY].BackgroundImage = null;
                                }

                                isUser[i][j] = userNum;
                                isUser[curX][curY] = 0;
                                curX = i;
                                curY = j;
                            }
                        }
                    }
                    //canMoveEnd();
                    canMove = false;
                    button_move.Text = "이동";
                    button_move.Enabled = false;
                    turnChange();
                }
                //else
                //{
                //    return;
                //}     
            }
        }

        private void door0_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sender == door[i][j])
                    {
                        if ((canMove == true) && (moreMove == false))
                        {
                            if ((sender == door[curX + moveRange][curY]) || (sender == door[curX - moveRange][curY])
                            || (sender == door[curX][curY + moveRange]) || (sender == door[curX][curY - moveRange])
                            || (sender == door[curX + moveRange][curY + moveRange]) || (sender == door[curX + moveRange][curY - moveRange])
                            || (sender == door[curX - moveRange][curY + moveRange]) || (sender == door[curX - moveRange][curY - moveRange]))
                            {
                                door[i][j].ForeColor = Color.Yellow;
                                door[i][j].Text = "👟";
                            }
                        }
                        else if (teleport == true)
                        {
                            door[i][j].ForeColor = Color.Yellow;
                            door[i][j].Text = "👟";
                        }
                        else if (moreMove == true)
                        {
                            moveRange = 2;
                            if ((sender == door[curX + moveRange][curY]) || (sender == door[curX - moveRange][curY])
               || (sender == door[curX][curY + moveRange]) || (sender == door[curX][curY - moveRange])
               || (sender == door[curX + moveRange][curY + moveRange]) || (sender == door[curX + moveRange][curY - moveRange])
               || (sender == door[curX - moveRange][curY + moveRange]) || (sender == door[curX - moveRange][curY - moveRange])

               || (sender == door[curX + moveRange - 1][curY]) || (sender == door[curX - moveRange + 1][curY])
               || (sender == door[curX][curY + moveRange - 1]) || (sender == door[curX][curY - moveRange + 1])
               || (sender == door[curX + moveRange - 1][curY + moveRange - 1]) || (sender == door[curX + moveRange - 1][curY - moveRange + 1])
               || (sender == door[curX - moveRange + 1][curY + moveRange - 1]) || (sender == door[curX - moveRange + 1][curY - moveRange + 1])

               || (sender == door[curX + moveRange - 1][curY + moveRange]) || (sender == door[curX + moveRange - 1][curY - moveRange])
               || (sender == door[curX - moveRange + 1][curY + moveRange]) || (sender == door[curX - moveRange + 1][curY - moveRange])
               || (sender == door[curX + moveRange][curY + moveRange - 1]) || (sender == door[curX + moveRange][curY - moveRange + 1])
               || (sender == door[curX - moveRange][curY + moveRange - 1]) || (sender == door[curX - moveRange][curY - moveRange + 1])
               )
                            {
                                door[i][j].ForeColor = Color.Yellow;
                                door[i][j].Text = "👟";

                            }
                        }
                        else if (canAttack == true || doubleAttack == true || multiAttack > 0)
                        {
                            if (isDoor[i][j] != 1)
                            {
                                door[i][j].ForeColor = Color.Red;
                                door[i][j].Text = "🔪";
                            }
                        }
                    }
                }
            }

        }

        private void door0_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sender == door[i][j])
                    {
                        door[i][j].Text = null;
                    }
                }
            }
        }

        private void canMoveEnd()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    door[i][j].Text = null;
                }
            }

        }
        private void ateItem(int i, int j)
        {
            //itemButton[3].BackgroundImage = Properties.Resources.seethrough;
            //itemButton[3].Enabled = true;
            //itemNumber[3] = 100 * 3 + 2;

            int ItemType = rand.Next(0, 20); //item종류 설정
            if ((attackItemCount < 6) || (defenceItemCount < 3))
            { //item 더 먹을 수 있는지 판단
                switch (ItemType)
                {
                    case 0:
                    case 1:
                    case 2: //연속두번공격
                    case 3:
                        if (attackItemCount < 6)
                        {
                            for (int e = 3; e < 6; e++)
                            {
                                if (itemButton[e].BackgroundImage == null)
                                {
                                    itemButton[e].BackgroundImage = Properties.Resources.doubleAttack;
                                    itemButton[e].Enabled = true;
                                    itemNumber[e] = 100 * e + 1;
                                    break;
                                }
                            }
                            attackItemCount++;
                            break;

                        }//item추가, 공격아이템 꽉 차있으면 방어아이템으로 다시 먹음
                        else
                        {
                            ateItem(i,j);
                            break;
                        }
                    case 4:  //텔포
                        if (defenceItemCount < 3)
                        {
                            for (int e = 0; e < 3; e++)
                            {
                                if (itemButton[e].BackgroundImage == null)
                                {
                                    itemButton[e].BackgroundImage = Properties.Resources.teleport;
                                    itemButton[e].Enabled = true;
                                    itemNumber[e] = 100 * e + 8;
                                    break;
                                }
                            }
                            defenceItemCount++;
                            break;
                        }//item추가, 방어아이템 꽉 차있으면 다시 먹음
                        else
                        {
                            ateItem(i,j);
                            break;
                        }
                    //case 6:
                    //case 7:
                    //case 8: //감옥
                    //    if (attackItemCount < 6)
                    //    {
                    //        for (int e = 3; e < 6; e++)
                    //        {
                    //            if (itemButton[e].BackgroundImage == null)
                    //            {
                    //                itemButton[e].BackgroundImage = Properties.Resources.hold;
                    //                itemButton[e].Enabled = true;
                    //                itemNumber[e] = 100 * e + 9;                                 
                    //                break;
                    //            }
                    //        }
                    //        attackItemCount++;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        ateItem(i,j);
                    //        break;
                    //    }
                    case 5:
                    case 6:
                    case 7:  //투시
                        if (attackItemCount < 6)
                        {
                            for (int e = 3; e < 6; e++)
                            {
                                if (itemButton[e].BackgroundImage == null)
                                {
                                    itemButton[e].BackgroundImage = Properties.Resources.seethrough;
                                    itemButton[e].Enabled = true;
                                    itemNumber[e] = 100 * e + 3;
                                    break;
                                }
                            }
                            attackItemCount++;
                            break;
                        }
                        else
                        {
                            ateItem(i,j);
                            break;
                        }
                    case 8:
                    case 9:
                    case 10:    //이동범위 증가
                        if (defenceItemCount < 3)
                        {
                            for (int e = 0; e < 3; e++)
                            {
                                if (itemButton[e].BackgroundImage == null)
                                {
                                    itemButton[e].BackgroundImage = Properties.Resources.moremove;
                                    itemButton[e].Enabled = true;
                                    itemNumber[e] = 100 * e + 5;
                                    break;
                                }
                            }
                            defenceItemCount++;
                            break;
                        }
                        else
                        {
                            ateItem(i,j);
                            break;
                        }
                    case 11:    //모든투시
                        if (attackItemCount < 6)
                        {
                            for (int e = 3; e < 6; e++)
                            {
                                if (itemButton[e].BackgroundImage == null)
                                {
                                    itemButton[e].BackgroundImage = Properties.Resources.allseethrough;
                                    itemButton[e].Enabled = true;
                                    itemNumber[e] = 100 * e + 6;

                                    break;
                                }
                            }
                            attackItemCount++;
                            break;
                        }
                        else
                        {
                            ateItem(i,j);
                            break;
                        }
                    case 12:
                    case 13:
                    case 14:
                    case 15:    //다중공격
                        if (attackItemCount < 6)
                        {
                            for (int e = 3; e < 6; e++)
                            {
                                if (itemButton[e].BackgroundImage == null)
                                {
                                    itemButton[e].BackgroundImage = Properties.Resources.multiattack;
                                    itemButton[e].Enabled = true;
                                    itemNumber[e] = 100 * e + 2;
                                    break;
                                }
                            }
                            attackItemCount++;
                            break;
                        }
                        else
                        {
                            ateItem(i,j);
                            break;
                        }
                    case 16:
                    case 17:
                    case 18:
                    case 19:    //에너지드링크
                        if (defenceItemCount < 3)
                        {
                            for (int e = 0; e < 3; e++)
                            {
                                if (itemButton[e].BackgroundImage == null)
                                {
                                    itemButton[e].BackgroundImage = Properties.Resources.engergy;
                                    itemButton[e].Enabled = true;
                                    itemNumber[e] = 100 * e + 4;
                                    break;
                                }
                            }
                            defenceItemCount++;
                            break;
                        }
                        else
                        {
                            ateItem(i,j);
                            break;
                        }
                }
            }

            else
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    label_log.Text = "더 이상 아이템을 먹을 수 없습니다.";
                }));
            }
            socket.Send(Encoding.UTF8.GetBytes("eati:" + i + "," + j + "/")); // ***
        }

        private void button_attack_Click(object sender, EventArgs e)
        {
            if ((canMove == true) || (canStart == 0))
                return;
            if (button_attack.Text == "공격")
            {
                button_attack.Text = "Skip";
                canAttack = true;
                Invoke(new MethodInvoker(delegate ()
                {
                    label_log.Text = "공격할 곳을 선택해주십시오.";
                }));

            }
            else if (button_attack.Text == "Skip")
            {
                button_attack.Text = "공격";
                canAttack = false;
                button_attack.Enabled = false;
                turnChange();
                Invoke(new MethodInvoker(delegate ()
                {
                    label_log.Text = "공격을 하지 않았습니다.";
                }));
            }
        }

        private void button_move_Click(object sender, EventArgs e)
        {
            if ((canAttack == true) || (canStart == 0))
                return;
            if (button_move.Text == "이동")
            {
                button_move.Text = "Skip";
                canMove = true;
                Invoke(new MethodInvoker(delegate ()
                {
                    label_log.Text = "이동할 곳을 선택해주십시오.";
                }));
            }
            else if (button_move.Text == "Skip")
            {
                button_move.Text = "이동";
                canMove = false;
                button_move.Enabled = false;
                turnChange();
                Invoke(new MethodInvoker(delegate ()
                {
                    label_log.Text = "이동을 하지 않았습니다.";
                }));
            }
        }
        

        private void button_start_Click(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                label_log.Text = "시작 위치를 선택해주십시오.";
            }));
            canStart = 1;
            button_start.Enabled = false;

            if (userNum == 1)
            {
                char_user = Properties.Resources.Red;
                door1_user = Properties.Resources.door1_Red;
                door2_user = Properties.Resources.door2_Red;
                door3_user = Properties.Resources.door3_Red;

                char_other = Properties.Resources.blue;
                door1_other = Properties.Resources.door1_blue;
                door2_other = Properties.Resources.door2_blue;
                door3_other = Properties.Resources.door3_blue;
                otherNum = 2;
            }
            else if (userNum == 2)
            {
                char_user = Properties.Resources.blue;
                door1_user = Properties.Resources.door1_blue;
                door2_user = Properties.Resources.door2_blue;
                door3_user = Properties.Resources.door3_blue;

                char_other = Properties.Resources.Red;
                door1_other = Properties.Resources.door1_Red;
                door2_other = Properties.Resources.door2_Red;
                door3_other = Properties.Resources.door3_Red;
                otherNum = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (turnTime > 0)
                turnTime--;
            else
            {
                /*
                turnTime = 11;
                button_move.Text = "이동";
                canMove = false;
                button_attack.Text = "공격";
                canAttack = false;
                button_move.Enabled = true;
                button_attack.Enabled = true;
                */
                turnCount = attackCount ;
                turnChange();
            }
            pictureBox_timer.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox_timer.Image = imgTimer;
            label_timer.Text = turnTime.ToString();
        }

        private void timer_bird_Tick(object sender, EventArgs e)
        {
            pictureBox_bird.Visible = true;
            int x = pictureBox_bird.Left - 3;
            int y = pictureBox_bird.Top;
            int width = pictureBox_bird.Width;
            int height = pictureBox_bird.Height;
            x -= 30;
            pictureBox_bird.SetBounds(x, y, width, height);
        }

        private void button_도움말_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void turnChange()
        {
            turnCount++;
            if (turnCount == (attackCount + 1))
            {/*
                timer1.Stop();
                turnTime = 11;
                turnCount = 0;
                button_move.Enabled = true;
                button_attack.Enabled = true;
                timer1.Start();
                */
                socket.Send(Encoding.UTF8.GetBytes(userNum.ToString() + "turn:" + "-1" + "/"));
            }
        }

        private void button_종료_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Close();
        }
        

        private void attacked(int value)  //usernum or othernum
        {
            socket.Send(Encoding.UTF8.GetBytes("heal:" + value.ToString() + "-" + "/"));
        }

        private void timer_seethrough_Tick(object sender, EventArgs e)
        {
            if (seethroughTimer > 0)
            {
                seethroughTimer--;
                if (isDoor[seethroughI][seethroughJ] == 1)
                    return;
                else if (isDoor[seethroughI][seethroughJ] != 1 && isUser[seethroughI][seethroughJ] == userNum)//창문있고 1p있음
                {
                    door[seethroughI][seethroughJ].BackgroundImage = char_user;
                }
                else if (isDoor[seethroughI][seethroughJ] != 1 && isUser[seethroughI][seethroughJ] == otherNum)//창문있고 2p있음
                {
                    door[seethroughI][seethroughJ].BackgroundImage = char_other;
                }
                else if (isDoor[seethroughI][seethroughJ] != 1 && isItem[seethroughI][seethroughJ] != 1)//창문있고 아이템없음
                {
                    door[seethroughI][seethroughJ].BackgroundImage = null;
                }
                else if (isDoor[seethroughI][seethroughJ] != 1 && isItem[seethroughI][seethroughJ] == 1)//창문있고 아이템있음
                {
                    door[seethroughI][seethroughJ].BackgroundImage = Properties.Resources.item;
                }

            }

            else
            {
                if (isDoor[seethroughI][seethroughJ] == 0)//무슨경우든 창문이있었으면 
                {
                    if (seethroughI == 2)
                    {
                        door[seethroughI][seethroughJ].BackgroundImage = Properties.Resources.door1;
                    }
                    else if (seethroughI == 3 || seethroughI == 4)
                    {
                        door[seethroughI][seethroughJ].BackgroundImage = Properties.Resources.door2;
                    }
                    else if (seethroughI == 5 || seethroughI == 6)
                    {
                        door[seethroughI][seethroughJ].BackgroundImage = Properties.Resources.door3;
                    }
                }

                //else if (isUser[seethroughI][seethroughJ] == userNum && isDoor[seethroughI][seethroughJ] == 0)//1p있고 창문있을때
                //{
                //    if (seethroughI == 1)
                //    {
                //        door[seethroughI][seethroughJ].BackgroundImage =char_user;
                //    }
                //    else if (seethroughI == 2 || seethroughI == 3)
                //    {
                //        door[seethroughI][seethroughJ].BackgroundImage = char_user;
                //    }
                //    else
                //    {
                //        door[seethroughI][seethroughJ].BackgroundImage = char_user;
                //    }
                //}
                //else if (isUser[seethroughI][seethroughJ] == otherNum && isDoor[seethroughI][seethroughJ] == 0)//2p있고 창문있을때
                //{
                //    if (seethroughI == 1)
                //    {
                //        door[seethroughI][seethroughJ].BackgroundImage =char_other;
                //    }
                //    else if (seethroughI == 2 || seethroughI == 3)
                //    {
                //        door[seethroughI][seethroughJ].BackgroundImage = char_other;
                //    }
                //    else
                //    {
                //        door[seethroughI][seethroughJ].BackgroundImage = char_user;
                //    }
                //}
                timer_seethrough.Stop();
                seethroughItem = false;
                seethroughTimer = 2;
            }

        }

        private void timer_allseethrough_Tick(object sender, EventArgs e)
        {
            if (allseethroughTimer > 0)
            {
                for (int i = 2; i < 7; i++)
                {
                    for (int j = 2; j < 7; j++)
                    {
                        if (isDoor[i][j] == 0)//문이 있고
                        {
                            if (isUser[i][j] == userNum || isUser[i][j] == otherNum)//유저 존재
                            {
                                if (isUser[i][j] == userNum)
                                {
                                    door[i][j].BackgroundImage = char_user;
                                    allseethrough[i][j] = 0;
                                }
                                else
                                {
                                    door[i][j].BackgroundImage = char_other;
                                    allseethrough[i][j] = 1;
                                }

                            }
                            else if ((isUser[i][j] == 0) && (isItem[i][j] == 0))    //유저x + 아이템x
                            {
                                door[i][j].BackgroundImage = null;
                                allseethrough[i][j] = 5;
                            }
                            else if (isItem[i][j] == 1)//아이템이있을때
                            {
                                door[i][j].BackgroundImage = Properties.Resources.item;
                                allseethrough[i][j] = 3;
                            }
                            else if (isItem[i][j] != 1)//아이템이 없을때
                            {
                                door[i][j].BackgroundImage = null;
                                allseethrough[i][j] = 4;
                            }
                        }

                        else if (isDoor[i][j] == 1) //문이깨져있을때
                        {
                            if (isUser[i][j] == userNum || isUser[i][j] == otherNum)//유저 존재
                            {
                                if (isUser[i][j] == userNum)
                                {
                                    door[i][j].BackgroundImage = char_user;
                                    allseethrough[i][j] = 8;
                                }
                                else
                                {
                                    door[i][j].BackgroundImage = char_other;
                                    allseethrough[i][j] = 9;
                                }

                            }
                            else if ((isUser[i][j] == 0) && (isItem[i][j] == 0)) //유저가 존재x, 아이템 존재x
                            {
                                door[i][j].BackgroundImage = null;
                                allseethrough[i][j] = 6;
                            }
                            else if (isItem[i][j] == 1)//아이템이있을때
                            {
                                door[i][j].BackgroundImage = Properties.Resources.item;
                                allseethrough[i][j] = 2;
                            }
                            else if (isItem[i][j] == 0)//아이템이없을때
                            {
                                door[i][j].BackgroundImage = null;
                                allseethrough[i][j] = 7;
                            }
                        }
                    }
                }
                allseethroughTimer--;
            }

            else
            {
                for (int i = 2; i < 7; i++)
                {
                    for (int j = 2; j < 7; j++)
                    {
                        if (allseethrough[i][j] == 0)//1p
                        { //창문있고 유저존재
                            if (i == 2)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door1;
                            }
                            else if (i == 3 || i == 4)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door2;
                            }
                            else if (i == 5 || i == 6)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door3;
                            }
                        }

                        if (allseethrough[i][j] == 1)//2p
                        { //창문있고 유저존재
                            if (i == 2)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door1;
                            }
                            else if (i == 3 || i == 4)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door2;
                            }
                            else if (i == 5 || i == 6)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door3;
                            }
                        }

                        else if (allseethrough[i][j] == 8) //문이깨져있을때
                        {
                            if (isUser[i][j] == userNum)// 유저가 존재
                            {
                                door[i][j].BackgroundImage = char_user;
                            }
                        }
                        else if (allseethrough[i][j] == 9) //문이깨져있을때
                        {
                            if (isUser[i][j] == otherNum)// 유저가 존재
                            {
                                door[i][j].BackgroundImage = char_other;
                            }
                        }

                        else if (allseethrough[i][j] == 2)     //문이깨져있고 아이템이있을때
                        {
                            door[i][j].BackgroundImage = Properties.Resources.item;
                        }

                        else if (allseethrough[i][j] == 3 || allseethrough[i][j] == 4)     //문이있고 아이템이있을때
                        {
                            if (i == 2)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door1;
                            }
                            else if (i == 3 || i == 4)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door2;
                            }
                            else if (i == 5 || i == 6)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door3;
                            }
                        }
                        else if (allseethrough[i][j] == 5)  //문이 있고 유저 없을때
                        {
                            if (i == 2)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door1;
                            }
                            else if (i == 3 || i == 4)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door2;
                            }
                            else if (i == 5 || i == 6)
                            {
                                door[i][j].BackgroundImage = Properties.Resources.door3;
                            }
                        }
                        else if ((allseethrough[i][j] == 6) || (allseethrough[i][j] == 7))//유저가 존재x + 아이템 존재x, 아이템 존재x
                        {
                            door[i][j].BackgroundImage = null;
                        }
                    }
                }
                timer_allseethrough.Stop();
                allseethroughItem = false;
                allseethroughTimer = 2;
                turnChange();
            }
        }

        private void item_Click(object sender, EventArgs e)
        {
            if ((button_attack.Text == "공격") && (button_attack.Enabled == true))
            {
                for (int i = 3; i < 6; i++)
                {
                    if (itemButton[i] == sender)
                    {
                        if (itemNumber[i]%100==1)
                        {
                            doubleAttack = true;
                            Invoke(new MethodInvoker(delegate ()
                            {
                                label_log.Text = "더블어택 : 한 곳에 두번 공격합니다.";
                            }));
                        }
                        else if (itemNumber[i]%100==2)
                        {
                            multiAttack = 2;
                            Invoke(new MethodInvoker(delegate ()
                            {
                                label_log.Text = "멀티어택 : 두 곳을 공격합니다.";
                            }));
                        }
                        else if(itemNumber[i] % 100 == 3)
                        {
                            seethroughItem = true;
                            Invoke(new MethodInvoker(delegate ()
                            {
                                label_log.Text = "투시 : 한 곳을 2초간 투시해볼 수 있습니다.";
                            }));
                        }
                        else if (itemNumber[i] % 100 == 6)
                        {
                            allseethroughItem = true;
                            Invoke(new MethodInvoker(delegate ()
                            {
                                label_log.Text = "모든 문을 2초간 투시해볼 수 있습니다.";
                            }));
                        }
                        else if (itemNumber[i] % 100 == 9)
                        {

                        }
                        canAttack = false;
                        button_attack.Text = "공격";
                        button_attack.Enabled = false;

                        itemButton[i].BackgroundImage = null;
                        itemButton[i].Enabled = false;
                        attackItemCount--;
                        turnChange();
                    }
                }
            }

            if ((button_move.Text == "이동") && (button_move.Enabled == true) && (button_attack.Text != "Skip"))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (itemButton[i] == sender)
                    {
                        if (itemNumber[i] % 100 == 4)
                        {
                            Invoke(new MethodInvoker(delegate ()
                            {
                                label_log.Text = "물약 : 체력을 일정 회복합니다.";
                            }));
                            if (userNum == 1)
                            {
                                if (HPbar1.Value != 100)
                                    socket.Send(Encoding.UTF8.GetBytes("heal:" + userNum.ToString() + "+" + "/"));
                            }
                            else if (userNum == 2)
                            {
                                if (HPbar.Value != 100)
                                    socket.Send(Encoding.UTF8.GetBytes("heal:" + userNum.ToString() + "+" + "/"));
                            }
                        }
                        else if (itemNumber[i] % 100 == 5)
                        {
                            moreMove = true;
                            Invoke(new MethodInvoker(delegate ()
                            {
                                label_log.Text = "이동증가 : 이동범위가 늘어납니다.";
                            }));
                        }
                        else if (itemNumber[i] % 100 == 7)
                        {

                        }
                        else if (itemNumber[i] % 100 == 8)
                        {
                            teleport = true;
                            Invoke(new MethodInvoker(delegate ()
                            {
                                label_log.Text = "텔레포트 : 모든 범위를 이동할 수 있습니다.";
                            }));
                        }
                        canMove = false;
                        button_move.Text = "이동";
                        button_move.Enabled = false;

                        itemButton[i].BackgroundImage = null;
                        itemButton[i].Enabled = false;
                        defenceItemCount--;
                        turnChange();
                    }
                }
            }
        }

        private void button_chat_Click(object sender, EventArgs e)
        {
            socket.Send(Encoding.UTF8.GetBytes("chat:" + id + " : " + textBox_chat2.Text + "/"));
            textBox_chat2.Text = "";
            textBox_chat2.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket != null)
                socket.Close();
            if (receiveThread != null)
                receiveThread.Abort();
        }

        public void reset()
        {
            for (int i = 2; i < 7; i++)
            {
                for (int j = 2; j < 7; j++)
                {
                    if (i == 2)
                        door[i][j].BackgroundImage = Properties.Resources.door1;
                    else if (i == 3 || i == 4)
                        door[i][j].BackgroundImage = Properties.Resources.door2;
                    else
                        door[i][j].BackgroundImage = Properties.Resources.door3;

                    isDoor[i][j] = 0;
                    isUser[i][j] = 0;
                    isItem[i][j] = 0;

                }
            }
            for (int i = 0; i < 6; i++)
                itemButton[i].BackgroundImage = null;

            if(userNum == 1)
            {
                char_user = Properties.Resources.Red;
                char_other = Properties.Resources.blue;
            }
            else if(userNum == 2)
            {
                char_user = Properties.Resources.blue;
                char_other = Properties.Resources.Red;
            }

            HPbar.Value = 100;
            HPbar1.Value = 100;

            button_start.Enabled = true;
            start_cnt = 0;
            canStart = 0;

            button_attack.Enabled = false;
            button_move.Enabled = false;
            timer1.Stop();
            turnTime = 30;
            turnCount = 0;
            label_timer.Text = "";

            Invoke(new MethodInvoker(delegate ()
            {
                label_log.Text = "게임을 다시 시작합니다. 시작버튼을 눌러주세요.";
            }));
        }
    }
}