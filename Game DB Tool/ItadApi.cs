namespace Game_DB_Tool;

using System;
using System.Net.Http;
using Newtonsoft.Json;

public class ItadApi
{
    private const string baseUrl = "https://api.isthereanydeal.com/";
    private HttpClient httpClient;
    private string apiKey;

    public ItadApi(string apiKey)
    {
        var baseAddress = new Uri(baseUrl);
        httpClient = new HttpClient { BaseAddress = baseAddress };
        this.apiKey = apiKey;
    }

    /// <summary>
    /// Retrieves the plain from the ITAD API based on the specified title.
    /// </summary>
    /// <param name="title">The title of the game to retrieve the plain for.</param>
    /// <returns>The plain associated with the specified game title. Null if no plain is found.</returns>
    public async Task<string?> GetPlainFromTitle(string title)
    {
        var request = $"v02/game/plain/?key={apiKey}&title={title}";
        
        // Await the GetAsync method to get the HttpResponseMessage
        var response = await httpClient.GetAsync(request);
        
        // Check if the request was successful (status code 200-299)
        response.EnsureSuccessStatusCode();
        
        // Read the content of the response as a string
        string responseData = await response.Content.ReadAsStringAsync();
        
        // Get an object representing the response
        dynamic responseObject = JsonConvert.DeserializeObject(responseData);
        
        // Check if the given title was not found in the ITAD database
        if (responseObject[".meta"]["match"] == false)
        {
            return null;
        }
        
        return responseObject.data.plain;
    }
    
    /// <summary>
    /// Retrieves all of the current prices for a game.
    /// </summary>
    /// <param name="plain">The plain of the game to retrieve the prices for.</param>
    /// <param name="region">The region to retrieve prices for.</param>
    /// <returns>The list of prices for the given game along with the corresponding store that sells at that price.</returns>
    public async Task<string?> GetCurrentPrices(string plain, string region)
    {
        var request = $"/v01/game/prices/?key={apiKey}&plains={plain}&region={region}";
        
        // Await the GetAsync method to get the HttpResponseMessage
        var response = await httpClient.GetAsync(request);
        
        // Check if the request was successful (status code 200-299)
        response.EnsureSuccessStatusCode();
        
        // Read the content of the response as a string
        string responseData = await response.Content.ReadAsStringAsync();
        
        Console.WriteLine(responseData);
        
        // Get an object representing the response
        // dynamic responseObject = JsonConvert.DeserializeObject(responseData);
        //
        // // Check if the given title was not found in the ITAD database
        // if (responseObject[".meta"]["match"] == false)
        // {
        //     return null;
        // }
        //
        // return responseObject.data.plain;

        return null;
    }
}