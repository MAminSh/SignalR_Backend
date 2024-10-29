using Microsoft.AspNetCore.SignalR;

namespace ProfitAndLoss.ChartHub
{
    public class ProfitAndLossHub : Hub
    {
        private readonly int[] _joan = new int[3];
        private readonly int[] _jain = new int[3];
        private readonly Random random = new();

        public async Task SendProfitAndLoss()
        {
            while (true)
            {
                for (int i = 0; i < _joan.Length; i++)
                {
                    _joan[i] = random.Next(1, 7);
                    _jain[i] = random.Next(1, 7);
                }
                await Clients.All.SendAsync("SendProfitAndLossData", _joan, _jain);
                await Task.Delay(20000);
            }
        }
    }
}
