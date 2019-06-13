using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JsonConverter;
using CanvasObjects;
using CsvHelper;
namespace air_nomads_canvas_to_CSV
{
    class Program
    {


        static async Task Main(string[] args)
        {
            string token = Environment.GetEnvironmentVariable("API_TOKEN");
            string url = promtUrlEnpoint();
            string filename = promtFilename();

            System.Console.WriteLine("URL: " + url);

            // string url = "https://byui.instructure.com/api/v1/courses/47002/quizzes/585539/questions";

            var result = await HTTPHelper.MakeHttpAuthCall(token, url);
            var quizzez = JsonToCanvas<Quiz>.convertJsonToQuizList(result);
            var csvString = "";
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(quizzez);
                csvString =  (writer.ToString());
            }    
            System.Console.WriteLine(csvString);
        }

        static string promtUrlEnpoint()
        {
            System.Console.WriteLine("Enter the api endpoint:");
            return ("https://byui.instructure.com/" + Console.ReadLine());
        }

        static string promtFilename()
        {
            System.Console.WriteLine("Enter destination filename:");
            return Console.ReadLine();
        }
    }
}
