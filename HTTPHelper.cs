using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace air_nomads_canvas_to_CSV
{
    internal static class HTTPHelper
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> MakeHttpAuthCall(string token)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                //Sets securely our canvas token to our http header
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //asynchronously makes a get request to the link we want to
                HttpResponseMessage response = await client.GetAsync("https://byui.instructure.com/api/v1/accounts/1/courses?by_subaccounts[]=96");
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

    }
}
