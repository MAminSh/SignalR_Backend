using GoldForecast.ChartHub;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp",
        builder =>
        {
            _ = builder
            .WithOrigins("Front URL Address")
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
app.MapHub<ForecastHub>("/forecasthub");
app.UseCors("ReactApp");
app.Run();

#endregion