using Microsoft.AspNetCore.SignalR;

namespace SignalR_Back.Hubs;
public class LineChartHub : Hub
{
    private readonly Random random = new();

    /// <summary>
    /// This Data Chart Is Updated Every Second 
    /// </summary>
    /// <returns> Send Random Data To Line Chart </returns>
    public async Task SendRandomDataToLineChart()
    {
        int number;
        while (true)
        {
            number = random.Next(0, 500);
            Console.WriteLine($"Sending random number: {number}");
            await Clients.All.SendAsync("RandomData", number);
            await Task.Delay(1000);
        }
    }
}
