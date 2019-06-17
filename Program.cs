using System;
using System.Threading.Tasks;
using JsonConverter;
using CanvasObjects;
using ClassToCsvConverter;
using System.Dynamic;
using System.Collections.Generic;

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
            var csvString = ClassToCsv.convertToCSV<Quiz>(quizzez, new string[]{"id", "question_name", "incorrect_comments"});
            System.IO.File.WriteAllText("./filtered_output.csv", csvString);
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
