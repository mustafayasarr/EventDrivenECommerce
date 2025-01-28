using NotificationService.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Ortam değişkenlerini yükle
builder.Configuration
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables(); // Docker ortam değişkenlerini oku

builder.Services.AddControllers();
builder.Services.ConfigureRabbitMq(builder.Configuration);
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
