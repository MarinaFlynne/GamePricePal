namespace Game_DB_Tool;

/// <summary>
/// Represents arguments given to the command line.
/// </summary>
public class Arguments
{
    // The first argument given. Represents the command that the user would like to execute.
    public string Command { get; }

    //The rest of the given arguments. Represents the parameters that the user specifies for the command.
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