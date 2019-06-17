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

            // string token = args[0];
            // string url = "https://byui.instructure.com/api/v1/courses/47002/quizzes/585539/questions";
            // var result = await HTTPHelper.MakeHttpAuthCall(token, url);
            var quizzez = JsonToCanvas<Quiz>.convertJsonToQuizList(System.IO.File.ReadAllText("./test_quiz.json"));
            var csvString = ClassToCsv.convertToCSV<Quiz>(quizzez, new string[]{"id", "question_name", "incorrect_comments"});
            System.IO.File.WriteAllText("./filtered_output.csv", csvString);
        }
    }
}
