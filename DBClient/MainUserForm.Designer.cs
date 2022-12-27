namespace DBClient
{
    partial class MainUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUserForm));
            this.upperPanel = new System.Windows.Forms.Panel();
            this.lblSexUser = new System.Windows.Forms.Label();
            this.iconRefreshMain = new System.Windows.Forms.PictureBox();
            this.iconSeachMain = new System.Windows.Forms.PictureBox();
            this.tbSearchMain = new System.Windows.Forms.TextBox();
            this.userInfoMain = new System.Windows.Forms.Label();
            this.dgvMainUser = new System.Windows.Forms.DataGridView();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.btnChangeAuth = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.iconHidden = new System.Windows.Forms.PictureBox();
            this.iconShow = new System.Windows.Forms.PictureBox();
            this.lblClassUser = new System.Windows.Forms.Label();
            this.upperPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconRefreshMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeachMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShow)).BeginInit();
            this.SuspendLayout();
            // 
            // upperPanel
            // 
            this.upperPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(167)))));
            this.upperPanel.Controls.Add(this.lblSexUser);
            this.upperPanel.Controls.Add(this.iconRefreshMain);
            this.upperPanel.Controls.Add(this.iconSeachMain);
            this.upperPanel.Controls.Add(this.tbSearchMain);
            this.upperPanel.Controls.Add(this.userInfoMain);
            this.upperPanel.Location = new System.Drawing.Point(12, 12);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(979, 51);
            this.upperPanel.TabIndex = 4;
            // 
            // lblSexUser
            // 
            this.lblSexUser.AutoSize = true;
            this.lblSexUser.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSexUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lblSexUser.Location = new System.Drawing.Point(565, 15);
            this.lblSexUser.Name = "lblSexUser";
            this.lblSexUser.Size = new System.Drawing.Size(61, 23);
            this.lblSexUser.TabIndex = 6;
            this.lblSexUser.Text = "Пол: ?";
            // 
            // iconRefreshMain
            // 
            this.iconRefreshMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(167)))));
            this.iconRefreshMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconRefreshMain.Image = ((System.Drawing.Image)(resources.GetObject("iconRefreshMain.Image")));
            this.iconRefreshMain.Location = new System.Drawing.Point(923, 9);
            this.iconRefreshMain.Name = "iconRefreshMain";
            this.iconRefreshMain.Size = new System.Drawing.Size(35, 33);
            this.iconRefreshMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconRefreshMain.TabIndex = 5;
            this.iconRefreshMain.TabStop = false;
            this.iconRefreshMain.Click += new System.EventHandler(this.iconRefreshMain_Click);
            this.iconRefreshMain.MouseEnter += new System.EventHandler(this.iconRefreshMain_MouseEnter);
            this.iconRefreshMain.MouseLeave += new System.EventHandler(this.iconRefreshMain_MouseLeave);
            // 
            // iconSeachMain
            // 
            this.iconSeachMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(167)))));
            this.iconSeachMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconSeachMain.Image = ((System.Drawing.Image)(resources.GetObject("iconSeachMain.Image")));
            this.iconSeachMain.Location = new System.Drawing.Point(644, 9);
            this.iconSeachMain.Name = "iconSeachMain";
            this.iconSeachMain.Size = new System.Drawing.Size(35, 33);
            this.iconSeachMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconSeachMain.TabIndex = 3;
            this.iconSeachMain.TabStop = false;
            this.iconSeachMain.Click += new System.EventHandler(this.iconSeachMain_Click);
            this.iconSeachMain.MouseEnter += new System.EventHandler(this.iconSeachMain_MouseEnter);
            this.iconSeachMain.MouseLeave += new System.EventHandler(this.iconSeachMain_MouseLeave);
            // 
            // tbSearchMain
            // 
            this.tbSearchMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearchMain.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSearchMain.Location = new System.Drawing.Point(685, 15);
            this.tbSearchMain.Name = "tbSearchMain";
            this.tbSearchMain.Size = new System.Drawing.Size(219, 23);
            this.tbSearchMain.TabIndex = 2;
            // 
            // userInfoMain
            // 
            this.userInfoMain.AutoSize = true;
            this.userInfoMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(173)))), ((int)(((byte)(167)))));
            this.userInfoMain.Font = new System.Drawing.Font("SF Pro Display", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userInfoMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.userInfoMain.Location = new System.Drawing.Point(3, 5);
            this.userInfoMain.Name = "userInfoMain";
            this.userInfoMain.Size = new System.Drawing.Size(0, 35);
            this.userInfoMain.TabIndex = 1;
            // 
            // dgvMainUser
            // 
            this.dgvMainUser.AllowUserToAddRows = false;
            this.dgvMainUser.AllowUserToDeleteRows = false;
            this.dgvMainUser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(140)))), ((int)(((byte)(152)))));
            this.dgvMainUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainUser.Location = new System.Drawing.Point(19, 74);
            this.dgvMainUser.Name = "dgvMainUser";
            this.dgvMainUser.ReadOnly = true;
            this.dgvMainUser.RowTemplate.Height = 25;
            this.dgvMainUser.Size = new System.Drawing.Size(963, 365);
            this.dgvMainUser.TabIndex = 5;
            // 
            // tbLogin
            // 
            this.tbLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLogin.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLogin.Location = new System.Drawing.Point(177, 459);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(261, 23);
            this.tbLogin.TabIndex = 6;
            // 
            // btnChangeAuth
            // 
            this.btnChangeAuth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeAuth.Location = new System.Drawing.Point(801, 459);
            this.btnChangeAuth.Name = "btnChangeAuth";
            this.btnChangeAuth.Size = new System.Drawing.Size(181, 52);
            this.btnChangeAuth.TabIndex = 7;
            this.btnChangeAuth.Text = "Изменить";
            this.btnChangeAuth.UseVisualStyleBackColor = true;
            this.btnChangeAuth.Click += new System.EventHandler(this.btnChangeAuth_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lblLogin.Location = new System.Drawing.Point(19, 459);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(66, 23);
            this.lblLogin.TabIndex = 8;
            this.lblLogin.Text = "Логин:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lblPassword.Location = new System.Drawing.Point(19, 488);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 23);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Пароль:";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPassword.Location = new System.Drawing.Point(177, 488);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(261, 23);
            this.tbPassword.TabIndex = 10;
            // 
            // iconHidden
            // 
            this.iconHidden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconHidden.Image = ((System.Drawing.Image)(resources.GetObject("iconHidden.Image")));
            this.iconHidden.Location = new System.Drawing.Point(444, 488);
            this.iconHidden.Name = "iconHidden";
            this.iconHidden.Size = new System.Drawing.Size(40, 23);
            this.iconHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconHidden.TabIndex = 11;
            this.iconHidden.TabStop = false;
            this.iconHidden.Click += new System.EventHandler(this.iconHidden_Click);
            // 
            // iconShow
            // 
            this.iconShow.Image = ((System.Drawing.Image)(resources.GetObject("iconShow.Image")));
            this.iconShow.Location = new System.Drawing.Point(444, 488);
            this.iconShow.Name = "iconShow";
            this.iconShow.Size = new System.Drawing.Size(40, 23);
            this.iconShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconShow.TabIndex = 12;
            this.iconShow.TabStop = false;
            this.iconShow.Click += new System.EventHandler(this.iconShow_Click);
            // 
            // lblClassUser
            // 
            this.lblClassUser.AutoSize = true;
            this.lblClassUser.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClassUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lblClassUser.Location = new System.Drawing.Point(518, 472);
            this.lblClassUser.Name = "lblClassUser";
            this.lblClassUser.Size = new System.Drawing.Size(244, 23);
            this.lblClassUser.TabIndex = 13;
            this.lblClassUser.Text = "Классификация: Платинова";
            // 
            // MainUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(140)))), ((int)(((byte)(152)))));
            this.ClientSize = new System.Drawing.Size(1001, 527);
            this.Controls.Add(this.lblClassUser);
            this.Controls.Add(this.iconHidden);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnChangeAuth);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.dgvMainUser);
            this.Controls.Add(this.upperPanel);
            this.Controls.Add(this.iconShow);
            this.Name = "MainUserForm";
            this.Text = "MainUserForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainUserForm_FormClosed);
            this.Load += new System.EventHandler(this.MainUserForm_Load);
            this.upperPanel.ResumeLayout(false);
            this.upperPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconRefreshMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSeachMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel upperPanel;
        private PictureBox iconRefreshMain;
        private PictureBox iconSeachMain;
        private TextBox tbSearchMain;
        private Label userInfoMain;
        private DataGridView dgvMainUser;
        private TextBox tbLogin;
        private Button btnChangeAuth;
        private Label lblLogin;
        private Label lblPassword;
        private TextBox tbPassword;
        private PictureBox iconHidden;
        private PictureBox iconShow;
        private Label lblSexUser;
        private Label lblClassUser;
    }
}