using CanvasObjects;
using Newtonsoft.Json;
using System.Reflection;
using System;
using System.Collections.Generic;
namespace JsonConverter{
    public static class JsonToCsv{
        public static string convertCourseJsonToCsv(string JsonString){
            
            var course = JsonConvert.DeserializeObject<CourseObject>(JsonString);
            System.Console.WriteLine(course.id);
            return compressToCsv(course);
        }

        private static string compressToCsv(CourseObject course){
            
            System.Console.WriteLine(course.GetType().GetProperties()[0].Name);
            List<string> headers = new List<string>();
            List<string> values = new List<string>();
            foreach(var field in course.GetType().GetProperties()){
                headers.Add(field.Name);
                values.Add($"{field.GetValue(course, null)}");
            }
            var headerLine = string.Join(",",headers.ToArray());
            var dataLine = string.Join(",", values);
            return string.Join("\n", new string[]{headerLine, dataLine});
        }
    }
}