
using ShareOfMarket.Hubs;
using ShareOfMarket.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

builder.Services.AddSignalR();
var cryptoShareOption = builder.Configuration.GetSection("CryptoShareOption").Get<CryptoOption>();

if (cryptoShareOption is not null)
    builder.Services.AddSingleton(cryptoShareOption);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp",
        builder =>
        {
            _ = builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});
builder.Services.AddEndpointsApiExplorer();

#endregion

WebApplication app = builder.Build();

#region Configure



app.UseAuthorization();
app.MapHub<ShareOfMarketHub>("/pieChartHub");
app.UseCors("ReactApp");
app.Run();

#endregion