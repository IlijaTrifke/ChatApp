namespace Client
{
    partial class FrmClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.listKorisnici = new System.Windows.Forms.ListBox();
            this.btnIzbaciKorisnika = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(501, 12);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 43);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(669, 373);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 50);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 22);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(449, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(12, 402);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(636, 22);
            this.txtMessage.TabIndex = 3;
            // 
            // rtbChat
            // 
            this.rtbChat.Location = new System.Drawing.Point(12, 62);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(753, 306);
            this.rtbChat.TabIndex = 4;
            this.rtbChat.Text = "";
            // 
            // listKorisnici
            // 
            this.listKorisnici.FormattingEnabled = true;
            this.listKorisnici.ItemHeight = 16;
            this.listKorisnici.Location = new System.Drawing.Point(811, 62);
            this.listKorisnici.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listKorisnici.Name = "listKorisnici";
            this.listKorisnici.Size = new System.Drawing.Size(187, 308);
            this.listKorisnici.TabIndex = 5;
            // 
            // btnIzbaciKorisnika
            // 
            this.btnIzbaciKorisnika.Location = new System.Drawing.Point(811, 378);
            this.btnIzbaciKorisnika.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIzbaciKorisnika.Name = "btnIzbaciKorisnika";
            this.btnIzbaciKorisnika.Size = new System.Drawing.Size(188, 39);
            this.btnIzbaciKorisnika.TabIndex = 6;
            this.btnIzbaciKorisnika.Text = "Izbaci korisnika";
            this.btnIzbaciKorisnika.UseVisualStyleBackColor = true;
            this.btnIzbaciKorisnika.Click += new System.EventHandler(this.btnIzbaciKorisnika_Click);
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 450);
            this.Controls.Add(this.btnIzbaciKorisnika);
            this.Controls.Add(this.listKorisnici);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmClient";
            this.Text = "Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClient_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.ListBox listKorisnici;
        private System.Windows.Forms.Button btnIzbaciKorisnika;
    }
}

