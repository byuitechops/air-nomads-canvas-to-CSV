using System.Collections.Generic;
using CanvasObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConverter
{
    public static class JsonToCsv
    {
        public static List<Quiz> convertJsonToQuizList(string JsonString)
        {
            JArray quizArray = JArray.Parse(JsonString);
            List<Quiz> quizzez = new List<Quiz>();
            foreach(var quiz in quizArray){
                quizzez.Add(convertToQuizObject(quiz.ToString()));
            }
            return quizzez;
        }
        public static Quiz convertToQuizObject(string quizObject){
            return JsonConvert.DeserializeObject<Quiz>(quizObject.Replace("\r\n", "").Replace(System.Environment.NewLine, "").Replace("\r", ""));
        }

    }
}