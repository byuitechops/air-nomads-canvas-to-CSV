using CsvHelper;
using System.Dynamic;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;

namespace CanvasToCsvConverter
{
    public static class CanvasToCsv{

        /*
         * Creates a new object only containing values which mactch the headers
         */
        public static dynamic newObjectFromHeaders<T>(T oldObject, string[] headers){
            dynamic newObject = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)newObject;
            foreach(var field in oldObject.GetType().GetProperties()){
                if(Array.Exists(headers, element => element == field.Name))
                    dictionary.Add(field.Name, field.GetValue(oldObject));
            }
            return newObject;
        }
        
        /*
         * This creates a csv string with only containing fields under the headers mentioned in the array
         */
        public static string convertToCSV<T>(List<T> CanvasObjectList, string[] headers){
            string csvOutput = "";
            var newCanvasObjectList = CanvasObjectList.Select<T, dynamic>( (canvasObject) => {return newObjectFromHeaders(canvasObject, headers);});
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(newCanvasObjectList);
                csvOutput =  (writer.ToString());
            }    
            return csvOutput;
        }

        /*
         * When no headers are specified, it creates a csv file for all headers
         */
        public static string convertToCSV<T>(List<T> CanvasObject){
            string csvOutput = "";
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(CanvasObject);
                csvOutput =  (writer.ToString());
            }    
            return csvOutput;
        }


    }
}