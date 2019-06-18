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
            var run = true;
             string fileOutput = "";
            string token = Environment.GetEnvironmentVariable("API_TOKEN");
            var urlList = new List<string>();
            System.Console.WriteLine("Enter course API endpoints (type 'exit' when done):");
            while (run)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    run = false;
                }
                else
                {
                    
                    urlList.Add("https://byui.instructure.com/" + input);
                }
            }
            string[] urls = urlList.ToArray();
            if (urls.Length == 0)
            {
                return;
            }
            else
            {
                fileOutput = promptFilename();
            }

            var results = await HTTPHelper.MakeHttpAuthCallForEach(token, urls);
            var canvasCourses = JsonToCanvas<CanvasCourse>.convertJsonToCanvasObjectList(results);

            var csvString = ClassToCsv.convertToCSV<CanvasCourse>(canvasCourses, new string[] { "id", "name", "created_at", "license" });
            System.IO.File.WriteAllText(fileOutput, csvString);
        }
        static string promptFilename()
        {
            System.Console.WriteLine("Enter destination filename:");
            return Console.ReadLine();
        }

    }
}
