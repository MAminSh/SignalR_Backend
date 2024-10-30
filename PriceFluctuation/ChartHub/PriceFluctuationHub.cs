using Microsoft.AspNetCore.SignalR;

namespace PriceFluctuation.ChartHub;
public class PriceFluctuationHub : Hub
{
    private readonly Random random = new();

    public async Task SendPriceFluctuation()
    {
        int number;
        while (true)
        {
            number = random.Next(15, 100);
            await Clients.Caller.SendAsync("SendRandomFluctuation", number);
            await Task.Delay(10000);
        }
    }
}
