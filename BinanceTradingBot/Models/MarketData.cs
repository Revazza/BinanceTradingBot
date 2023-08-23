namespace BinanceTradingBot.Models;

public class MarketData
{
    public DateTime OpenTimeStamp { get; set; } 
    public decimal OpenPrice { get; set; }
    public decimal HighestPrice { get; set; }
    public decimal LowPrice { get; set; }
    public decimal ClosePrice { get; set; }
    public decimal Volume { get; set; }
    public DateTime CloseTimeStamp { get; set; } 
    public decimal QuoteAssetVolume { get; set; }
    public int NumberOfTrades { get; set; }
    public decimal TakerBuyBaseAssetVolume { get; set; }
    public decimal TakerBuyQuoteAssetVolume { get; set; }

    public override string? ToString()
    {
        
        return $"Open TimeStamp: {OpenTimeStamp}" +
            $"\nOpenPrice: {OpenPrice}" +
            $"\nHighestPrice: {HighestPrice}" +
            $"\nClosePrice: {ClosePrice}" +
            $"\nLowPrice: {LowPrice}" +
            $"\nVolume: {Volume}" +
            $"\nCloseTimeStamp: {CloseTimeStamp}" +
            $"\nQuoteAssetVolume: {QuoteAssetVolume}" +
            $"\nNumberOfTrades: {NumberOfTrades}" +
            $"\nTakerBuyBaseAssetVolume: {TakerBuyBaseAssetVolume}" +
            $"\nTakerBuyQuoteAssetVolume: {TakerBuyQuoteAssetVolume}"+ "\n";
    }
}