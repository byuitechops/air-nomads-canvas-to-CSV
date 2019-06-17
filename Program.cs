using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using JsonConverter;
using CanvasObjects;
using CanvasCoursestring;
using ClassToCsvConverter;

namespace air_nomads_canvas_to_CSV
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var run = true;
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
            string filename = promtFilename();

            string[] urls = urlList.ToArray();

            //System.Console.WriteLine("URL: " + url);

            // string url = "https://byui.instructure.com/api/v1/courses/47002/quizzes/585539/questions";

            var results = await HTTPHelper.MakeHttpAuthCallForEach(token, urls);

            var canvasCourses = JsonToCanvas<CanvasCourse>.convertJsonToCanvasObjectList(results);

            var csvString = ClassToCsv.convertToCSV<CanvasCourse>(canvasCourses, new string[] { "id", "name", "created_at", "license" });
            System.IO.File.WriteAllText("./filtered_output.csv", csvString);
        }

        static string promtFilename()
        {
            System.Console.WriteLine("Enter destination filename:");
            return Console.ReadLine();
        }


    }
}
