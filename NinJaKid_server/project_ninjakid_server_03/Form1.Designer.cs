namespace project_ninjakid_server_03
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
            this.lstClient = new System.Windows.Forms.ListView();
            this.player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sockID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstClient
            // 
            this.lstClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.player,
            this.sockID,
            this.ID,
            this.PW,
            this.lastMsg,
            this.lastTime});
            this.lstClient.Location = new System.Drawing.Point(12, 12);
            this.lstClient.Name = "lstClient";
            this.lstClient.Size = new System.Drawing.Size(902, 132);
            this.lstClient.TabIndex = 0;
            this.lstClient.UseCompatibleStateImageBehavior = false;
            this.lstClient.View = System.Windows.Forms.View.Details;
            // 
            // player
            // 
            this.player.Text = "player";
            // 
            // sockID
            // 
            this.sockID.Text = "Socket id";
            this.sockID.Width = 164;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 115;
            // 
            // PW
            // 
            this.PW.Text = "PW";
            this.PW.Width = 99;
            // 
            // lastMsg
            // 
            this.lastMsg.Text = "last msg";
            this.lastMsg.Width = 277;
            // 
            // lastTime
            // 
            this.lastTime.Text = "last time";
            this.lastTime.Width = 180;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 161);
            this.Controls.Add(this.lstClient);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstClient;
        private System.Windows.Forms.ColumnHeader sockID;
        private System.Windows.Forms.ColumnHeader lastMsg;
        private System.Windows.Forms.ColumnHeader lastTime;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader PW;
        private System.Windows.Forms.ColumnHeader player;
    }
}

