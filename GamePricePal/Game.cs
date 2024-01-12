namespace Game_DB_Tool;

public class Game(string title, string id, bool isDlc, bool achievements, bool tradingCards)
{
    public string title = title;
    public string id = id;
    public bool isDlc = isDlc;
    public bool achievements = achievements;
    public bool tradingCards = tradingCards;

    public override string ToString()
    {
        string str =
            $"title: {title} | id: {id} | isDlc: {isDlc} | achievements: {achievements} | tradingCards: {tradingCards}";
        return str;
    }
}