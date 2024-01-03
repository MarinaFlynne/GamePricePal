// Uses the IsThereAnyDeal.com API https://itad.docs.apiary.io/

namespace Game_DB_Tool;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var config = new Config("Config.json");
        var itadApiKey = config.getItadApiKey();

        var itadApi = new ItadApi(itadApiKey);

        var plain = await itadApi.GameLookup("Elden Ring");
        Console.WriteLine(plain);
        // if (plain == null)
        // {
        //     Console.WriteLine("Game does not exist.");
        // }
        // else
        // {
        //     var prices = await itadApi.GetCurrentPrices(plain, "CA");
        //     Console.WriteLine(prices);
        // }
    }
}