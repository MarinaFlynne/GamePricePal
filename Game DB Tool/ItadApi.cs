namespace Game_DB_Tool;

using System;
using System.Net.Http;

public class ItadApi
{
    private readonly string baseUrl;

    public ItadApi(string baseUrl)
    {
        this.baseUrl = baseUrl;
    }
}