using System;
using System.Net.Http;
namespace Powerev {
    public class JackpotDownloader {
        
        private const string POWERBALL_URL = "https://www.powerball.com";

        public static async Task<double> GetJackpot() {
            using (HttpClient client = new HttpClient()) {
                try {
                    var response = await client.GetAsync(POWERBALL_URL);

                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(content);

                    return 1.0;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error getting current jackpot: {e.Message}");
                    throw;
                }
            }
        }
    }
}
