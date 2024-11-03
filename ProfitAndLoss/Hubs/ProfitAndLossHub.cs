using Microsoft.AspNetCore.SignalR;

namespace ProfitAndLoss.ChartHub
{
    public class ProfitAndLossHub : Hub
    {
        private readonly double[] _buy;
        private readonly double[] _sale;
        private readonly Random _random;

        public ProfitAndLossHub()
        {
            _buy = new double[3];
            _sale = new double[3];
            _random = new();
        }

        public async Task SendProfitAndLoss()
        {
            while (true)
            {
                for (int i = 0; i < _buy.Length; i++)
                {
                    _buy[i] = _random.Next(3, 5);
                    _sale[i] = _random.Next(3, 5);
                }
                await Clients.Caller.SendAsync("SendProfitAndLossData", _buy, _sale);
                await Task.Delay(20000);
            }
        }
    }
}
