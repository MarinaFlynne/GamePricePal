namespace Game_DB_Tool;

public class Arguments
{
    public string Command { get; }
    public string?[] Parameters { get; }

    public Arguments(string[] args)
    {
        Command = args[0];
        if (args.Length > 1)
        {
            Parameters = new string[args.Length - 1];
            for (int i = 0; i < args.Length - 1; i++)
            {
                Parameters[i] = args[i + 1];
            }
        }
    }
}