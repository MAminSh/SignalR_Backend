using Microsoft.AspNetCore.SignalR;

namespace Transaction.Hub;
public class SolidHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly Random random = new();

    public async Task SendRandomDataToSolidChart()
    {
        int number;
        while (true)
        {
            number = random.Next(0, 500);
            Console.WriteLine($"Sending random number: {number}");
            await Clients.All.SendAsync("RandomData", number);
            await Task.Delay(10000);
        }
    }
}
