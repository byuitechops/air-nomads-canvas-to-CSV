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
            string token = args[0];
            string url = "https://byui.instructure.com/api/v1/courses/47002/quizzes/585539/questions";
            var result = await HTTPHelper.MakeHttpAuthCall(token, url);
            var quizzez = JsonToCsv.convertJsonToQuizList(result);
        
            using (var writer = new StreamWriter("quiz.csv"))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(quizzez);
            }
        }
    }
}
