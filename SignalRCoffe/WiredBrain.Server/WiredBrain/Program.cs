using WiredBrain.Helpers;
using WiredBrain.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new Random());
builder.Services.AddSingleton<OrderChecker>();

builder.Services.AddCors();
builder.Services.AddSignalR();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins("null")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseAuthorization();

app.MapHub<CoffeeHub>("/caffeHub");

app.MapControllers();

app.Run();

