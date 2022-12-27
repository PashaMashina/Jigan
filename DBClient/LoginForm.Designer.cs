namespace DBClient
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.ldlPassword = new System.Windows.Forms.Label();
            this.LoginImage = new System.Windows.Forms.PictureBox();
            this.lblLoginHead = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.iconShow = new System.Windows.Forms.PictureBox();
            this.iconHidden = new System.Windows.Forms.PictureBox();
            this.iconLog = new System.Windows.Forms.PictureBox();
            this.iconPass = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoginImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPass)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(228)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(228)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Font = new System.Drawing.Font("SF Pro Display", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.btnLogin.Location = new System.Drawing.Point(165, 303);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(171, 49);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(228)))));
            this.tbLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLogin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLogin.Location = new System.Drawing.Point(226, 198);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(153, 25);
            this.tbLogin.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lblLogin.Location = new System.Drawing.Point(107, 200);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(61, 23);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Логин";
            // 
            // ldlPassword
            // 
            this.ldlPassword.AutoSize = true;
            this.ldlPassword.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ldlPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.ldlPassword.Location = new System.Drawing.Point(107, 247);
            this.ldlPassword.Margin = new System.Windows.Forms.Padding(0);
            this.ldlPassword.Name = "ldlPassword";
            this.ldlPassword.Size = new System.Drawing.Size(73, 23);
            this.ldlPassword.TabIndex = 4;
            this.ldlPassword.Text = "Пароль";
            // 
            // LoginImage
            // 
            this.LoginImage.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LoginImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(140)))), ((int)(((byte)(152)))));
            this.LoginImage.Image = ((System.Drawing.Image)(resources.GetObject("LoginImage.Image")));
            this.LoginImage.Location = new System.Drawing.Point(180, 10);
            this.LoginImage.Margin = new System.Windows.Forms.Padding(0);
            this.LoginImage.Name = "LoginImage";
            this.LoginImage.Size = new System.Drawing.Size(140, 120);
            this.LoginImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoginImage.TabIndex = 6;
            this.LoginImage.TabStop = false;
            // 
            // lblLoginHead
            // 
            this.lblLoginHead.AutoSize = true;
            this.lblLoginHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(140)))), ((int)(((byte)(152)))));
            this.lblLoginHead.Font = new System.Drawing.Font("SF Pro Display", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoginHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lblLoginHead.Location = new System.Drawing.Point(165, 140);
            this.lblLoginHead.Name = "lblLoginHead";
            this.lblLoginHead.Size = new System.Drawing.Size(171, 33);
            this.lblLoginHead.TabIndex = 7;
            this.lblLoginHead.Text = "Авторизация";
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(228)))));
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPassword.Location = new System.Drawing.Point(226, 245);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(153, 25);
            this.tbPassword.TabIndex = 8;
            // 
            // iconShow
            // 
            this.iconShow.Image = ((System.Drawing.Image)(resources.GetObject("iconShow.Image")));
            this.iconShow.Location = new System.Drawing.Point(385, 245);
            this.iconShow.Name = "iconShow";
            this.iconShow.Size = new System.Drawing.Size(40, 25);
            this.iconShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconShow.TabIndex = 9;
            this.iconShow.TabStop = false;
            this.iconShow.Click += new System.EventHandler(this.iconShow_Click);
            // 
            // iconHidden
            // 
            this.iconHidden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconHidden.Image = ((System.Drawing.Image)(resources.GetObject("iconHidden.Image")));
            this.iconHidden.Location = new System.Drawing.Point(385, 245);
            this.iconHidden.Name = "iconHidden";
            this.iconHidden.Size = new System.Drawing.Size(40, 25);
            this.iconHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconHidden.TabIndex = 10;
            this.iconHidden.TabStop = false;
            this.iconHidden.Click += new System.EventHandler(this.iconHidden_Click);
            // 
            // iconLog
            // 
            this.iconLog.Image = ((System.Drawing.Image)(resources.GetObject("iconLog.Image")));
            this.iconLog.Location = new System.Drawing.Point(183, 198);
            this.iconLog.Name = "iconLog";
            this.iconLog.Size = new System.Drawing.Size(37, 25);
            this.iconLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconLog.TabIndex = 11;
            this.iconLog.TabStop = false;
            // 
            // iconPass
            // 
            this.iconPass.Image = ((System.Drawing.Image)(resources.GetObject("iconPass.Image")));
            this.iconPass.Location = new System.Drawing.Point(183, 245);
            this.iconPass.Name = "iconPass";
            this.iconPass.Size = new System.Drawing.Size(37, 25);
            this.iconPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPass.TabIndex = 12;
            this.iconPass.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(140)))), ((int)(((byte)(152)))));
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.iconPass);
            this.Controls.Add(this.iconLog);
            this.Controls.Add(this.iconHidden);
            this.Controls.Add(this.iconShow);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblLoginHead);
            this.Controls.Add(this.LoginImage);
            this.Controls.Add(this.ldlPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnLogin);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoginImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLogin;
        private TextBox tbLogin;
        private Label lblLogin;
        private Label ldlPassword;
        private PictureBox LoginImage;
        private Label lblLoginHead;
        private TextBox tbPassword;
        private PictureBox iconShow;
        private PictureBox iconHidden;
        private PictureBox iconLog;
        private PictureBox iconPass;
    }
}