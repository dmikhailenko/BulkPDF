﻿using BulkPDF;
using OneRecToManyPdfsCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OneRecToManyPdfs.WinForms.F48
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Dictionary<string, string>> _myRecs;
        private string _dataFolderPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            _dataFolderPath = Properties.Settings.Default.DataFolderPath;
            var recordFileName = Properties.Settings.Default.RecordFileName;

            var fullRecFilePath = Path.Combine(_dataFolderPath, recordFileName);

            if (!File.Exists(fullRecFilePath))
            {
                MessageBox.Show(this, $"The following file is not found: '{fullRecFilePath}'\n\nApplication will close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            IDataSource dataSource = new Spreadsheet();
            _myRecs = Common.GetMyRecords(fullRecFilePath, dataSource);

            // populate combobox with records
            cboRecs.Items.Clear();
            foreach (var rec in _myRecs)
            {
                cboRecs.Items.Add(Common.GetDisplayName(rec.Value));
            }

            // populate listbox with templates
            lstTemplates.Items.Clear(); 
            var templateFiles = Directory.GetFiles(_dataFolderPath, "*.bulkpdf");
            foreach (var tpl in templateFiles)
            {
                lstTemplates.Items.Add(tpl.Split("\\".ToArray()).Last().Replace(".bulkpdf", ""));
            }

            btnFillTemplates.Enabled = false;
        }

        private void btnFillTemplates_Click(object sender, EventArgs e)
        {
            var pickedRec = _myRecs[cboRecs.SelectedIndex];

            var selectedTemplateFiles = new List<string>();
            foreach (var selItm in lstTemplates.SelectedItems)
            {
                selectedTemplateFiles.Add(selItm.ToString());
            }

            Cursor.Current = Cursors.WaitCursor;

            string outFolderPath;
            List<String> files = Common.FillTemplatesWithSingleRecord(pickedRec, _dataFolderPath, selectedTemplateFiles, out outFolderPath);


            // open the new folder
            Process.Start("explorer.exe", outFolderPath);

            Cursor.Current = Cursors.Default;

        }

        private void cboRecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableTheFillTemplatesButton();
        }

        private void lstTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableTheFillTemplatesButton();
        }
        private void EnableDisableTheFillTemplatesButton()
        {
            btnFillTemplates.Enabled = (cboRecs.SelectedIndex != -1) && (lstTemplates.SelectedItems.Count > 0);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RefreshData();
            Cursor.Current = Cursors.Default;
        }

        private void btnOpenDataFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _dataFolderPath);
        }

        private void btnEditBindings_Click(object sender, EventArgs e)
        {
            //Process.Start("BulkPDF.exe");
            var bulkPdf = new BulkPDF.MainForm();
            bulkPdf.InitialDirectory = _dataFolderPath;
            bulkPdf.ShowDialog();
            RefreshData();
        }
    }
}