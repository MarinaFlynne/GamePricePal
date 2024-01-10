using Microsoft.VisualBasic;

namespace Game_DB_Tool;

using Newtonsoft.Json;

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