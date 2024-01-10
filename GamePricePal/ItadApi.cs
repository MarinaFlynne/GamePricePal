﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Game_DB_Tool;

public class ItadApi
{
    private const string baseUrl = "https://api.isthereanydeal.com/";
    private readonly string apiKey;
    private readonly HttpClient httpClient;

    public ItadApi(string apiKey)
    {
        var baseAddress = new Uri(baseUrl);
        httpClient = new HttpClient { BaseAddress = baseAddress };
        this.apiKey = apiKey;
    }

    /// <summary>
    ///     Requests data from the ITAD API using the given request query.
    /// </summary>
    /// <param name="request">The URL for the request.</param>
    /// <returns>The deserialized JSON object representing the response.</returns>
    public async Task<dynamic?> ApiRequest(string request)
    {
        // Await the GetAsync method to get the HttpResponseMessage
        var response = await httpClient.GetAsync(request);

        // Check if the request was successful (status code 200-299)
        response.EnsureSuccessStatusCode();

        // Read the content of the response as a string
        var responseData = await response.Content.ReadAsStringAsync();

        // Get an object representing the response
        dynamic? responseObject = JsonConvert.DeserializeObject(responseData);

        return responseObject;
    }

    /// <summary>
    ///     Retrieves the plain from the ITAD API based on the specified title.
    /// </summary>
    /// <param name="title">The title of the game to retrieve the plain for.</param>
    /// <returns>The plain associated with the specified game title. Null if no plain is found.</returns>
    public async Task<string?> GetPlainFromTitle(string title)
    {
        var request = $"v02/game/plain/?key={apiKey}&title={title}";

        // Get an object representing the response
        dynamic? responseObject = await ApiRequest(request);

        // Check if the given title was not found in the ITAD database


        return responseObject.data.plain;
    }


    // /// <summary>
    // ///     Retrieves the plain from the ITAD API based on the specified title.
    // /// </summary>
    // /// <param name="title">The title of the game to retrieve the plain for.</param>
    // /// <returns>The plain associated with the specified game title. Null if no plain is found.</returns>
    // public async Task<string?> GameLookup(string title)
    // {
    //     var request = $"games/lookup/v1/?key={apiKey}&title={title}";
    //
    //     // Get an object representing the response
    //     dynamic? responseObject = await ApiRequest(request);
    //
    //     // Check if the given title was not found in the ITAD database
    //     if (responseObject.found == false)
    //     {
    //         return null;
    //     }
    //
    //     return responseObject.data.game.slug;
    // }

    /// <summary>
    ///     Retrieves all of the current prices for a game.
    /// </summary>
    /// <param name="plain">The plain of the game to retrieve the prices for.</param>
    /// <param name="region">The region to retrieve prices for.</param>
    /// <returns>The list of prices for the given game along with the corresponding store that sells at that price.</returns>
    public async Task<Price[]?> GetCurrentPrices(string plain, string region)
    {
        var request = $"/v01/game/prices/?key={apiKey}&plains={plain}&region={region}";

        // Get an object representing the response
        dynamic? responseObject = await ApiRequest(request);

        // Get an array of the list of different prices for the video game
        var listOfPrices =
            (JArray)responseObject["data"][plain]["list"];

        // For each price, create a Price object, and add that object to our array
        Price[] prices = new Price[listOfPrices.Count];
        int iterations = 0;
        foreach (JObject priceObject in listOfPrices)
        {
            var priceNew = (double)priceObject["price_new"];
            var priceOld = (double)priceObject["price_old"];
            var priceCut = (double)priceObject["price_cut"];
            var shopId = (string)priceObject["shop"]["id"];
            Price price = new Price(priceNew, priceOld, priceCut, shopId);
            // Console.WriteLine(price.ToString());
            prices[iterations] = price;
            iterations++;
        }

        return prices;
    }

    /// <summary>
    ///     Retrieves all of the current prices for a game.
    /// </summary>
    /// <param name="plain">The plain of the game to retrieve the prices for.</param>
    /// <param name="region">The region to retrieve prices for.</param>
    /// <returns>The list of prices for the given game along with the corresponding store that sells at that price.</returns>
    public async Task<Array[]> GameSearch(string title)
    {
        return null;
    }
}