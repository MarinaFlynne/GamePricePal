using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;

// uses the IsThereAnyDeal.com API https://itad.docs.apiary.io/

namespace Game_DB_Tool
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            // Get the API key from the config json file
            // TODO make a config class
            // TODO make the tool ask for your API key on startup and save it in a config file
            string configFilePath = "Config.json";
            string itadApiKeyProperty = "itad_api_key";
            string configContent = File.ReadAllText(configFilePath);
            JsonDocument configDocument = JsonDocument.Parse(configContent);
            JsonElement root = configDocument.RootElement;
            string itadApiKey = "";
            if (root.TryGetProperty(itadApiKeyProperty, out JsonElement itadApiKeyElement))
            {
                itadApiKey = itadApiKeyElement.GetString();
            }
            else
            {
                Console.WriteLine($"ITAD API key not found in {configFilePath}");
            }
            
            
            
            var baseAddress = new Uri("https://api.isthereanydeal.com/");
            var httpClient = new HttpClient { BaseAddress = baseAddress };
            var title = "lethal company";
            var request = $"v02/game/plain/?key={itadApiKey}&title={title}";
            var response =
                await httpClient.GetAsync(request);
            string responseData = await response.Content.ReadAsStringAsync();
            
            dynamic responseObject = JsonConvert.DeserializeObject(responseData);
            string plainValue = responseObject.data.plain;
            Console.WriteLine(plainValue);
            
        }
    }
}

