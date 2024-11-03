using Microsoft.AspNetCore.SignalR;
using ShareOfMarket.Models;

namespace ShareOfMarket.Hubs
{
    public class ShareOfMarketHub : Hub
    {

        private CryptoOption _cryptoOption;
        private readonly Cryptocurrency[] _cryptocurrencies;
        private readonly Random _random;
        public double[] _modifiedValues;


        public ShareOfMarketHub(CryptoOption cryptoOption)
        {
            _cryptoOption = cryptoOption;
            _cryptocurrencies = new Cryptocurrency[5];
            _modifiedValues = new double[_cryptoOption.OriginalValues.Count];
            _random = new();
        }

        public async Task SendShareOfMarket()
        {

            while (true)
            {
                for (int i = 0; i < _cryptoOption.OriginalValues.Count; i++)
                {
                    double change = _random.NextDouble() * 25;
                    double newValue = _cryptoOption.OriginalValues[i] + _cryptoOption.OriginalValues[i] * change / 100;
                    _modifiedValues[i] = Math.Round(newValue, 2);
                    _cryptocurrencies[i] = new()
                    {
                        Name = _cryptoOption.CryptocurrencyName[i],
                        Percent = _modifiedValues[i]
                    };
                    Console.WriteLine(_modifiedValues[i]);
                }

                await Clients.Caller.SendAsync("SendShareOfMarketData", _cryptocurrencies);
                await Task.Delay(5000);
            }
        }
    }
}