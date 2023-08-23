using BinanceTradingBot.Models.Requests;
using System.IO.Compression;
using System.Net;

namespace BinanceTradingBot.Models;

public class BinanceDataFetcher
{
    private const string BINANCE_URL = "https://data.binance.vision/data/spot/daily/klines/";
    private readonly string MARKET_DATA_FOLDER_PATH;

    public BinanceDataFetcher()
    {
        MARKET_DATA_FOLDER_PATH = GetMarketDataFolderPath();
    }

    public async Task<List<MarketData>> FetchAsync(FetchMarketDataRequest request)
    {
        var url = BuildUrl(request);
        var filePath = CreateFilePath(url);

        if (FileExists(filePath))
        {
            Console.WriteLine($"Reading Downloaded File From {filePath}");
            Console.WriteLine();
            return Read(filePath);
        }
        Console.WriteLine($"Fetching {url}");

        var zip = await FetchZip(url);
        var zipFileAsByteArr = await zip.Content.ReadAsByteArrayAsync();
        Console.WriteLine($"Completed Fetching {url} ");

        using var memoryStream = new MemoryStream(zipFileAsByteArr);
        using var archive = new ZipArchive(memoryStream);

        Console.WriteLine($"Saving {filePath}");
        Save(archive.Entries.First());
        Console.WriteLine($"Completed Saving {filePath}");
        Console.WriteLine();

        return Read(filePath);
    }

    private string GetMarketDataFolderPath()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        return $@"{projectDirectory}\MarketData\";
    }

    private bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    private string CreateFilePath(string url)
    {
        var fileName = url.Split('/').Last().Replace(".zip", ".csv");
        var path = Path.Combine(MARKET_DATA_FOLDER_PATH, fileName);
        return path;
    }

    private List<MarketData> Read(string filePath)
    {
        var list = new List<MarketData>();

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var info = line.Split(',');
            var data = new MarketData
            {
                OpenTimeStamp = info[0].ToLong().ToDateTime(),
                OpenPrice = info[1].ToDecimal(),
                HighestPrice = info[2].ToDecimal(),
                LowPrice = info[3].ToDecimal(),
                ClosePrice = info[4].ToDecimal(),
                Volume = info[5].ToDecimal(),
                CloseTimeStamp = info[6].ToLong().ToDateTime(),
                QuoteAssetVolume = info[7].ToDecimal(),
                NumberOfTrades = info[8].ToInt(),
                TakerBuyBaseAssetVolume = info[9].ToDecimal(),
                TakerBuyQuoteAssetVolume = info[10].ToDecimal(),
            };
            list.Add(data);
        }

        return list;
    }

    private string Save(ZipArchiveEntry entry)
    {
        var filePath = Path.Combine(MARKET_DATA_FOLDER_PATH, entry.Name);
        using var csvFileStream = File.Create(filePath);
        using var entryStream = entry.Open();
        entryStream.CopyTo(csvFileStream);
        return filePath;
    }

    private async Task<HttpResponseMessage> FetchZip(string url)
    {
        using var httpClient = new HttpClient();
        return await httpClient.GetAsync(url);
    }

    private string BuildUrl(FetchMarketDataRequest request)
    {
        var interval = $"{request.Duration}{request.Interval.ToString().ToLower()[0]}";
        var url = $"{request.Symbol}/{interval}/";
        var zipUrl = $"{request.Symbol}-{interval}-{request.Date:yyyy-MM-dd}";
        return $"{BINANCE_URL}{url}{zipUrl}.zip";
    }

}

