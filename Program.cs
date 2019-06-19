﻿using System;
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
            var Objects = results.ToList().Select(result => {return JArray.Parse( (!result.EndsWith("]")) ? $"[{result}]" : result);}).ToList();
            var csvStringz = Objects.Select<JArray, string>(objectz => {return ClassToCsvConverter.ClassToCsv.convertToCSV(objectz);}).ToList();
            System.Console.WriteLine(string.Join("\n\n\n\n\n\n\n\n\n\n\n\n", results));
            for(var i = 0; i < csvStringz.Count; i ++)
                System.IO.File.WriteAllText("./output/"+fileOutput+"_"+i+".csv", csvStringz[i]);
        }


    }
}
