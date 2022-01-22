using BulkPDF;
using OneRecToManyPdfsCore;
using System;
using System.IO;
using System.Windows.Forms;

namespace OneRecToManyPdfsWinForms
{
    public partial class Form1 : Form
    {
        private static IDataSource dataSource;
        private static string outFolderPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRefreshRecords_Click(object sender, EventArgs e)
        {
            RefreshRecords();
        }

        private void RefreshRecords()
        {
            var dataFolderPath = Properties.Settings.Default.DataFolderPath;
            var recordFileName = Properties.Settings.Default.RecordFileName;

            dataSource = new Spreadsheet();
            var myContacts = Common.GetMyRecords(Path.Combine(dataFolderPath, recordFileName), dataSource);

            cboRecords.DataSource = myContacts;
            //cboRecords.DisplayMember = myContacts.Select(x=>x.Fu)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshRecords();
        }
    }
}
