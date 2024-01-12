﻿namespace Game_DB_Tool;

public class Query
{
    private Arguments arguments;
    private string command;
    private string?[] parameters;
    private ItadApi itadApi;

    public Query(Arguments arguments, ItadApi itadApi)
    {
        this.arguments = arguments;
        command = arguments.Command;
        parameters = arguments.Parameters;
        this.itadApi = itadApi;
    }

    public async Task RunQuery()
    {
        switch (command)
        {
            case "prices":
                await Prices();
                break;
            case "info":
                await GameInfo();
                break;
            default:
                // if the user does not enter in a correct command
                InvalidQuery();
                break;
        }
    }

    private void InvalidQuery()
    {
        Console.WriteLine("Invalid query. Type 'help' to get a list of commands.");
    }

    // Given the title of the game, get the prices for it
    private async Task Prices()
    {
        // Make sure the parameters list has at least 1 parameter
        if (parameters == null || parameters.Length == 0)
        {
            InvalidQuery();
            return;
        }

        string title = parameters[0]!; //parameters cannot be null; has at least 1 element
        for (int i = 1; i < parameters.Length; i++)
        {
            title += " " + parameters[i];
        }

        // Get the plain from the API
        var plain = await itadApi.GetPlainFromTitle(title);
        if (plain == null)
        {
            Console.WriteLine("Game does not exist.");
            return;
        }

        // Get prices from the API
        Price[]? prices = await itadApi.GetCurrentPrices(plain, "CA");

        if (prices == null || prices.Length == 0)
        {
            Console.WriteLine("No prices found.");
            return;
        }

        // Get the title of the game
        Game game = await itadApi.GameInfo(plain);
        string gameTitle = game.title;

        Console.WriteLine($"Here are all the prices for {gameTitle}");
        foreach (Price price in prices)
        {
            Console.WriteLine(price);
        }
    }

    // Given the title of the game, get its information
    private async Task GameInfo()
    {
        // Make sure the parameters list has at least 1 parameter
        if (parameters == null || parameters.Length == 0)
        {
            InvalidQuery();
            return;
        }

        string title = parameters[0]!; //parameters cannot be null; has at least 1 element
        for (int i = 1; i < parameters.Length; i++)
        {
            title += " " + parameters[i];
        }

        // Get the plain from the API
        var plain = await itadApi.GetPlainFromTitle(title);
        if (plain == null)
        {
            Console.WriteLine("Game does not exist.");
            return;
        }

        Game game = await itadApi.GameInfo(plain);
        Console.WriteLine(game.ToString());
    }
}