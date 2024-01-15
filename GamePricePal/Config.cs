using Newtonsoft.Json;

namespace Game_DB_Tool;

/// <summary>
/// Represents the configuration of the program.
/// </summary>
public class Config
{
    public string? itadApiKey { get; }

    public Config(string configFilePath)
    {
        string configContent = File.ReadAllText(configFilePath);
        dynamic configObject = JsonConvert.DeserializeObject(configContent);
        itadApiKey = configObject.itadApiKey;
    }
}