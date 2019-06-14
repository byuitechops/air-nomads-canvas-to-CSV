using System.Collections.Generic;
using CanvasObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace JsonConverter
{
    public static class JsonToCanvas<T>
    {
        public static List<T> convertJsonToCanvasObjectList(string[] JsonString)
        {
            //JArray canvasObjectArray = new JArray();
            List<T> canvasObjects = new List<T>();
            foreach (var str in JsonString)
            {
                System.Console.WriteLine(str);
                canvasObjects.Add(convertToCanvasObject(str));
            }
            return canvasObjects;
        }

        public static T convertToCanvasObject(string quizObject)
        {
            return JsonConvert.DeserializeObject<T>(quizObject.Replace("\r\n", "").Replace(System.Environment.NewLine, "").Replace("\r", ""));
        }


        // public static List<T> convertJsonToQuizList(string JsonString)
        // {
        //     JArray canvasObjectArray = JArray.Parse(JsonString);
        //     List<T> canvasObjects = new List<T>();
        //     foreach(var canvasObject in canvasObjectArray){
        //         canvasObjects.Add(convertToQuizObject(canvasObject.ToString()));
        //     }
        //     return canvasObjects;
        // }

        // public static T convertToQuizObject(string quizObject)
        // {
        //     return JsonConvert.DeserializeObject<T>(quizObject.Replace("\r\n", "").Replace(System.Environment.NewLine, "").Replace("\r", ""));
        // }

    }
}