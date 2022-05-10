using System.Net.WebSockets;
using WebSocketServer.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebSocketManager();

var app = builder.Build();

app.UseWebSockets();

app.UseWebSocketServer();

app.Run(async context =>
{
    Console.WriteLine("Hello from the 3rd request delegate.");
    await context.Response.WriteAsync("Hello from the 3rd request delegate.");
});

app.Run();


//void WriteRequestParam(HttpContext context)
//{
//    Console.WriteLine("Request Method: " + context.Request.Method);
//    Console.WriteLine("request Protocol: " + context.Request.Protocol);

//    if(context.Request.Headers != null)
//    {
//        foreach(var h in context.Request.Headers)
//        {
//            Console.WriteLine("--> " + h.Key + " : " + h.Value);
//        }
//    }
//}





