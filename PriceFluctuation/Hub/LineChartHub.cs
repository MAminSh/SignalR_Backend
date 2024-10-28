using Microsoft.AspNetCore.SignalR;

namespace PriceFluctuation.Hub;
public class LineChartHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly Random random = new();

    public async Task SendRandomDataToLineChart()
    {
        int number;
        while (true)
        {
            number = random.Next(0, 100);
            Console.WriteLine("".PadRight(70, '-'));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Log From LineChart :");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" Sending Random Data Is : {number} ");
            Console.ForegroundColor = ConsoleColor.White;
            await Clients.All.SendAsync("SendRandomDataToLineChart", number);
            await Task.Delay(5000);
        }
    }
}
