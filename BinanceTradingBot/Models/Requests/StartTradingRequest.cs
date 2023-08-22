using Microsoft.VisualBasic;

namespace BinanceTradingBot.Models.Requests;

    public class StartTradingRequest
    {
        public string Symbol { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateInterval Interval { get; set; }
        public int Duration { get; set; }

    }