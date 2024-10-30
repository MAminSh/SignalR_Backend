using Microsoft.AspNetCore.SignalR;

namespace GoldAndDollerAverage.ChartHub
{
    public class PriceAvgChartHub : Hub
    {
        private readonly int[] _gold = new int[10];
        private readonly int[] _doller = new int[10];
        private readonly Random random = new();

        public async Task SendGoldAndDollerAvg()
        {
            while (true)
            {
                for (int i = 0; i < _gold.Length; i++)
                {
                    _doller[i] = random.Next(1, 20);
                    _gold[i] = random.Next(40, 60);
                }             
                await Clients.Caller.SendAsync("SendDataAvg", _doller, _gold);
                await Task.Delay(5000);
            }
        }
    }
}
