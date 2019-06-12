using CanvasObjects;
using Newtonsoft.Json;
using System.Reflection;
using System;
namespace JsonConverter{
    public static class JsonToCsv{
        public static string convertCourseJsonToCsv(string JsonString){
            
            var course = JsonConvert.DeserializeObject<CourseObject>(JsonString);
            System.Console.WriteLine(course.id);
            compressToCsv(course);
            return "";
        }

        private static string compressToCsv(CourseObject course){
            BindingFlags bindingFlags = BindingFlags.Public |
                            BindingFlags.NonPublic |
                            BindingFlags.Instance |
                            BindingFlags.Static;
            System.Console.WriteLine(typeof(CourseObject).GetFields(bindingFlags)[0].Name);
            foreach(FieldInfo field in typeof(CourseObject).GetFields(bindingFlags)){
                Console.WriteLine(field.Name);
            }
            return "";
        }
    }
}