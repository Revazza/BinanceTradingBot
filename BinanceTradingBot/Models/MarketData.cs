namespace BinanceTradingBot.Models;

public class MarketData
{
    public string TimeStamp { get; set; } = null!;
    public decimal OpenPrice { get; set; }
    public decimal HighestPrice { get; set; }
    public decimal ClosePrice { get; set; }
    public decimal LowPrice { get; set; }
    public decimal Volume { get; set; }
    public string OpenTimeStamp { get; set; } = null!;
    public string CloseTimeStamp { get; set; } = null!;
    public decimal QuoteAssetVolume { get; set; }
    public int NumberOfTrades { get; set; }
    public decimal TakerBuyBaseAssetVolume { get; set; }
    public decimal TakerBuyQuoteAssetVolume { get; set; }

    public override string? ToString()
    {
        return $"TimeStamp: {TimeStamp}" +
            $"\nOpenPrice: {OpenPrice}" +
            $"\nHighestPrice: {HighestPrice}" +
            $"\nClosePrice: {ClosePrice}" +
            $"\nLowPrice: {LowPrice}" +
            $"\nVolume: {Volume}" +
            $"\nOpenTimeStamp: {OpenTimeStamp}" +
            $"\nCloseTimeStamp: {CloseTimeStamp}" +
            $"\nQuoteAssetVolume: {QuoteAssetVolume}" +
            $"\nNumberOfTrades: {NumberOfTrades}" +
            $"\nTakerBuyBaseAssetVolume: {TakerBuyBaseAssetVolume}" +
            $"\nTakerBuyQuoteAssetVolume: {TakerBuyQuoteAssetVolume}"+ "\n";
    }
}