namespace Game_DB_Tool;

public class Game
{
    private string title;
    private string id;
    private string type;
    private bool mature;
    private string releaseDate;

    public Game(string title, string id, string type, bool mature, string releaseDate)
    {
        this.title = title;
        this.id = id;
        this.type = type;
        this.mature = mature;
        this.releaseDate = releaseDate;
    }
}