namespace BinanceTradingBot;

public static class Extenstions
{

    public static long ToLong(this string str)
    {
        if(long.TryParse(str, out var result))
        {
            return result;
        }
        return -1;
    }

    public static DateTime ToDateTime(this long timeStamp)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(timeStamp).UtcDateTime;
    }
    
    public static decimal ToDecimal(this string str)
    {
        if (decimal.TryParse(str, out decimal result))
        {
            return result;
        }
        return -1;
    }

    public static int ToInt(this string str)
    {
        if (int.TryParse(str, out int result))
        {
            return result;
        }
        return -1;
    }

    public static void Display(this IEnumerable<object> list)
    {
        foreach (object obj in list)
        {
            Console.WriteLine(obj);
        }
        Console.WriteLine();
    }

}