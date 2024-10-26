using SignalR_Back.Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

builder.Services.AddControllers();
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
builder.Services.AddSwaggerGen();

#endregion

WebApplication app = builder.Build();

#region Configure

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.MapHub<LineChartHub>("/LineChartHub");
app.MapHub<PieChartHub>("/PieChartHub");
app.MapHub<SolidHub>("/SolidHub");
app.MapHub<SpeedometerHub>("/SpeedometerHub");
app.MapHub<TextHub>("/TextHub");
app.UseCors("ReactApp");
app.Run();

#endregion