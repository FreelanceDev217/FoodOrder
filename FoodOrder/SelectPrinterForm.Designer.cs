namespace FoodOrder
{
    partial class SelectPrinterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPrinterForm));
            this.uiGridPrinterMatch = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSavePrinterSetting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridPrinterMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGridPrinterMatch
            // 
            this.uiGridPrinterMatch.AllowUserToAddRows = false;
            this.uiGridPrinterMatch.AllowUserToDeleteRows = false;
            this.uiGridPrinterMatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.uiGridPrinterMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridPrinterMatch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.uiGridPrinterMatch.Location = new System.Drawing.Point(13, 41);
            this.uiGridPrinterMatch.Name = "uiGridPrinterMatch";
            this.uiGridPrinterMatch.RowHeadersVisible = false;
            this.uiGridPrinterMatch.Size = new System.Drawing.Size(469, 360);
            this.uiGridPrinterMatch.TabIndex = 0;
            // 
            // btnSavePrinterSetting
            // 
            this.btnSavePrinterSetting.Location = new System.Drawing.Point(204, 12);
            this.btnSavePrinterSetting.Name = "btnSavePrinterSetting";
            this.btnSavePrinterSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSavePrinterSetting.TabIndex = 1;
            this.btnSavePrinterSetting.Text = "Save";
            this.btnSavePrinterSetting.UseVisualStyleBackColor = true;
            this.btnSavePrinterSetting.Click += new System.EventHandler(this.btnSavePrinterSetting_Click);
            // 
            // SelectPrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 413);
            this.Controls.Add(this.btnSavePrinterSetting);
            this.Controls.Add(this.uiGridPrinterMatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectPrinterForm";
            this.Text = "Select printers for food Categories";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectPrinterForm_FormClosing);
            this.Load += new System.EventHandler(this.SelectPrinterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGridPrinterMatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView uiGridPrinterMatch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnSavePrinterSetting;
    }
}