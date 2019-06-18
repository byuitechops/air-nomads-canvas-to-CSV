using System.Collections.Generic;
using System;

namespace air_nomads_canvas_to_CSV
{
    static class Prompter
    {
        public static List<string> promptEndpoints()
        {
            var run = true;
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
            return urlList;
        }

        public static string promptFilename()
        {
            System.Console.WriteLine("Enter destination filename:");
            return Console.ReadLine();
        }
    }
}