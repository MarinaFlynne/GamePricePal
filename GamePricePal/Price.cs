namespace Game_DB_Tool;

/// <summary>
/// Represents a price in a certain shop for a video game. Contains information about the old price and price cut, if the price is a sale.
/// </summary>
public class Price(double priceNew, double priceOld, double priceCut, string shopId)
{
    public double PriceNew { get; } = priceNew;
    public double PriceOld { get; } = priceOld;
    public double PriceCut { get; } = priceCut;
    public string ShopId { get; } = shopId;

    public override string ToString()
    {
        return $"new: {PriceNew} | old: {PriceOld} | price cut: {PriceCut}% | shop id: {ShopId}";
    }
}