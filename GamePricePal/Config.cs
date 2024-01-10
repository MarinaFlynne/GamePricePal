using Newtonsoft.Json;

namespace Game_DB_Tool;

public class Config
{
    private string? itadApiKey;

    public Config(string configFilePath)
    {
        string configContent = File.ReadAllText(configFilePath);
        dynamic configObject = JsonConvert.DeserializeObject(configContent);
        itadApiKey = configObject.itadApiKey;
    }

    public string? getItadApiKey()
    {
        return itadApiKey;
    }
}