using System.Collections.Generic;
using CanvasObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace JsonConverter
{
    public static class JsonToCanvas<T>
    {
        public static List<T> convertJsonToQuizList(string JsonString)
        {
            JArray quizArray = JArray.Parse(JsonString);
            List<T> canvasObjects = new List<T>();
            foreach(var canvasObject in quizArray){
                canvasObjects.Add(convertToQuizObject(canvasObject.ToString()));
            }
            return canvasObjects;
        }
        public static T convertToQuizObject(string quizObject){
            return JsonConvert.DeserializeObject<T>(quizObject.Replace("\r\n", "").Replace(System.Environment.NewLine, "").Replace("\r", ""));
        }

    }
}