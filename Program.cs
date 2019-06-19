using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


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
            System.Console.WriteLine(results[0]);
            var Objects = JArray.Parse( (!results[0].EndsWith("]")) ? $"[{results[0]}]" : results[0]);
            var csvString = ClassToCsvConverter.ClassToCsv.convertToCSV(Objects);
            System.IO.File.WriteAllText(fileOutput, csvString);
        }


    }
}
