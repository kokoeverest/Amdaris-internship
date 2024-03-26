using Amdaris.Logging;
using Amdaris.Logging.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI /IoC container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAmdarisLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/di", (AmdarisLogger logger) => 
{
    string message = "Hello, Amdaris! Logged using DI";
    logger.LogMessage(message);
    return message;
});

app.MapGet("/sl", (IServiceProvider serviceProvider) =>
{
    string message = "Hello, Amdaris! Logged using SL";
    var logger = serviceProvider.GetRequiredService<AmdarisLogger>();
    logger.LogMessage(message, true);
    return message;
});

app.Run();
