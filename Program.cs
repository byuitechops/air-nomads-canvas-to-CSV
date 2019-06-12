using System;
using System.IO;
using System.Threading.Tasks;
using JsonConverter;

namespace air_nomads_canvas_to_CSV
{
    class Program
    {
        static async void authThinggy(){

            string pathToToken = @"C:\Users\lwargha\auth.txt";
            string url = "https://byui.instructure.com/api/v1/courses/47002/quizzes/585539/questions";
            // string path = args[0];
            string text = System.IO.File.ReadAllText(pathToToken);
            var result = await HTTPHelper.MakeHttpAuthCall(text, url);
            System.Console.WriteLine(result);

        }
        static void Main(string[] args)
        {
            var JSON = System.IO.File.ReadAllText("./test.json");
            Console.WriteLine(JSON);
            JSON_TO_CSV.getCSVFromJSON(JSON);
        }
        static void Main(string[] args)
        {
            var csv = JsonToCsv.convertCourseJsonToCsv(System.IO.File.ReadAllText("./test.json"));
            System.IO.File.WriteAllText("./test.csv", csv);
        }
    }
}
