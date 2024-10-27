using Microsoft.AspNetCore.SignalR;

namespace TransactionSpeed.Hub;
public class SpeedometerHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly Random random = new();

    public async Task SendRandomDataToSpeedometerChart()
    {
        int number;
        while (true)
        {
            number = random.Next(0, 500);
            Console.WriteLine($"Sending random number: {number}");
            await Clients.All.SendAsync("RandomData", number);
            await Task.Delay(15000);
        }
    }
}
