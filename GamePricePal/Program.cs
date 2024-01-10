// Uses the IsThereAnyDeal.com API https://itad.docs.apiary.io/

namespace Game_DB_Tool;

internal class Program
{
    private const string configFilePath = "Config.json";

    private static async Task Main(string[] args)
    {
        string? itadApiKey = null;

        // Check if a config file exists
        if (File.Exists("Config.json"))
        {
            var config = new Config("Config.json");
            itadApiKey = config.getItadApiKey();
        }
        else
        {
            Console.WriteLine("Enter your IsThereAnyDeal API key:");
            itadApiKey = Console.ReadLine();
            while (itadApiKey == null || itadApiKey.Length != 40)
            {
                Console.WriteLine("Invalid API key. Please enter a valid API key");
                itadApiKey = Console.ReadLine();
            }
        }


        // var config = new Config("Config.json");
        // var itadApiKey = config.getItadApiKey();

        ItadApi itadApi = new ItadApi(itadApiKey);
        Arguments arguments = new Arguments(args);

        Query query = new Query(arguments, itadApi);
        await query.RunQuery();


        // Console.WriteLine("Enter the title of the game to retrieve prices for:");
        // string? title = null;
        // title = Console.ReadLine();
        // while (title == null)
        // {
        //     Console.WriteLine("Title cannot be empty, please try again.");
        //     title = Console.ReadLine();
        // }


        // var plain = await itadApi.GetPlainFromTitle(title);
        // Console.WriteLine(plain);
        //
        // if (plain == null)
        // {
        //     Console.WriteLine("Game does not exist.");
        //     return;
        // }
        //
        // Price[]? prices = await itadApi.GetCurrentPrices(plain, "CA");
        //
        // if (prices == null || prices.Length == 0)
        // {
        //     Console.WriteLine("No prices found.");
        //     return;
        // }
        //
        // foreach (Price price in prices)
        // {
        //     Console.WriteLine(price);
        // }
    }
}