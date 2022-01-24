namespace OneRecToManyPdfs.WinForms.F48
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
            this.cboRecs = new System.Windows.Forms.ComboBox();
            this.lstTemplates = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFillTemplates = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpenDataFolder = new System.Windows.Forms.Button();
            this.btnEditBindings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboRecs
            // 
            this.cboRecs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecs.FormattingEnabled = true;
            this.cboRecs.Location = new System.Drawing.Point(12, 29);
            this.cboRecs.Name = "cboRecs";
            this.cboRecs.Size = new System.Drawing.Size(271, 21);
            this.cboRecs.TabIndex = 0;
            this.cboRecs.SelectedIndexChanged += new System.EventHandler(this.cboRecs_SelectedIndexChanged);
            // 
            // lstTemplates
            // 
            this.lstTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTemplates.FormattingEnabled = true;
            this.lstTemplates.Location = new System.Drawing.Point(12, 87);
            this.lstTemplates.Name = "lstTemplates";
            this.lstTemplates.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTemplates.Size = new System.Drawing.Size(317, 121);
            this.lstTemplates.TabIndex = 1;
            this.lstTemplates.SelectedIndexChanged += new System.EventHandler(this.lstTemplates_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Records";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PDF Templates";
            // 
            // btnFillTemplates
            // 
            this.btnFillTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFillTemplates.Enabled = false;
            this.btnFillTemplates.Location = new System.Drawing.Point(230, 225);
            this.btnFillTemplates.Name = "btnFillTemplates";
            this.btnFillTemplates.Size = new System.Drawing.Size(99, 23);
            this.btnFillTemplates.TabIndex = 4;
            this.btnFillTemplates.Text = "Fill Templates";
            this.btnFillTemplates.UseVisualStyleBackColor = true;
            this.btnFillTemplates.Click += new System.EventHandler(this.btnFillTemplates_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::OneRecToManyPdfs.Properties.Resources.refresh1_2;
            this.btnRefresh.Location = new System.Drawing.Point(291, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpenDataFolder
            // 
            this.btnOpenDataFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenDataFolder.Location = new System.Drawing.Point(17, 225);
            this.btnOpenDataFolder.Name = "btnOpenDataFolder";
            this.btnOpenDataFolder.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDataFolder.TabIndex = 6;
            this.btnOpenDataFolder.Text = "Open Data Folder";
            this.btnOpenDataFolder.UseVisualStyleBackColor = true;
            this.btnOpenDataFolder.Click += new System.EventHandler(this.btnOpenDataFolder_Click);
            // 
            // btnEditBindings
            // 
            this.btnEditBindings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditBindings.Location = new System.Drawing.Point(126, 225);
            this.btnEditBindings.Name = "btnEditBindings";
            this.btnEditBindings.Size = new System.Drawing.Size(95, 23);
            this.btnEditBindings.TabIndex = 7;
            this.btnEditBindings.Text = "Edit Bindings...";
            this.btnEditBindings.UseVisualStyleBackColor = true;
            this.btnEditBindings.Click += new System.EventHandler(this.btnEditBindings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 269);
            this.Controls.Add(this.btnEditBindings);
            this.Controls.Add(this.btnOpenDataFolder);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFillTemplates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTemplates);
            this.Controls.Add(this.cboRecs);
            this.Name = "Form1";
            this.Text = "One Record To Multiple PDFs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRecs;
        private System.Windows.Forms.ListBox lstTemplates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFillTemplates;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpenDataFolder;
        private System.Windows.Forms.Button btnEditBindings;
    }
}

