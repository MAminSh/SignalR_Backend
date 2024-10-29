using Microsoft.AspNetCore.SignalR;

namespace ShareOfMarket.ChartHub;
public class PieChartHub : Hub
{
    private readonly Random random = new();


    public async Task SendRandomDataToPieChart()
    {
        int number;
        double bitcoin = 57;

        while (true)
        {
            number = random.Next(0, 500);
            Console.WriteLine($"Sending random number: {number}");
            await Clients.All.SendAsync("RandomData", number);
            await Task.Delay(5000);
        }
    }
}
