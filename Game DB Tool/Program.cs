using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using Newtonsoft.Json;

// Uses the IsThereAnyDeal.com API https://itad.docs.apiary.io/

namespace Game_DB_Tool
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            // Get the API key from the config json file
            // TODO make a config class
            // TODO make the tool ask for your API key on startup and save it in a config file

            Config config = new Config("Config.json");
            string? itadApiKey = config.getItadApiKey();

            ItadApi itadApi = new ItadApi(itadApiKey);

            string? plain = await itadApi.GetPlainFromTitle("Elden ring");
            Console.WriteLine(plain);
            if (plain == null)
            {
                Console.WriteLine("Game does not exist.");
            }
            else
            {
                var prices = await itadApi.GetCurrentPrices(plain, "CA");
                Console.WriteLine(prices);
            }
            
            
        }
    }
}

