using BulkPDF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace OneRecToManyPdfsConsole
{
    class Program
    {
        private static IDataSource dataSource;
        private static string outFolderPath;

        static void Main(string[] args)
        {
            //var curDir = Directory.GetCurrentDirectory();
            var dataFolderPath = Properties.Settings.Default.DataFolderPath;
            var recordFileName = Properties.Settings.Default.RecordFileName;

            dataSource = new Spreadsheet();
            var myContacts = GetMyContacts(Path.Combine(dataFolderPath, recordFileName));

            var pickedCont = PickContact(myContacts);

            if (pickedCont == null)
            {
                Console.WriteLine("Not a valid number. See ya...");
                Environment.Exit(0);
            }

            // todo: list all templates
            var templateFiles = Directory.GetFiles(dataFolderPath, "*.bulkpdf");
            Console.Write(string.Join("\n", templateFiles.Select(x=>x.Split("\\".ToArray()).Last().Replace(".bulkpdf", ""))));
            Console.WriteLine();

            // todo: fill all templates
            List<String> files = FillTemplatesWithSingleContact(pickedCont, dataFolderPath, templateFiles);

            // todo: pick templates

            // open the new folder
            Process.Start("explorer.exe", outFolderPath);
        }

        private static List<string> FillTemplatesWithSingleContact(Dictionary<string, string> pickedCont, string dataFolderPath, string[] templateFiles)
        {
            outFolderPath = Path.Combine(dataFolderPath, "out", DateTime.Now.ToString("yyyyMMddHHmmss"));
            Directory.CreateDirectory(outFolderPath);

            var outFileNames = new List<string>();
            // loop templates
            foreach (var templateFile in templateFiles)
            {
                Dictionary<string, PDFField> pdfFields = LoadPdfFieldConfiguration(templateFile);

                // PDF file name
                var pdfFileName = templateFile.Split("\\".ToArray(), StringSplitOptions.None).Last().Replace(".bulkpdf", "");

                // export file name
                var exportFileName = $"filled.{pdfFileName}";
                outFileNames.Add(exportFileName); // todo: the actual file names

                var pdf = new PDF();
                pdf.Open(Path.Combine(dataFolderPath, pdfFileName));

                // todo: fill the PDF file
                foreach (var field in pdfFields.Keys)
                {
                    if (pdfFields[field].UseValueFromDataSource)
                    {
                        var value = pickedCont[pdfFields[field].DataSourceValue];
                        pdf.SetFieldValue(field, value, pdfFields[field].MakeReadOnly);
                    }
                }

                // PDF
                pdf.SaveFilledPDF(Path.Combine(outFolderPath, exportFileName), true, false, false, "");
                pdf.ResetFieldValue();

            }
            Console.WriteLine($"Exported to '{outFolderPath}'");
            return outFileNames;
        }

        private static Dictionary<string, PDFField> LoadPdfFieldConfiguration(string templateFile)
        {
            Dictionary<string, PDFField> pdfFields = new Dictionary<string, PDFField>();
            XDocument xDocument = XDocument.Parse(File.ReadAllText(templateFile));
            foreach (var node in xDocument.Root.Element("PDFFieldValues").Descendants("PDFFieldValue"))
            {
                var pdfField = new PDFField();
                pdfField.Name = node.Element("Name").Value;
                pdfField.DataSourceValue = node.Element("NewValue").Value;
                pdfField.UseValueFromDataSource = Convert.ToBoolean(node.Element("UseValueFromDataSource").Value);
                pdfField.MakeReadOnly = Convert.ToBoolean(node.Element("MakeReadOnly").Value);

                pdfFields.Add(pdfField.Name, pdfField);

            }
            return pdfFields;
        }

        private static Dictionary<string, string> PickContact(Dictionary<int, Dictionary<string, string>> myContacts)
        {
            foreach (var cont in myContacts)
            {
                var contactLine = string.Empty;
                for (int fld = 0; fld < 2; fld++)
                {
                    contactLine += cont.Value.Values.ToArray()[fld] + " ";
                }
                Console.WriteLine($"{cont.Key + 1}. {contactLine}");
            }

            Console.WriteLine();

            Console.Write("Pick a contact: ");
            string pick = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(pick, out int contNum))
            {
                return myContacts[contNum - 1];
            }
            else
            {
                return null;
            }

        }

        static Dictionary<int, Dictionary<string, string>> GetMyContacts(string filePath)
        {
            var myContacts = new Dictionary<int, Dictionary<string, string>>();

            dataSource.Open(filePath);

            var columns = (List<string>)dataSource.Columns;

            for (int i = 0; i < dataSource.PossibleRows; i++)
            {

                var colDict = new Dictionary<string, string>();
                for (int col = 0; col < columns.Count; col++)
                {
                    colDict.Add(columns[col], dataSource.GetField(col + 1));
                }

                myContacts.Add(i, colDict);

                dataSource.NextRow();
            }

            dataSource.Close();

            return myContacts;
        }

    }
}
