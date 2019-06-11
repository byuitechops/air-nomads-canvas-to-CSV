using System;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using CsvHelper;
using System.Collections.Generic.Dictionary;
namespace JSON_TO_CSV_CONVERTER{
    public static class JSON_TO_CSV{
        public static string getCSVFromJSON(string jsonFile){
            string csv = "";
            var Dictionayz = JsonHelper.Deserialize(jsonFile);
            Console.WriteLine(Dictionayz.GetType());

            return csv;
        }
    }

    public static class JsonHelper
{
    public static object Deserialize(string json)
    {
        return ToObject(JToken.Parse(json));
    }

    private static Dictionary ToObject(JToken token)
    {
        switch (token.Type)
        {
            case JTokenType.Object:
                return token.Children<JProperty>()
                            .ToDictionary(prop => prop.Name,
                                          prop => ToObject(prop.Value));

            case JTokenType.Array:
                return token.Select(ToObject).ToList();

            default:
                return ((JValue)token).Value;
        }
    }
}

}