using Microsoft.AspNetCore.SignalR;

namespace ProfitablePerson.ChartHub;

public class ProfitablePersonHub : Hub
{
    private readonly Random _random;
    private readonly List<string> _names;
    private readonly int _delay;

    public ProfitablePersonHub(IConfiguration configuration, Random random)
    {
        _random = random;
        _names = configuration.GetSection("ProfitablePerson:Names").Get<List<string>>() ?? [];
        _delay = configuration.GetValue<int>("ProfitablePerson:Delay", 2000);
    }

    public async Task SendProfitablePerson()
    {
        while (_names.Count > 0)
        {
            int randomIndex = _random.Next(_names.Count);
            string randomName = _names[randomIndex];
            await Clients.Caller.SendAsync("SendProfName", randomName);
            await Task.Delay(_delay);
        }
    }
}
