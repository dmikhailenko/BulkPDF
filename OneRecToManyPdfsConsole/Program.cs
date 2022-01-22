using BulkPDF;
using OneRecToManyPdfsCore;
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

        static void Main(string[] args)
        {
            try
            {

                //var curDir = Directory.GetCurrentDirectory();
                var dataFolderPath = Properties.Settings.Default.DataFolderPath;
                var recordFileName = Properties.Settings.Default.RecordFileName;

                dataSource = new Spreadsheet();
                var myRecs = Common.GetMyRecords(Path.Combine(dataFolderPath, recordFileName), dataSource);

                var pickedRec = PickRecord(myRecs);

                if (pickedRec == null)
                {
                    Console.WriteLine("Not a valid number. See ya...");
                    Environment.Exit(0);
                }

                // list all templates
                var templateFiles = Directory.GetFiles(dataFolderPath, "*.bulkpdf");
                Console.Write(string.Join("\n", templateFiles.Select(x => x.Split("\\".ToArray()).Last().Replace(".bulkpdf", ""))));
                Console.WriteLine();

                // fill all templates
                string outFolderPath;
                List<String> files = Common.FillTemplatesWithSingleRecord(pickedRec, dataFolderPath, templateFiles, out outFolderPath);

                // todo: pick templates

                // open the new folder
                Process.Start("explorer.exe", outFolderPath);

            }
            catch (Exception)
            {
                Console.ReadLine();
            }
            
        }


        private static Dictionary<string, string> PickRecord(Dictionary<int, Dictionary<string, string>> myRecs)
        {
            foreach (var rec in myRecs)
            {
                var recLine = string.Empty;
                for (int fld = 0; fld < 2; fld++)
                {
                    recLine += rec.Value.Values.ToArray()[fld] + " ";
                }
                Console.WriteLine($"{rec.Key + 1}. {recLine}");
            }

            Console.WriteLine();

            Console.Write("Pick a contact: ");
            string pick = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(pick, out int contNum))
            {
                return myRecs[contNum - 1];
            }
            else
            {
                return null;
            }

        }

    }
}
