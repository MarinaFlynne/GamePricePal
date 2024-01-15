namespace Game_DB_Tool;

/// <summary>
/// The main class of the program. Gets parameters from the command line and runs the given query.
/// Uses the IsThereAnyDeal.com API https://itad.docs.apiary.io/
/// </summary>
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
            itadApiKey = config.itadApiKey;
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

        ItadApi itadApi = new ItadApi(itadApiKey);
        Arguments arguments = new Arguments(args);

        Query query = new Query(arguments, itadApi);
        await query.RunQuery();
    }
}