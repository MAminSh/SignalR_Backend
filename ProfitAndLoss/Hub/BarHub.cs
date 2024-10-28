using Microsoft.AspNetCore.SignalR;

namespace ProfitAndLoss.Hub
{
    public class BarHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly int[] _joan = new int[3];
        private readonly int[] _jain = new int[3];
        private readonly Random random = new();

        public async Task SendRandomDataToBarChart()
        {
            while (true)
            {
                for (int i = 0; i < _joan.Length - 1; i++)
                {
                    _joan[i] = random.Next(0, 7);
                    _jain[i] = random.Next(0, 7);
                }
                Console.WriteLine("".PadRight(70, '-'));
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Log From BarChart : ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Joan: [{_joan[0]}, {_joan[1]}, {_joan[2]}] ");
                Console.Write($"Jain: [{_jain[0]}, {_jain[1]}, {_jain[2]}] ");
                Console.ForegroundColor = ConsoleColor.White;
                await Clients.All.SendAsync("SendRandomDataToBarChart", _joan, _jain);
                await Task.Delay(10000);
            }
        }
    }
}
