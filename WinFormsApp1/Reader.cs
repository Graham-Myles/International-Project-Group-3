using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Reader
    {

        public static void Main()
        {
            List<String[]> fileContent = new List<string[]>();

            using (FileStream reader = File.OpenRead(@"Downloads\WorkSmartDataCapture.txt")) 
            using (TextFieldParser parser = new TextFieldParser(reader))
            {
                parser.TrimWhiteSpace = true; // if you want
                parser.Delimiters = new[] { "," };
                parser.HasFieldsEnclosedInQuotes = true;
                while (!parser.EndOfData)
                {
                    string[] line = parser.ReadFields();
                    fileContent.Add(line);
                }
            }

            
        }

    }
}