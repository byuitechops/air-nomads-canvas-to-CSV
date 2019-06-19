using CsvHelper;
using System.Dynamic;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ClassToCsvConverter
{
    public static class ClassToCsv
    {
        /* When no headers are specified, it creates a csv file for all headers */
        public static string convertToCSV(JArray csvData)
        {
            string csvOutput = "";
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer))
            {
            
            var firstObject = csvData[0];

            foreach (JProperty property in firstObject)
                csv.WriteField(property.Name);
            csv.NextRecord();

            foreach(var row in csvData){
                foreach(JProperty column in row){
                    csv.WriteField(column.Value.ToString());
                }
                csv.NextRecord();
            }

            writer.Flush();

            csvOutput = (writer.ToString());
            }
            return csvOutput;
        }

    }
}