using Microsoft.AspNetCore.SignalR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProfitablePerson.Hub;
public class TextHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly Random random = new();
    private readonly List<string> names = new()
        {
            "علی", "حسین", "رضا", "فاطمه", "زهرا", "محمد", "سعید", "مجتبی", "ندا", "پریسا",
            "مینا", "سارا", "مهسا", "آرزو", "آرمان", "عاطفه", "مرضیه", "مریم", "الهام", "ندا",
            "بهزاد", "بهنام", "بهروز", "آرین", "شایان", "کیوان", "مهرداد", "کیارش", "رامین", "کاوه",
            "رها", "الهه", "ساحل", "سحر", "نرگس", "نسیم", "نیلوفر", "فرزانه", "فریبا", "فرشته",
            "شهریار", "آرش", "امیر", "آیدا", "فرهاد", "بابک", "داریوش", "پویان", "پگاه", "پرنیا",
            "تارا", "ترانه", "پونه", "سینا", "احمد", "امید", "پیمان", "سهیل", "سروش", "سجاد",
            "شهاب", "شهرام", "شیرین", "شمیم", "شیما", "شادی", "شیرزاد", "سپهر", "شبنم", "شیوا",
            "علی‌رضا", "علیرضا", "عصمت", "عفت", "کریم", "کیانوش", "کبری", "کیمیا", "یاسمین", "یلدا",
            "یگانه", "یسنا", "هومن", "هما", "هانیه", "هدا", "هلن", "وحید", "ویدا", "الهه", "هیراد",
            "یاسر", "یوسف", "وحید", "محسن", "منوچهر", "مهین", "سروش", "پیمان", "فرید", "فرشاد"
        };


    public async Task SendRandomText()
    {
        Console.WriteLine("".PadRight(70, '-'));
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        int randomIndex = random.Next(names.Count);
        string randomName = names[randomIndex];
        Console.WriteLine("Log From Text :");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($" The Value Is : {randomName} ");
        Console.ForegroundColor = ConsoleColor.White;
        await Clients.All.SendAsync("SendRandomText", randomName);
        await Task.Delay(1000);
    }
}
