namespace Game_DB_Tool;

public class Price
{
    public double priceNew { get; set; }
    public double priceOld { get; set; }
    public double priceCut { get; set; }
    public string shopId { get; set; }

    public Price(double priceNew, double priceOld, double priceCut, string shopId)
    {
        this.priceNew = priceNew;
        this.priceOld = priceOld;
        this.priceCut = priceCut;
        this.shopId = shopId;
    }

    public override string ToString()
    {
        return $"new: {priceNew} | old: {priceOld} | cut: {priceCut}% | shop id: {shopId}";
    }
}