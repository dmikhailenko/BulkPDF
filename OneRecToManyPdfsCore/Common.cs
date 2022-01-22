using BulkPDF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OneRecToManyPdfsCore
{
    public class Common
    {
        public static Dictionary<int, Dictionary<string, string>> GetMyRecords(string filePath, IDataSource dataSource)
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

        public static List<string> FillTemplatesWithSingleRecord(Dictionary<string, string> pickedCont, string dataFolderPath, IEnumerable<string> templateFiles, out string outFolderPath)
        {

            outFolderPath = Path.Combine(dataFolderPath, "out", DateTime.Now.ToString("yyyyMMddHHmmss"));

            Directory.CreateDirectory(outFolderPath);

            var outFileNames = new List<string>();
            // loop templates
            foreach (var templateFile in templateFiles)
            {

                var templateFileFullPath = Path.Combine(dataFolderPath, templateFile) + ".bulkpdf";

                Dictionary<string, PDFField> pdfFields = LoadPdfFieldConfiguration(templateFileFullPath);

                // PDF file name
                var pdfFileName = templateFile.Split("\\".ToArray(), StringSplitOptions.None).Last().Replace(".bulkpdf", "");

                // export file name
                var exportFileName = $"{Common.GetDisplayName(pickedCont)} - {pdfFileName}";
                outFileNames.Add(exportFileName); // todo: the actual file names

                var pdf = new PDF();
                pdf.Open(Path.Combine(dataFolderPath, pdfFileName));

                // fill the PDF file
                foreach (var field in pdfFields.Keys)
                {
                    if (pdfFields[field].UseValueFromDataSource)
                    {
                        var value = pickedCont[pdfFields[field].DataSourceValue];
                        pdf.SetFieldValue(field, value, pdfFields[field].MakeReadOnly);
                    }
                }

                // PDF
                pdf.SaveFilledPDF(Path.Combine(outFolderPath, exportFileName), false, false, false, "");
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

        public static string GetDisplayName(Dictionary<string, string> rec)
        {
            return $"{rec.Values.ToArray()[0]} {rec.Values.ToArray()[1]}";
        }

    }
}
