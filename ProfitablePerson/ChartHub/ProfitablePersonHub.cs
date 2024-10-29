using Microsoft.AspNetCore.SignalR;

namespace ProfitablePerson.ChartHub;
public class ProfitablePersonHub : Hub
{
    private readonly Random random = new();
    private readonly List<string> names =
        [
            "Ali", "Hossein", "Reza", "Fatemeh", "Zahra", "Mohammad", "Saeed", "Mojtaba", "Neda", "Parisa",
            "Mina", "Sara", "Mahsa", "Arezoo", "Arman", "Atefeh", "Marzieh", "Maryam", "Elham", "Neda",
            "Behzad", "Behnam", "Behrooz", "Aryan", "Shayan", "Keyvan", "Mehrdad", "Kiarash", "Ramin", "Kaveh",
            "Raha", "Elaheh", "Sahel", "Sahar", "Narges", "Nasim", "Niloofar", "Farzaneh", "Fariba", "Fereshteh",
            "Shahryar", "Arash", "Amir", "Ayda", "Farhad", "Babak", "Daryoush", "Pouyan", "Pegah", "Parniya",
            "Tara", "Taraneh", "Pooneh", "Sina", "Ahmad", "Omid", "Peyman", "Soheil", "Soroosh", "Sajjad",
            "Shahab", "Shahram", "Shirin", "Shamin", "Shima", "Shadi", "Shirzad", "Sepehr", "Shabnam", "Shiva",
            "Ali-Reza", "Alireza", "Esmat", "Eftekhar", "Karim", "Kianoush", "Kabra", "Kimia", "Yasmin", "Yalda",
            "Yeganeh", "Yesna", "Hooman", "Homa", "Hanieh", "Hoda", "Helen", "Vahid", "Vida", "Elaheh", "Hirad",
            "Yasser", "Yousef", "Vahid", "Mohsen", "Manoochehr", "Mahin", "Soroosh", "Peyman", "Farid", "Farshad"
        ];

    public async Task SendProfitablePerson()
    {
        while (true)
        {
            int randomIndex = random.Next(names.Count);
            string randomName = names[randomIndex];
            await Clients.All.SendAsync("SendProfName", randomName);
            await Task.Delay(1000);
        }
    }
}
