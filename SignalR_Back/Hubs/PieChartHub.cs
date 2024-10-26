using Microsoft.AspNetCore.SignalR;

namespace SignalR_Back.Hubs;
public class PieChartHub : Hub
{
    private readonly Random random = new();

    /// <summary>
    /// This Data Chart Is Updated Every 5 Second 
    /// </summary>
    /// <returns> Send Random Data To Pie Chart </returns>
    public async Task SendRandomDataToPieChart()
    {
        int number;
        while (true)
        {
            number = random.Next(0, 500);
            Console.WriteLine($"Sending random number: {number}");
            await Clients.All.SendAsync("RandomData", number);
            await Task.Delay(5000);
        }
    }
}
