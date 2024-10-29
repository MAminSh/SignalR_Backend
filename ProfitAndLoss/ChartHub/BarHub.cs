using Microsoft.AspNetCore.SignalR;

namespace ProfitAndLoss.ChartHub
{
    public class BarHub : Hub
    {
        private readonly int[] _joan = new int[3];
        private readonly int[] _jain = new int[3];
        private readonly Random random = new();

        public async Task SendRandomDataToBarChart()
        {
            while (true)
            {
                for (int i = 0; i < _joan.Length; i++)
                {
                    _joan[i] = random.Next(1, 7);
                    _jain[i] = random.Next(1, 7);
                }
                Console.WriteLine("Log From BarChart : ");
                Console.WriteLine($"Joan: [{_joan[0]}, {_joan[1]}, {_joan[2]}] ");
                Console.WriteLine($"Jain: [{_jain[0]}, {_jain[1]}, {_jain[2]}] ");
                await Clients.All.SendAsync("SendRandomData", _joan, _jain);
                await Task.Delay(10000);
            }
        }
    }
}
