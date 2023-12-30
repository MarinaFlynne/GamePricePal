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

