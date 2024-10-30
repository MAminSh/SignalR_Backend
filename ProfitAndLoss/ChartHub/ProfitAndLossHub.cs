using Microsoft.AspNetCore.SignalR;

namespace ProfitAndLoss.ChartHub
{
    public class ProfitAndLossHub : Hub
    {
        private readonly double[] _buy = new double[3];
        private readonly double[] _sale = new double[3];
        private readonly Random random = new();


        public async Task SendProfitAndLoss()
        {
            while (true)
            {
                for (int i = 0; i < _buy.Length; i++)
                {
                    _buy[i] = random.Next(3, 5);
                    _sale[i] = random.Next(3, 5);
                }
                await Clients.Caller.SendAsync("SendProfitAndLossData", _buy, _sale);
                await Task.Delay(20000);
            }
        }
    }
}
