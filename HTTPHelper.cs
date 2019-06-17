using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace air_nomads_canvas_to_CSV
{
    internal static class HTTPHelper
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> MakeHttpAuthCall(string token, string url)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                //Sets securely our canvas token to our http header
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //asynchronously makes a get request to the link we want to
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                //stringfy the response
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                throw;
            }
        }

        public static async Task<string[]> MakeHttpAuthCallForEach(string token, string[] urls)
        {
            string[] responseBodies = new string[urls.GetLength(0)];

            for (int i = 0; i < urls.GetLength(0); i++)
            {
                try
                {
                    responseBodies[i] = await MakeHttpAuthCall(token, urls[i]);
                }
                catch (HttpRequestException e)
                {
                    System.Console.WriteLine("Error found in url #" + (i + 1) + ": {0}", e.Message);
                    throw;
                }


            }

            return responseBodies;
        }

    }
}
