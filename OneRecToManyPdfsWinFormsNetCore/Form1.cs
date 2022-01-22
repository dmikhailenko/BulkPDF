using BulkPDF;
using OneRecToManyPdfsCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneRecToManyPdfsWinFormsNetCore
{
    public partial class Form1 : Form
    {
        private static IDataSource dataSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshRecords();
        }

        private void RefreshRecords()
        {
            var dataFolderPath = @"C:\Data\OneRecToManyPdfsConsole";
            var recordFileName = "MyRecords.xlsx";
            dataSource = new Spreadsheet();
            var myContacts = Common.GetMyRecords(Path.Combine(dataFolderPath, recordFileName), dataSource);

            //cboRecords.DataSource = myContacts;
            //cboRecords.DisplayMember = myContacts.Select(x=>x.Fu)
        }

    }
}
