using System.Collections.Generic;
using Newtonsoft.Json;
namespace JsonConverter
{
    public static class JsonToCanvas<T>
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        public static List<T> convertJsonToCanvasObjectList(string[] JsonString)
        {
            //JArray canvasObjectArray = new JArray();
            List<T> canvasObjects = new List<T>();
            foreach (var str in JsonString)
            {
                //System.Console.WriteLine(str);
                canvasObjects.Add(convertToCanvasObject(str));
            }
            return canvasObjects;
        }

        public static T convertToCanvasObject(string canvasObject)
        {
            return JsonConvert.DeserializeObject<T>(canvasObject.Replace("\r\n", "").Replace(System.Environment.NewLine, "").Replace("\r", ""), settings);
        }

    }
}