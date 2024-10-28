using ProfitAndLoss.Hub;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

builder.Services.AddSignalR();
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
app.MapHub<BarHub>("/barhub");
app.UseCors("ReactApp");
app.Run();

#endregion
