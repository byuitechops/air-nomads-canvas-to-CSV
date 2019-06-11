using System;
using System.IO;
using System.Threading.Tasks;

namespace air_nomads_canvas_to_CSV
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string pathToToken = @"C:\Users\lwargha\auth.txt";
            string url = "https://byui.instructure.com/api/v1/courses/47002/quizzes/585539/questions";
            // string path = args[0];
            string text = System.IO.File.ReadAllText(pathToToken);
            var result = await HTTPHelper.MakeHttpAuthCall(text, url);
            System.Console.WriteLine(result);
        }
    }
}
