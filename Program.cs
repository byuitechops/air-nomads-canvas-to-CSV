using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using JsonConverter;
using CanvasCoursestring;
using ClassToCsvConverter;

namespace air_nomads_canvas_to_CSV
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string fileOutput = "";
            string token = Environment.GetEnvironmentVariable("API_TOKEN");

            string[] urls = Prompter.promptEndpoints().ToArray();
            if (urls.Length == 0)
            {
                return;
            }
            else
            {
                fileOutput = Prompter.promptFilename();
            }

            var results = await HTTPHelper.MakeHttpAuthCallForEach(token, urls);
            var canvasCourses = JsonToCanvas<CanvasCourse>.convertJsonToCanvasObjectList(results);

            var csvString = ClassToCsv.convertToCSV<CanvasCourse>(canvasCourses, new string[] { "id", "name", "created_at", "license" });
            System.IO.File.WriteAllText(fileOutput, csvString);
        }


    }
}
