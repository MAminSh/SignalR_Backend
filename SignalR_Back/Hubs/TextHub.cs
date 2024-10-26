﻿using Microsoft.AspNetCore.SignalR;

namespace SignalR_Back.Hubs;
public class TextHub : Hub
{
    private readonly Random random = new();
    private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";

    public void SendRandomText()
    {
        string result = new(Enumerable.Repeat(CHARS, 10)
             .Select(s => s[random.Next(0, 69)]).ToArray());
    }
}
