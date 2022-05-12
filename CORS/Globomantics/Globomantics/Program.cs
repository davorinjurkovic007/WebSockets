var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin()
//.AllowAnyMethod()
//.AllowAnyHeader()));

var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")?.Split(",") ?? new string[0];

builder.Services.AddCors(options => options.AddPolicy("GlobomaticsInternal", builder => builder.WithOrigins(allowedOrigins)));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("GlobomaticsInternal");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
