using Microsoft.AspNetCore.SignalR;
using ShareOfMarket.Model;
using System.Text.Json;

namespace ShareOfMarket.ChartHub;
public class PieChartHub : Hub
{
    private static readonly double[] _originalValues = { 40, 25, 19, 10, 6 };
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
            }

            Cryptocurrency cryptocurrency = new()
            {
                Bitcoin = _modifiedValues[0],
                Tether = _modifiedValues[1],
                Ethereum = _modifiedValues[2],
                Solana = _modifiedValues[3],
                Bnb = _modifiedValues[4]
            };

            string jsonConvert = JsonSerializer.Serialize(cryptocurrency);
            Console.WriteLine($" Sending random number ");
            await Clients.All.SendAsync("SendRandomData", jsonConvert);
            await Task.Delay(5000);
        }
    }
}