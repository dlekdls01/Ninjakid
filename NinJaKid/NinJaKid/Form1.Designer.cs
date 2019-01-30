namespace NinJaKid
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_chat1 = new System.Windows.Forms.TextBox();
            this.textBox_chat2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_chat = new System.Windows.Forms.Button();
            this.timer_seethrough = new System.Windows.Forms.Timer(this.components);
            this.timer_allseethrough = new System.Windows.Forms.Timer(this.components);
            this.label_log = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.timer_bird = new System.Windows.Forms.Timer(this.components);
            this.button_종료 = new System.Windows.Forms.Button();
            this.button_도움말 = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.panel1 = new NinJaKid.DoubleBuffered();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox_timer = new System.Windows.Forms.PictureBox();
            this.pictureBox_bird = new System.Windows.Forms.PictureBox();
            this.label_2pID = new System.Windows.Forms.Label();
            this.label_1pID = new System.Windows.Forms.Label();
            this.HPbar1 = new System.Windows.Forms.ProgressBar();
            this.HPbar = new System.Windows.Forms.ProgressBar();
            this.item9 = new System.Windows.Forms.Button();
            this.item8 = new System.Windows.Forms.Button();
            this.item7 = new System.Windows.Forms.Button();
            this.item6 = new System.Windows.Forms.Button();
            this.item5 = new System.Windows.Forms.Button();
            this.item4 = new System.Windows.Forms.Button();
            this.item3 = new System.Windows.Forms.Button();
            this.item2 = new System.Windows.Forms.Button();
            this.item1 = new System.Windows.Forms.Button();
            this.label_timer = new System.Windows.Forms.Label();
            this.button_move = new System.Windows.Forms.Button();
            this.button_attack = new System.Windows.Forms.Button();
            this.door24 = new System.Windows.Forms.Button();
            this.door23 = new System.Windows.Forms.Button();
            this.door22 = new System.Windows.Forms.Button();
            this.door21 = new System.Windows.Forms.Button();
            this.door20 = new System.Windows.Forms.Button();
            this.door19 = new System.Windows.Forms.Button();
            this.door18 = new System.Windows.Forms.Button();
            this.door17 = new System.Windows.Forms.Button();
            this.door16 = new System.Windows.Forms.Button();
            this.door15 = new System.Windows.Forms.Button();
            this.door14 = new System.Windows.Forms.Button();
            this.door13 = new System.Windows.Forms.Button();
            this.door12 = new System.Windows.Forms.Button();
            this.door11 = new System.Windows.Forms.Button();
            this.door10 = new System.Windows.Forms.Button();
            this.door9 = new System.Windows.Forms.Button();
            this.door8 = new System.Windows.Forms.Button();
            this.door7 = new System.Windows.Forms.Button();
            this.door6 = new System.Windows.Forms.Button();
            this.door5 = new System.Windows.Forms.Button();
            this.door4 = new System.Windows.Forms.Button();
            this.door3 = new System.Windows.Forms.Button();
            this.door2 = new System.Windows.Forms.Button();
            this.door1 = new System.Windows.Forms.Button();
            this.door0 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_timer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bird)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_chat1
            // 
            this.textBox_chat1.Location = new System.Drawing.Point(259, 750);
            this.textBox_chat1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_chat1.Multiline = true;
            this.textBox_chat1.Name = "textBox_chat1";
            this.textBox_chat1.ReadOnly = true;
            this.textBox_chat1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_chat1.Size = new System.Drawing.Size(510, 142);
            this.textBox_chat1.TabIndex = 1;
            // 
            // textBox_chat2
            // 
            this.textBox_chat2.Location = new System.Drawing.Point(259, 898);
            this.textBox_chat2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_chat2.Name = "textBox_chat2";
            this.textBox_chat2.Size = new System.Drawing.Size(423, 28);
            this.textBox_chat2.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_chat
            // 
            this.button_chat.Location = new System.Drawing.Point(694, 898);
            this.button_chat.Margin = new System.Windows.Forms.Padding(2);
            this.button_chat.Name = "button_chat";
            this.button_chat.Size = new System.Drawing.Size(75, 29);
            this.button_chat.TabIndex = 3;
            this.button_chat.Text = "보내기";
            this.button_chat.UseVisualStyleBackColor = true;
            this.button_chat.Click += new System.EventHandler(this.button_chat_Click);
            // 
            // timer_seethrough
            // 
            this.timer_seethrough.Interval = 1000;
            this.timer_seethrough.Tick += new System.EventHandler(this.timer_seethrough_Tick);
            // 
            // timer_allseethrough
            // 
            this.timer_allseethrough.Interval = 1000;
            this.timer_allseethrough.Tick += new System.EventHandler(this.timer_allseethrough_Tick);
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(255, 716);
            this.label_log.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(0, 18);
            this.label_log.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.SteelBlue;
            this.button3.Location = new System.Drawing.Point(114, 930);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // timer_bird
            // 
            this.timer_bird.Tick += new System.EventHandler(this.timer_bird_Tick);
            // 
            // button_종료
            // 
            this.button_종료.BackgroundImage = global::NinJaKid.Properties.Resources.button;
            this.button_종료.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_종료.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button_종료.FlatAppearance.BorderSize = 0;
            this.button_종료.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_종료.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_종료.Location = new System.Drawing.Point(812, 802);
            this.button_종료.Margin = new System.Windows.Forms.Padding(2);
            this.button_종료.Name = "button_종료";
            this.button_종료.Size = new System.Drawing.Size(178, 54);
            this.button_종료.TabIndex = 7;
            this.button_종료.Text = "종료";
            this.button_종료.UseVisualStyleBackColor = true;
            this.button_종료.Click += new System.EventHandler(this.button_종료_Click);
            // 
            // button_도움말
            // 
            this.button_도움말.BackgroundImage = global::NinJaKid.Properties.Resources.button;
            this.button_도움말.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_도움말.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button_도움말.FlatAppearance.BorderSize = 0;
            this.button_도움말.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_도움말.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_도움말.Location = new System.Drawing.Point(812, 872);
            this.button_도움말.Margin = new System.Windows.Forms.Padding(2);
            this.button_도움말.Name = "button_도움말";
            this.button_도움말.Size = new System.Drawing.Size(178, 54);
            this.button_도움말.TabIndex = 5;
            this.button_도움말.Text = "도움말";
            this.button_도움말.UseVisualStyleBackColor = true;
            this.button_도움말.Click += new System.EventHandler(this.button_도움말_Click);
            // 
            // button_start
            // 
            this.button_start.BackgroundImage = global::NinJaKid.Properties.Resources.button;
            this.button_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_start.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_start.Location = new System.Drawing.Point(812, 733);
            this.button_start.Margin = new System.Windows.Forms.Padding(2);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(178, 54);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "시작";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::NinJaKid.Properties.Resources.background;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox_timer);
            this.panel1.Controls.Add(this.pictureBox_bird);
            this.panel1.Controls.Add(this.label_2pID);
            this.panel1.Controls.Add(this.label_1pID);
            this.panel1.Controls.Add(this.HPbar1);
            this.panel1.Controls.Add(this.HPbar);
            this.panel1.Controls.Add(this.item9);
            this.panel1.Controls.Add(this.item8);
            this.panel1.Controls.Add(this.item7);
            this.panel1.Controls.Add(this.item6);
            this.panel1.Controls.Add(this.item5);
            this.panel1.Controls.Add(this.item4);
            this.panel1.Controls.Add(this.item3);
            this.panel1.Controls.Add(this.item2);
            this.panel1.Controls.Add(this.item1);
            this.panel1.Controls.Add(this.label_timer);
            this.panel1.Controls.Add(this.button_move);
            this.panel1.Controls.Add(this.button_attack);
            this.panel1.Controls.Add(this.door24);
            this.panel1.Controls.Add(this.door23);
            this.panel1.Controls.Add(this.door22);
            this.panel1.Controls.Add(this.door21);
            this.panel1.Controls.Add(this.door20);
            this.panel1.Controls.Add(this.door19);
            this.panel1.Controls.Add(this.door18);
            this.panel1.Controls.Add(this.door17);
            this.panel1.Controls.Add(this.door16);
            this.panel1.Controls.Add(this.door15);
            this.panel1.Controls.Add(this.door14);
            this.panel1.Controls.Add(this.door13);
            this.panel1.Controls.Add(this.door12);
            this.panel1.Controls.Add(this.door11);
            this.panel1.Controls.Add(this.door10);
            this.panel1.Controls.Add(this.door9);
            this.panel1.Controls.Add(this.door8);
            this.panel1.Controls.Add(this.door7);
            this.panel1.Controls.Add(this.door6);
            this.panel1.Controls.Add(this.door5);
            this.panel1.Controls.Add(this.door4);
            this.panel1.Controls.Add(this.door3);
            this.panel1.Controls.Add(this.door2);
            this.panel1.Controls.Add(this.door1);
            this.panel1.Controls.Add(this.door0);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 689);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::NinJaKid.Properties.Resources.도움말;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(232, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 399);
            this.panel2.TabIndex = 42;
            this.panel2.Visible = false;
            // 
            // pictureBox_timer
            // 
            this.pictureBox_timer.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_timer.Image = global::NinJaKid.Properties.Resources.timer;
            this.pictureBox_timer.Location = new System.Drawing.Point(880, 212);
            this.pictureBox_timer.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_timer.Name = "pictureBox_timer";
            this.pictureBox_timer.Size = new System.Drawing.Size(40, 52);
            this.pictureBox_timer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_timer.TabIndex = 41;
            this.pictureBox_timer.TabStop = false;
            // 
            // pictureBox_bird
            // 
            this.pictureBox_bird.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_bird.Image = global::NinJaKid.Properties.Resources.bird;
            this.pictureBox_bird.Location = new System.Drawing.Point(904, 0);
            this.pictureBox_bird.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_bird.Name = "pictureBox_bird";
            this.pictureBox_bird.Size = new System.Drawing.Size(100, 49);
            this.pictureBox_bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_bird.TabIndex = 40;
            this.pictureBox_bird.TabStop = false;
            // 
            // label_2pID
            // 
            this.label_2pID.AutoSize = true;
            this.label_2pID.BackColor = System.Drawing.Color.Transparent;
            this.label_2pID.Location = new System.Drawing.Point(875, 590);
            this.label_2pID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_2pID.Name = "label_2pID";
            this.label_2pID.Size = new System.Drawing.Size(0, 18);
            this.label_2pID.TabIndex = 39;
            this.label_2pID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_1pID
            // 
            this.label_1pID.AutoSize = true;
            this.label_1pID.BackColor = System.Drawing.Color.Transparent;
            this.label_1pID.Location = new System.Drawing.Point(91, 590);
            this.label_1pID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_1pID.Name = "label_1pID";
            this.label_1pID.Size = new System.Drawing.Size(0, 18);
            this.label_1pID.TabIndex = 38;
            this.label_1pID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HPbar1
            // 
            this.HPbar1.ForeColor = System.Drawing.Color.Lime;
            this.HPbar1.Location = new System.Drawing.Point(18, 410);
            this.HPbar1.Margin = new System.Windows.Forms.Padding(4);
            this.HPbar1.Name = "HPbar1";
            this.HPbar1.Size = new System.Drawing.Size(185, 32);
            this.HPbar1.Step = -20;
            this.HPbar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.HPbar1.TabIndex = 37;
            this.HPbar1.Value = 100;
            // 
            // HPbar
            // 
            this.HPbar.ForeColor = System.Drawing.Color.Lime;
            this.HPbar.Location = new System.Drawing.Point(808, 412);
            this.HPbar.Margin = new System.Windows.Forms.Padding(4);
            this.HPbar.Name = "HPbar";
            this.HPbar.Size = new System.Drawing.Size(185, 32);
            this.HPbar.Step = -20;
            this.HPbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.HPbar.TabIndex = 36;
            this.HPbar.Value = 100;
            // 
            // item9
            // 
            this.item9.BackColor = System.Drawing.Color.Transparent;
            this.item9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item9.Location = new System.Drawing.Point(920, 654);
            this.item9.Margin = new System.Windows.Forms.Padding(4);
            this.item9.Name = "item9";
            this.item9.Size = new System.Drawing.Size(31, 30);
            this.item9.TabIndex = 35;
            this.item9.UseVisualStyleBackColor = false;
            // 
            // item8
            // 
            this.item8.BackColor = System.Drawing.Color.Transparent;
            this.item8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item8.Location = new System.Drawing.Point(886, 654);
            this.item8.Margin = new System.Windows.Forms.Padding(4);
            this.item8.Name = "item8";
            this.item8.Size = new System.Drawing.Size(31, 30);
            this.item8.TabIndex = 34;
            this.item8.UseVisualStyleBackColor = false;
            // 
            // item7
            // 
            this.item7.BackColor = System.Drawing.Color.Transparent;
            this.item7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item7.Location = new System.Drawing.Point(852, 654);
            this.item7.Margin = new System.Windows.Forms.Padding(4);
            this.item7.Name = "item7";
            this.item7.Size = new System.Drawing.Size(31, 30);
            this.item7.TabIndex = 33;
            this.item7.UseVisualStyleBackColor = false;
            // 
            // item6
            // 
            this.item6.BackColor = System.Drawing.Color.Transparent;
            this.item6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item6.Enabled = false;
            this.item6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item6.Location = new System.Drawing.Point(719, 653);
            this.item6.Margin = new System.Windows.Forms.Padding(4);
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(31, 30);
            this.item6.TabIndex = 32;
            this.item6.UseVisualStyleBackColor = false;
            this.item6.Click += new System.EventHandler(this.item_Click);
            // 
            // item5
            // 
            this.item5.BackColor = System.Drawing.Color.Transparent;
            this.item5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item5.Enabled = false;
            this.item5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item5.Location = new System.Drawing.Point(684, 653);
            this.item5.Margin = new System.Windows.Forms.Padding(4);
            this.item5.Name = "item5";
            this.item5.Size = new System.Drawing.Size(31, 30);
            this.item5.TabIndex = 31;
            this.item5.UseVisualStyleBackColor = false;
            this.item5.Click += new System.EventHandler(this.item_Click);
            // 
            // item4
            // 
            this.item4.BackColor = System.Drawing.Color.Transparent;
            this.item4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item4.Enabled = false;
            this.item4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item4.Location = new System.Drawing.Point(650, 653);
            this.item4.Margin = new System.Windows.Forms.Padding(4);
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(31, 30);
            this.item4.TabIndex = 30;
            this.item4.UseVisualStyleBackColor = false;
            this.item4.Click += new System.EventHandler(this.item_Click);
            // 
            // item3
            // 
            this.item3.BackColor = System.Drawing.Color.Transparent;
            this.item3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item3.Enabled = false;
            this.item3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item3.Location = new System.Drawing.Point(554, 653);
            this.item3.Margin = new System.Windows.Forms.Padding(4);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(31, 30);
            this.item3.TabIndex = 29;
            this.item3.UseVisualStyleBackColor = false;
            this.item3.Click += new System.EventHandler(this.item_Click);
            // 
            // item2
            // 
            this.item2.BackColor = System.Drawing.Color.Transparent;
            this.item2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item2.Enabled = false;
            this.item2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item2.Location = new System.Drawing.Point(521, 653);
            this.item2.Margin = new System.Windows.Forms.Padding(4);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(31, 30);
            this.item2.TabIndex = 28;
            this.item2.UseVisualStyleBackColor = false;
            this.item2.Click += new System.EventHandler(this.item_Click);
            // 
            // item1
            // 
            this.item1.BackColor = System.Drawing.Color.Transparent;
            this.item1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.item1.Enabled = false;
            this.item1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.item1.Location = new System.Drawing.Point(489, 653);
            this.item1.Margin = new System.Windows.Forms.Padding(4);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(31, 30);
            this.item1.TabIndex = 6;
            this.item1.UseVisualStyleBackColor = false;
            this.item1.Click += new System.EventHandler(this.item_Click);
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.BackColor = System.Drawing.Color.Transparent;
            this.label_timer.ForeColor = System.Drawing.Color.White;
            this.label_timer.Location = new System.Drawing.Point(875, 185);
            this.label_timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(0, 18);
            this.label_timer.TabIndex = 27;
            // 
            // button_move
            // 
            this.button_move.BackColor = System.Drawing.Color.Transparent;
            this.button_move.Enabled = false;
            this.button_move.FlatAppearance.BorderSize = 0;
            this.button_move.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_move.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_move.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_move.Location = new System.Drawing.Point(208, 650);
            this.button_move.Margin = new System.Windows.Forms.Padding(2);
            this.button_move.Name = "button_move";
            this.button_move.Size = new System.Drawing.Size(100, 37);
            this.button_move.TabIndex = 26;
            this.button_move.Text = "이동";
            this.button_move.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_move.UseVisualStyleBackColor = false;
            this.button_move.Click += new System.EventHandler(this.button_move_Click);
            // 
            // button_attack
            // 
            this.button_attack.BackColor = System.Drawing.Color.Transparent;
            this.button_attack.Enabled = false;
            this.button_attack.FlatAppearance.BorderSize = 0;
            this.button_attack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_attack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_attack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_attack.Location = new System.Drawing.Point(102, 650);
            this.button_attack.Margin = new System.Windows.Forms.Padding(2);
            this.button_attack.Name = "button_attack";
            this.button_attack.Size = new System.Drawing.Size(100, 37);
            this.button_attack.TabIndex = 25;
            this.button_attack.Text = "공격";
            this.button_attack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_attack.UseVisualStyleBackColor = false;
            this.button_attack.Click += new System.EventHandler(this.button_attack_Click);
            // 
            // door24
            // 
            this.door24.BackColor = System.Drawing.Color.Transparent;
            this.door24.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door24.BackgroundImage")));
            this.door24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door24.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door24.FlatAppearance.BorderSize = 0;
            this.door24.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door24.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door24.Location = new System.Drawing.Point(644, 559);
            this.door24.Margin = new System.Windows.Forms.Padding(2);
            this.door24.Name = "door24";
            this.door24.Size = new System.Drawing.Size(72, 78);
            this.door24.TabIndex = 24;
            this.door24.UseVisualStyleBackColor = false;
            this.door24.Click += new System.EventHandler(this.door_Click);
            this.door24.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door24.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door23
            // 
            this.door23.BackColor = System.Drawing.Color.Transparent;
            this.door23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door23.BackgroundImage")));
            this.door23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door23.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door23.FlatAppearance.BorderSize = 0;
            this.door23.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door23.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door23.Location = new System.Drawing.Point(555, 559);
            this.door23.Margin = new System.Windows.Forms.Padding(2);
            this.door23.Name = "door23";
            this.door23.Size = new System.Drawing.Size(72, 78);
            this.door23.TabIndex = 23;
            this.door23.UseVisualStyleBackColor = false;
            this.door23.Click += new System.EventHandler(this.door_Click);
            this.door23.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door23.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door22
            // 
            this.door22.BackColor = System.Drawing.Color.Transparent;
            this.door22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door22.BackgroundImage")));
            this.door22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door22.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door22.FlatAppearance.BorderSize = 0;
            this.door22.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door22.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door22.Location = new System.Drawing.Point(466, 559);
            this.door22.Margin = new System.Windows.Forms.Padding(2);
            this.door22.Name = "door22";
            this.door22.Size = new System.Drawing.Size(72, 78);
            this.door22.TabIndex = 22;
            this.door22.UseVisualStyleBackColor = false;
            this.door22.Click += new System.EventHandler(this.door_Click);
            this.door22.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door22.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door21
            // 
            this.door21.BackColor = System.Drawing.Color.Transparent;
            this.door21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door21.BackgroundImage")));
            this.door21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door21.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door21.FlatAppearance.BorderSize = 0;
            this.door21.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door21.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door21.Location = new System.Drawing.Point(378, 559);
            this.door21.Margin = new System.Windows.Forms.Padding(2);
            this.door21.Name = "door21";
            this.door21.Size = new System.Drawing.Size(72, 78);
            this.door21.TabIndex = 21;
            this.door21.UseVisualStyleBackColor = false;
            this.door21.Click += new System.EventHandler(this.door_Click);
            this.door21.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door21.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door20
            // 
            this.door20.BackColor = System.Drawing.Color.Transparent;
            this.door20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door20.BackgroundImage")));
            this.door20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door20.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door20.FlatAppearance.BorderSize = 0;
            this.door20.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door20.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door20.Location = new System.Drawing.Point(288, 559);
            this.door20.Margin = new System.Windows.Forms.Padding(2);
            this.door20.Name = "door20";
            this.door20.Size = new System.Drawing.Size(72, 78);
            this.door20.TabIndex = 20;
            this.door20.UseVisualStyleBackColor = false;
            this.door20.Click += new System.EventHandler(this.door_Click);
            this.door20.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door20.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door19
            // 
            this.door19.BackColor = System.Drawing.Color.Transparent;
            this.door19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door19.BackgroundImage")));
            this.door19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door19.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door19.FlatAppearance.BorderSize = 0;
            this.door19.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door19.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door19.ForeColor = System.Drawing.Color.Lime;
            this.door19.Location = new System.Drawing.Point(640, 440);
            this.door19.Margin = new System.Windows.Forms.Padding(2);
            this.door19.Name = "door19";
            this.door19.Size = new System.Drawing.Size(72, 77);
            this.door19.TabIndex = 19;
            this.door19.UseVisualStyleBackColor = false;
            this.door19.Click += new System.EventHandler(this.door_Click);
            this.door19.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door19.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door18
            // 
            this.door18.BackColor = System.Drawing.Color.Transparent;
            this.door18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door18.BackgroundImage")));
            this.door18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door18.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door18.FlatAppearance.BorderSize = 0;
            this.door18.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door18.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door18.Location = new System.Drawing.Point(552, 440);
            this.door18.Margin = new System.Windows.Forms.Padding(2);
            this.door18.Name = "door18";
            this.door18.Size = new System.Drawing.Size(72, 77);
            this.door18.TabIndex = 18;
            this.door18.UseVisualStyleBackColor = false;
            this.door18.Click += new System.EventHandler(this.door_Click);
            this.door18.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door18.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door17
            // 
            this.door17.BackColor = System.Drawing.Color.Transparent;
            this.door17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door17.BackgroundImage")));
            this.door17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door17.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door17.FlatAppearance.BorderSize = 0;
            this.door17.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door17.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door17.Location = new System.Drawing.Point(466, 440);
            this.door17.Margin = new System.Windows.Forms.Padding(2);
            this.door17.Name = "door17";
            this.door17.Size = new System.Drawing.Size(72, 77);
            this.door17.TabIndex = 17;
            this.door17.UseVisualStyleBackColor = false;
            this.door17.Click += new System.EventHandler(this.door_Click);
            this.door17.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door17.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door16
            // 
            this.door16.BackColor = System.Drawing.Color.Transparent;
            this.door16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door16.BackgroundImage")));
            this.door16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door16.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door16.FlatAppearance.BorderSize = 0;
            this.door16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door16.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door16.Location = new System.Drawing.Point(379, 440);
            this.door16.Margin = new System.Windows.Forms.Padding(2);
            this.door16.Name = "door16";
            this.door16.Size = new System.Drawing.Size(72, 77);
            this.door16.TabIndex = 16;
            this.door16.UseVisualStyleBackColor = false;
            this.door16.Click += new System.EventHandler(this.door_Click);
            this.door16.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door16.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door15
            // 
            this.door15.BackColor = System.Drawing.Color.Transparent;
            this.door15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door15.BackgroundImage")));
            this.door15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door15.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door15.FlatAppearance.BorderSize = 0;
            this.door15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door15.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door15.Location = new System.Drawing.Point(292, 440);
            this.door15.Margin = new System.Windows.Forms.Padding(2);
            this.door15.Name = "door15";
            this.door15.Size = new System.Drawing.Size(72, 77);
            this.door15.TabIndex = 15;
            this.door15.UseVisualStyleBackColor = false;
            this.door15.Click += new System.EventHandler(this.door_Click);
            this.door15.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door15.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door14
            // 
            this.door14.BackColor = System.Drawing.Color.Transparent;
            this.door14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door14.BackgroundImage")));
            this.door14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door14.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door14.FlatAppearance.BorderSize = 0;
            this.door14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door14.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door14.Location = new System.Drawing.Point(635, 320);
            this.door14.Margin = new System.Windows.Forms.Padding(2);
            this.door14.Name = "door14";
            this.door14.Size = new System.Drawing.Size(72, 78);
            this.door14.TabIndex = 14;
            this.door14.UseVisualStyleBackColor = false;
            this.door14.Click += new System.EventHandler(this.door_Click);
            this.door14.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door14.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door13
            // 
            this.door13.BackColor = System.Drawing.Color.Transparent;
            this.door13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door13.BackgroundImage")));
            this.door13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door13.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door13.FlatAppearance.BorderSize = 0;
            this.door13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door13.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door13.Location = new System.Drawing.Point(550, 320);
            this.door13.Margin = new System.Windows.Forms.Padding(2);
            this.door13.Name = "door13";
            this.door13.Size = new System.Drawing.Size(72, 78);
            this.door13.TabIndex = 13;
            this.door13.UseVisualStyleBackColor = false;
            this.door13.Click += new System.EventHandler(this.door_Click);
            this.door13.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door13.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door12
            // 
            this.door12.BackColor = System.Drawing.Color.Transparent;
            this.door12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door12.BackgroundImage")));
            this.door12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door12.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door12.FlatAppearance.BorderSize = 0;
            this.door12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door12.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door12.Location = new System.Drawing.Point(466, 320);
            this.door12.Margin = new System.Windows.Forms.Padding(2);
            this.door12.Name = "door12";
            this.door12.Size = new System.Drawing.Size(72, 78);
            this.door12.TabIndex = 12;
            this.door12.UseVisualStyleBackColor = false;
            this.door12.Click += new System.EventHandler(this.door_Click);
            this.door12.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door12.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door11
            // 
            this.door11.BackColor = System.Drawing.Color.Transparent;
            this.door11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door11.BackgroundImage")));
            this.door11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door11.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door11.FlatAppearance.BorderSize = 0;
            this.door11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door11.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door11.Location = new System.Drawing.Point(381, 320);
            this.door11.Margin = new System.Windows.Forms.Padding(2);
            this.door11.Name = "door11";
            this.door11.Size = new System.Drawing.Size(72, 78);
            this.door11.TabIndex = 11;
            this.door11.UseVisualStyleBackColor = false;
            this.door11.Click += new System.EventHandler(this.door_Click);
            this.door11.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door11.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door10
            // 
            this.door10.BackColor = System.Drawing.Color.Transparent;
            this.door10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door10.BackgroundImage")));
            this.door10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door10.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door10.FlatAppearance.BorderSize = 0;
            this.door10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door10.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door10.Location = new System.Drawing.Point(298, 320);
            this.door10.Margin = new System.Windows.Forms.Padding(2);
            this.door10.Name = "door10";
            this.door10.Size = new System.Drawing.Size(72, 78);
            this.door10.TabIndex = 10;
            this.door10.UseVisualStyleBackColor = false;
            this.door10.Click += new System.EventHandler(this.door_Click);
            this.door10.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door10.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door9
            // 
            this.door9.BackColor = System.Drawing.Color.Transparent;
            this.door9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door9.BackgroundImage")));
            this.door9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door9.FlatAppearance.BorderSize = 0;
            this.door9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door9.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door9.Location = new System.Drawing.Point(630, 206);
            this.door9.Margin = new System.Windows.Forms.Padding(2);
            this.door9.Name = "door9";
            this.door9.Size = new System.Drawing.Size(72, 77);
            this.door9.TabIndex = 9;
            this.door9.UseVisualStyleBackColor = false;
            this.door9.Click += new System.EventHandler(this.door_Click);
            this.door9.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door9.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door8
            // 
            this.door8.BackColor = System.Drawing.Color.Transparent;
            this.door8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door8.BackgroundImage")));
            this.door8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door8.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door8.FlatAppearance.BorderSize = 0;
            this.door8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door8.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door8.Location = new System.Drawing.Point(548, 206);
            this.door8.Margin = new System.Windows.Forms.Padding(2);
            this.door8.Name = "door8";
            this.door8.Size = new System.Drawing.Size(72, 77);
            this.door8.TabIndex = 8;
            this.door8.UseVisualStyleBackColor = false;
            this.door8.Click += new System.EventHandler(this.door_Click);
            this.door8.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door8.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door7
            // 
            this.door7.BackColor = System.Drawing.Color.Transparent;
            this.door7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door7.BackgroundImage")));
            this.door7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door7.FlatAppearance.BorderSize = 0;
            this.door7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door7.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door7.Location = new System.Drawing.Point(466, 206);
            this.door7.Margin = new System.Windows.Forms.Padding(2);
            this.door7.Name = "door7";
            this.door7.Size = new System.Drawing.Size(72, 77);
            this.door7.TabIndex = 7;
            this.door7.UseVisualStyleBackColor = false;
            this.door7.Click += new System.EventHandler(this.door_Click);
            this.door7.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door7.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door6
            // 
            this.door6.BackColor = System.Drawing.Color.Transparent;
            this.door6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door6.BackgroundImage")));
            this.door6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door6.FlatAppearance.BorderSize = 0;
            this.door6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door6.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door6.Location = new System.Drawing.Point(384, 206);
            this.door6.Margin = new System.Windows.Forms.Padding(2);
            this.door6.Name = "door6";
            this.door6.Size = new System.Drawing.Size(72, 77);
            this.door6.TabIndex = 6;
            this.door6.UseVisualStyleBackColor = false;
            this.door6.Click += new System.EventHandler(this.door_Click);
            this.door6.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door6.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door5
            // 
            this.door5.BackColor = System.Drawing.Color.Transparent;
            this.door5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door5.BackgroundImage")));
            this.door5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door5.FlatAppearance.BorderSize = 0;
            this.door5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door5.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door5.Location = new System.Drawing.Point(302, 206);
            this.door5.Margin = new System.Windows.Forms.Padding(2);
            this.door5.Name = "door5";
            this.door5.Size = new System.Drawing.Size(72, 77);
            this.door5.TabIndex = 5;
            this.door5.UseVisualStyleBackColor = false;
            this.door5.Click += new System.EventHandler(this.door_Click);
            this.door5.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door5.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door4
            // 
            this.door4.BackColor = System.Drawing.Color.Transparent;
            this.door4.BackgroundImage = global::NinJaKid.Properties.Resources.door1;
            this.door4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door4.FlatAppearance.BorderSize = 0;
            this.door4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door4.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door4.Location = new System.Drawing.Point(635, 98);
            this.door4.Margin = new System.Windows.Forms.Padding(2);
            this.door4.Name = "door4";
            this.door4.Size = new System.Drawing.Size(64, 68);
            this.door4.TabIndex = 4;
            this.door4.UseVisualStyleBackColor = false;
            this.door4.Click += new System.EventHandler(this.door_Click);
            this.door4.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door4.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door3
            // 
            this.door3.BackColor = System.Drawing.Color.Transparent;
            this.door3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door3.BackgroundImage")));
            this.door3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door3.FlatAppearance.BorderSize = 0;
            this.door3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door3.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door3.Location = new System.Drawing.Point(552, 98);
            this.door3.Margin = new System.Windows.Forms.Padding(2);
            this.door3.Name = "door3";
            this.door3.Size = new System.Drawing.Size(64, 68);
            this.door3.TabIndex = 3;
            this.door3.UseVisualStyleBackColor = false;
            this.door3.Click += new System.EventHandler(this.door_Click);
            this.door3.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door3.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door2
            // 
            this.door2.BackColor = System.Drawing.Color.Transparent;
            this.door2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door2.BackgroundImage")));
            this.door2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door2.FlatAppearance.BorderSize = 0;
            this.door2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door2.Location = new System.Drawing.Point(470, 98);
            this.door2.Margin = new System.Windows.Forms.Padding(2);
            this.door2.Name = "door2";
            this.door2.Size = new System.Drawing.Size(64, 68);
            this.door2.TabIndex = 2;
            this.door2.UseVisualStyleBackColor = false;
            this.door2.Click += new System.EventHandler(this.door_Click);
            this.door2.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door2.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door1
            // 
            this.door1.BackColor = System.Drawing.Color.Transparent;
            this.door1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door1.BackgroundImage")));
            this.door1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door1.FlatAppearance.BorderSize = 0;
            this.door1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door1.Location = new System.Drawing.Point(388, 98);
            this.door1.Margin = new System.Windows.Forms.Padding(2);
            this.door1.Name = "door1";
            this.door1.Size = new System.Drawing.Size(64, 68);
            this.door1.TabIndex = 1;
            this.door1.UseVisualStyleBackColor = false;
            this.door1.Click += new System.EventHandler(this.door_Click);
            this.door1.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door1.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // door0
            // 
            this.door0.BackColor = System.Drawing.Color.Transparent;
            this.door0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("door0.BackgroundImage")));
            this.door0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door0.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.door0.FlatAppearance.BorderSize = 0;
            this.door0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.door0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.door0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.door0.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.door0.Location = new System.Drawing.Point(306, 98);
            this.door0.Margin = new System.Windows.Forms.Padding(2);
            this.door0.Name = "door0";
            this.door0.Size = new System.Drawing.Size(64, 68);
            this.door0.TabIndex = 0;
            this.door0.UseVisualStyleBackColor = false;
            this.door0.Click += new System.EventHandler(this.door_Click);
            this.door0.MouseEnter += new System.EventHandler(this.door0_MouseEnter);
            this.door0.MouseLeave += new System.EventHandler(this.door0_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(143, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "[ 아이템 설명 ]";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(418, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "닫기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1028, 944);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_종료);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.button_도움말);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_chat);
            this.Controls.Add(this.textBox_chat2);
            this.Controls.Add(this.textBox_chat1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NINJAKID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_timer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_chat1;
        private System.Windows.Forms.TextBox textBox_chat2;
        private System.Windows.Forms.Button door0;
        private System.Windows.Forms.Button door4;
        private System.Windows.Forms.Button door3;
        private System.Windows.Forms.Button door2;
        private System.Windows.Forms.Button door1;
        private System.Windows.Forms.Button door5;
        private System.Windows.Forms.Button door14;
        private System.Windows.Forms.Button door13;
        private System.Windows.Forms.Button door12;
        private System.Windows.Forms.Button door11;
        private System.Windows.Forms.Button door10;
        private System.Windows.Forms.Button door9;
        private System.Windows.Forms.Button door8;
        private System.Windows.Forms.Button door7;
        private System.Windows.Forms.Button door6;
        private System.Windows.Forms.Button door24;
        private System.Windows.Forms.Button door23;
        private System.Windows.Forms.Button door22;
        private System.Windows.Forms.Button door21;
        private System.Windows.Forms.Button door20;
        private System.Windows.Forms.Button door19;
        private System.Windows.Forms.Button door18;
        private System.Windows.Forms.Button door17;
        private System.Windows.Forms.Button door16;
        private System.Windows.Forms.Button door15;
        private System.Windows.Forms.Button button_attack;
        private System.Windows.Forms.Button button_move;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.Button button_chat;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_도움말;
        private System.Windows.Forms.Button item9;
        private System.Windows.Forms.Button item8;
        private System.Windows.Forms.Button item7;
        private System.Windows.Forms.Button item6;
        private System.Windows.Forms.Button item5;
        private System.Windows.Forms.Button item4;
        private System.Windows.Forms.Button item3;
        private System.Windows.Forms.Button item2;
        private System.Windows.Forms.Button item1;
        private System.Windows.Forms.ProgressBar HPbar;
        private System.Windows.Forms.Timer timer_seethrough;
        private System.Windows.Forms.Timer timer_allseethrough;
        private System.Windows.Forms.ProgressBar HPbar1;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Label label_2pID;
        private System.Windows.Forms.Label label_1pID;
        private System.Windows.Forms.Button button_종료;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox_bird;
        private System.Windows.Forms.PictureBox pictureBox_timer;
        private System.Windows.Forms.Timer timer_bird;
        private DoubleBuffered panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

