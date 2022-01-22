namespace OneRecToManyPdfsWinForms
{
    partial class Form1
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
            this.cboRecords = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTemplates = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFillTemplates = new System.Windows.Forms.Button();
            this.btnRefreshRecords = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboRecords
            // 
            this.cboRecords.FormattingEnabled = true;
            this.cboRecords.Location = new System.Drawing.Point(13, 24);
            this.cboRecords.Name = "cboRecords";
            this.cboRecords.Size = new System.Drawing.Size(277, 21);
            this.cboRecords.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select record to export";
            // 
            // lstTemplates
            // 
            this.lstTemplates.FormattingEnabled = true;
            this.lstTemplates.Location = new System.Drawing.Point(13, 79);
            this.lstTemplates.Name = "lstTemplates";
            this.lstTemplates.Size = new System.Drawing.Size(353, 251);
            this.lstTemplates.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select PDF template to fill";
            // 
            // btnFillTemplates
            // 
            this.btnFillTemplates.Location = new System.Drawing.Point(263, 346);
            this.btnFillTemplates.Name = "btnFillTemplates";
            this.btnFillTemplates.Size = new System.Drawing.Size(103, 22);
            this.btnFillTemplates.TabIndex = 4;
            this.btnFillTemplates.Text = "Fill Templates";
            this.btnFillTemplates.UseVisualStyleBackColor = true;
            // 
            // btnRefreshRecords
            // 
            this.btnRefreshRecords.Location = new System.Drawing.Point(296, 24);
            this.btnRefreshRecords.Name = "btnRefreshRecords";
            this.btnRefreshRecords.Size = new System.Drawing.Size(70, 23);
            this.btnRefreshRecords.TabIndex = 5;
            this.btnRefreshRecords.Text = "Refresh";
            this.btnRefreshRecords.UseVisualStyleBackColor = true;
            this.btnRefreshRecords.Click += new System.EventHandler(this.btnRefreshRecords_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 390);
            this.Controls.Add(this.btnRefreshRecords);
            this.Controls.Add(this.btnFillTemplates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstTemplates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboRecords);
            this.Name = "Form1";
            this.Text = "One Record to Many PDFs";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTemplates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFillTemplates;
        private System.Windows.Forms.Button btnRefreshRecords;
    }
}

