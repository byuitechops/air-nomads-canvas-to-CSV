using CsvHelper;
using System.Dynamic;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ClassToCsvConverter
{
    public static class ClassToCsv
    {
        /* Creates a new object only containing values which mactch the headers*/
        public static dynamic newObjectFromHeaders<T>(T oldObject, string[] headers)
        {
            dynamic newObject = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)newObject;
            oldObject.GetType().GetProperties()
                     .Where(property => headers.Any(selectorz => property.Name == selectorz)).ToList()
                     .ForEach(property => dictionary.Add(property.Name, property.GetValue(oldObject)));
            return newObject;
        }

        /*This creates a csv string with only containing fields under the headers mentioned in the array*/
        public static string convertToCSV<T>(List<T> ClassObjectList, string[] headers)
        {
            var newCanvasObjectList = ClassObjectList.Select<T, dynamic>((canvasObject) => { return newObjectFromHeaders(canvasObject, headers); }).ToList();
            return convertToCSV<dynamic>(newCanvasObjectList);
        }

        
        /* When no headers are specified, it creates a csv file for all headers */
        public static string convertToCSV<T>(List<T> ClassObjectList)
        {
            string csvOutput = "";
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(ClassObjectList);
                csvOutput = (writer.ToString());
            }
            return csvOutput;
        }

    }
}