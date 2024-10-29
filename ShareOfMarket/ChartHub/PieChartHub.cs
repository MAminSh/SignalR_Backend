using Microsoft.AspNetCore.SignalR;
using ShareOfMarket.Model;
using System.Text.Json;

namespace ShareOfMarket.ChartHub;
public class PieChartHub : Hub
{
    private static readonly double[] _originalValues = [40, 25, 19, 10, 6];
    private static readonly string[] _cryptocurrencyName = ["Bitcoin", "Tether", "Ethereum", "Solana", "Bnb"];
    private readonly List<Cryptocurrency> _cryptocurrencies = [];
    private readonly Random _random = new();
    private static readonly double[] _modifiedValues = new double[_originalValues.Length];


    public async Task SendRandomDataToPieChart()
    {
        while (true)
        {
            for (int i = 0; i < _originalValues.Length; i++)
            {
                double change = (_random.NextDouble() * 10) - 5;
                double newValue = _originalValues[i] + (_originalValues[i] * change / 100);
                _modifiedValues[i] = Math.Round(newValue, 2);
                _cryptocurrencies.Add(new Cryptocurrency
                {
                    Name = _cryptocurrencyName[i],
                    y = _modifiedValues[i]
                });
            }

            string jsonConvert = JsonSerializer.Serialize(_cryptocurrencies);
            Console.WriteLine($" Sending random number ");
            await Clients.All.SendAsync("SendRandomData", jsonConvert);
            await Task.Delay(5000);
        }
    }
}