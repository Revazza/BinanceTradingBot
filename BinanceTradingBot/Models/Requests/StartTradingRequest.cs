using BinanceTradingBot.Interfaces;
using Microsoft.VisualBasic;

namespace BinanceTradingBot.Models.Requests;

public class StartTradingRequest
{
    public string Symbol { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateInterval Interval { get; set; }
    public int Duration { get; set; }
    public IExchange Exchange { get; set; } = null!;
    public ITradingStrategy Strategy { get; set; } = null!;

}