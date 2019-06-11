using System;
using System.IO;
using System.Threading.Tasks;

namespace air_nomads_canvas_to_CSV
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = @"C:\Users\lwargha\auth.txt";
            // string path = args[0];
            string text = System.IO.File.ReadAllText(path);
            var result = await HTTPHelper.MakeHttpAuthCall(text);
            System.Console.WriteLine(result);
        }
    }
}
