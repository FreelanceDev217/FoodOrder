namespace FoodOrder
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.uiLblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiTextServerAdd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiTextDBName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiTextUserID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uiTextPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiTextCheckInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uiBtnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status :";
            // 
            // uiLblStatus
            // 
            this.uiLblStatus.AutoSize = true;
            this.uiLblStatus.ForeColor = System.Drawing.Color.Blue;
            this.uiLblStatus.Location = new System.Drawing.Point(72, 14);
            this.uiLblStatus.Name = "uiLblStatus";
            this.uiLblStatus.Size = new System.Drawing.Size(103, 13);
            this.uiLblStatus.TabIndex = 8;
            this.uiLblStatus.Text = "Connected to server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Server address";
            // 
            // uiTextServerAdd
            // 
            this.uiTextServerAdd.Location = new System.Drawing.Point(101, 42);
            this.uiTextServerAdd.Name = "uiTextServerAdd";
            this.uiTextServerAdd.Size = new System.Drawing.Size(175, 20);
            this.uiTextServerAdd.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database name";
            // 
            // uiTextDBName
            // 
            this.uiTextDBName.Location = new System.Drawing.Point(101, 71);
            this.uiTextDBName.Name = "uiTextDBName";
            this.uiTextDBName.Size = new System.Drawing.Size(175, 20);
            this.uiTextDBName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "User ID";
            // 
            // uiTextUserID
            // 
            this.uiTextUserID.Location = new System.Drawing.Point(101, 100);
            this.uiTextUserID.Name = "uiTextUserID";
            this.uiTextUserID.Size = new System.Drawing.Size(175, 20);
            this.uiTextUserID.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password";
            // 
            // uiTextPassword
            // 
            this.uiTextPassword.Location = new System.Drawing.Point(101, 129);
            this.uiTextPassword.Name = "uiTextPassword";
            this.uiTextPassword.PasswordChar = '●';
            this.uiTextPassword.Size = new System.Drawing.Size(175, 20);
            this.uiTextPassword.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Check interval";
            // 
            // uiTextCheckInterval
            // 
            this.uiTextCheckInterval.Location = new System.Drawing.Point(101, 158);
            this.uiTextCheckInterval.Name = "uiTextCheckInterval";
            this.uiTextCheckInterval.Size = new System.Drawing.Size(158, 20);
            this.uiTextCheckInterval.TabIndex = 4;
            this.uiTextCheckInterval.Text = "60";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "s";
            // 
            // uiBtnConnect
            // 
            this.uiBtnConnect.Location = new System.Drawing.Point(201, 9);
            this.uiBtnConnect.Name = "uiBtnConnect";
            this.uiBtnConnect.Size = new System.Drawing.Size(75, 23);
            this.uiBtnConnect.TabIndex = 5;
            this.uiBtnConnect.Text = "Connect";
            this.uiBtnConnect.UseVisualStyleBackColor = true;
            this.uiBtnConnect.Click += new System.EventHandler(this.uiBtnConnect_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 187);
            this.Controls.Add(this.uiBtnConnect);
            this.Controls.Add(this.uiTextCheckInterval);
            this.Controls.Add(this.uiTextPassword);
            this.Controls.Add(this.uiTextUserID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uiTextDBName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uiTextServerAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.uiLblStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiLblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiTextServerAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiTextDBName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiTextUserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uiTextPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox uiTextCheckInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button uiBtnConnect;
    }
}

