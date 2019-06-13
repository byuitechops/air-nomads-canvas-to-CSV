using System;
using System.IO;
using System.Threading.Tasks;
using JsonConverter;

namespace air_nomads_canvas_to_CSV
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string token = args[0];
            string url = "https://byui.instructure.com/api/v1/courses/47002/quizzes/585539/questions";
            var result = await HTTPHelper.MakeHttpAuthCall(token, url);
            Console.WriteLine(result);
            var csv = JsonToCsv.convertCourseJsonToCsv(result);
            System.IO.File.WriteAllText("./test.csv", csv);
        }
    }
}
