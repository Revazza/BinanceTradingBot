using BinanceTradingBot.Interfaces;

namespace BinanceTradingBot.Models;

public class Exchange : IExchange
{
    private decimal StartingBalance { get; set; }
    public decimal Balance { get; private set; }
    public decimal Profit { get; set; }
    private decimal BoughtStockQuantity { get; set; }

    public Exchange(decimal balance)
    {
        Balance = StartingBalance = balance;
    }

    public void Buy(decimal stockPrice)
    {
        var quantity = (int)(Balance / stockPrice);

        Balance -= stockPrice * quantity;
        BoughtStockQuantity = quantity;
    }

    public void Sell(decimal stockPrice)
    {
        Balance += stockPrice * BoughtStockQuantity;
        BoughtStockQuantity = 0;
    }

    public decimal CalculateProfit()
    {
        Profit = Balance - StartingBalance;
        Console.WriteLine($"Profit: {Profit:N3}$");
        return Profit;
    }

}