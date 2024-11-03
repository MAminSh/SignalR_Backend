using Microsoft.AspNetCore.SignalR;
using ProfitablePerson.Models;

namespace ProfitablePerson.ChartHub;

public class ProfitablePersonHub : Hub
{
    private readonly Random _random;
    private readonly ProfitablePersonOption _profitablePersonOption;

    public ProfitablePersonHub(ProfitablePersonOption profitablePersonOption)
    {
        _random = new();
        _profitablePersonOption = profitablePersonOption;
    }

    public async Task SendProfitablePerson()
    {
        while (_profitablePersonOption.Names.Any())
        {
            int randomIndex = _random.Next(_profitablePersonOption.Names.Count());
            string randomName = _profitablePersonOption.Names[randomIndex];
            await Clients.Caller.SendAsync("SendProfName", randomName);
            await Task.Delay(_profitablePersonOption.Delay);
        }
    }
}
