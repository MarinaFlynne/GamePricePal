namespace Game_DB_Tool;

/// <summary>
/// Represents and contains information about a game.
/// </summary>
public class Game(string title, string id, bool isDlc, bool achievements, bool tradingCards)
{
    public readonly string Title = title;
    public readonly string Id = id;
    public readonly bool IsDlc = isDlc;
    public readonly bool Achievements = achievements;
    public readonly bool TradingCards = tradingCards;

    public override string ToString()
    {
        string str =
            $"title: {Title} | id: {Id} | isDlc: {IsDlc} | achievements: {Achievements} | tradingCards: {TradingCards}";
        return str;
    }
}