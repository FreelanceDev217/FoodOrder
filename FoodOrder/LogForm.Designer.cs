namespace FoodOrder
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.uiDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.uiDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.uiGridLog = new System.Windows.Forms.DataGridView();
            this.uiBtnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // uiDateFrom
            // 
            this.uiDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uiDateFrom.Location = new System.Drawing.Point(264, 12);
            this.uiDateFrom.Name = "uiDateFrom";
            this.uiDateFrom.Size = new System.Drawing.Size(96, 20);
            this.uiDateFrom.TabIndex = 1;
            this.uiDateFrom.ValueChanged += new System.EventHandler(this.uiDateFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // uiDateTo
            // 
            this.uiDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uiDateTo.Location = new System.Drawing.Point(400, 12);
            this.uiDateTo.Name = "uiDateTo";
            this.uiDateTo.Size = new System.Drawing.Size(96, 20);
            this.uiDateTo.TabIndex = 1;
            this.uiDateTo.ValueChanged += new System.EventHandler(this.uiDateTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // uiGridLog
            // 
            this.uiGridLog.AllowUserToAddRows = false;
            this.uiGridLog.AllowUserToDeleteRows = false;
            this.uiGridLog.AllowUserToOrderColumns = true;
            this.uiGridLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.uiGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridLog.Location = new System.Drawing.Point(13, 38);
            this.uiGridLog.Name = "uiGridLog";
            this.uiGridLog.ReadOnly = true;
            this.uiGridLog.RowHeadersVisible = false;
            this.uiGridLog.Size = new System.Drawing.Size(693, 388);
            this.uiGridLog.TabIndex = 3;
            // 
            // uiBtnRefresh
            // 
            this.uiBtnRefresh.Location = new System.Drawing.Point(630, 8);
            this.uiBtnRefresh.Name = "uiBtnRefresh";
            this.uiBtnRefresh.Size = new System.Drawing.Size(75, 23);
            this.uiBtnRefresh.TabIndex = 4;
            this.uiBtnRefresh.Text = "Refresh";
            this.uiBtnRefresh.UseVisualStyleBackColor = true;
            this.uiBtnRefresh.Click += new System.EventHandler(this.uiBtnRefresh_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 438);
            this.Controls.Add(this.uiBtnRefresh);
            this.Controls.Add(this.uiGridLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiDateTo);
            this.Controls.Add(this.uiDateFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogForm";
            this.Text = "Log";
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGridLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker uiDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker uiDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView uiGridLog;
        private System.Windows.Forms.Button uiBtnRefresh;
    }
}