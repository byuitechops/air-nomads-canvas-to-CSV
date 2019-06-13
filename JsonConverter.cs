using CanvasObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConverter
{
    public static class JsonToCsv
    {
        public static Quiz convertCourseJsonToObj(string JsonString)
        {
            JArray j = JArray.Parse(JsonString);
            Quiz quiz = JsonConvert.DeserializeObject<Quiz>(j[0].ToString().Replace("\r\n", "").Replace(System.Environment.NewLine, "").Replace("\r", ""));
            return quiz;
        }
    }
}