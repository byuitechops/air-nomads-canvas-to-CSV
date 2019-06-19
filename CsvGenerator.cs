using CsvHelper;

using System.IO;
using Newtonsoft.Json.Linq;
using System;

namespace CsvGenerator
{
    public static class ClassToCsv
    {
        /* When no headers are specified, it creates a csv file for all headers */

        public static string convertToCSV(JArray csvData, string[] headers)
        {
            string csvOutput = "";
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer))
            {

                var firstObject = csvData[0];
                foreach (JProperty property in firstObject)
                    if(Array.Exists(headers, item => item == property.Name))
                        csv.WriteField(property.Name);
                csv.NextRecord();

                foreach (var row in csvData)
                {
                    foreach (JProperty column in row)
                    {
                        if(Array.Exists(headers, item => item == column.Name))
                            csv.WriteField(column.Value.ToString());
                    }
                    csv.NextRecord();
                }

                writer.Flush();

                csvOutput = (writer.ToString());
            }
            return csvOutput;
        }

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

                foreach (var row in csvData)
                {
                    foreach (JProperty column in row)
                    {
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