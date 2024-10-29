using Microsoft.AspNetCore.SignalR;

namespace GoldAndDollerAverage.ChartHub
{
    public class AvarageChartHub : Hub
    {
        private readonly int[] _gold = new int[10];
        private readonly int[] _doller = new int[10];
        private readonly Random random = new();

        public async Task SendRandomDataToAvarageChart()
        {
            while (true)
            {
                for (int i = 0; i < _gold.Length; i++)
                {
                    _doller[i] = random.Next(1, 20);
                    _gold[i] = random.Next(40, 60);
                }
                Console.WriteLine("Log From BarChart : ");
                Console.WriteLine($"Doller: [ {_doller[0]}, {_doller[1]}, {_doller[2]}, {_doller[3]}, {_doller[4]}, {_doller[5]}, {_doller[6]}, {_doller[7]}, {_doller[8]},{_doller[9]} ] ");
                Console.WriteLine($"Gold: [ {_gold[0]}, {_gold[1]}, {_gold[2]}, {_gold[3]}, {_gold[4]}, {_gold[5]}, {_gold[6]}, {_gold[7]}, {_gold[8]},{_gold[9]} ] ");
                await Clients.All.SendAsync("SendRandomData", _doller, _gold);
                await Task.Delay(10000);
            }
        }
    }
}
