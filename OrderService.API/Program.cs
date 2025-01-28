using Microsoft.EntityFrameworkCore;
using OrderService.Application.Commands.CreateOrder;
using OrderService.Infrastructure.Messaging;
using OrderService.Infrastructure.Persistence;
using Scalar.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Ortam değişkenlerini yükle
builder.Configuration
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables(); // Docker ortam değişkenlerini oku

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));

// LocalDB Konfigürasyonu
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")),ServiceLifetime.Scoped);

builder.Services.ConfigureRabbitMq(builder.Configuration);
builder.Logging.AddDebug(); // Daha detaylı hata mesajları için

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); 
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Servers = [
            new ScalarServer("https://localhost:5012/")
            ];
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
