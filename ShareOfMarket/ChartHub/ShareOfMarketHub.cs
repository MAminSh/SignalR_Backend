using Microsoft.AspNetCore.SignalR;
using ShareOfMarket.Model;

namespace ShareOfMarket.ChartHub;
public class ShareOfMarketHub : Hub
{
    private static readonly double[] _originalValues = [40, 25, 19, 10, 4];
    private static readonly string[] _cryptocurrencyName = ["Bitcoin", "Tether", "Ethereum", "Solana", "Others"];
    private readonly Cryptocurrency[] _cryptocurrencies = new Cryptocurrency[5];
    private readonly Random _random = new();
    private static readonly double[] _modifiedValues = new double[_originalValues.Length];


    public async Task SendShareOfMarket()
    {
        while (true)
        {
            for (int i = 0; i < _originalValues.Length; i++)
            {
                double change = _random.NextDouble() * 25;
                double newValue = _originalValues[i] + (_originalValues[i] * change / 100);
                _modifiedValues[i] = Math.Round(newValue, 2);
                _cryptocurrencies[i] = new()
                {
                    name = _cryptocurrencyName[i],
                    y = _modifiedValues[i]
                };
            }

            await Clients.Caller.SendAsync("SendShareOfMarketData", _cryptocurrencies);
            await Task.Delay(5000);
        }
    }
}