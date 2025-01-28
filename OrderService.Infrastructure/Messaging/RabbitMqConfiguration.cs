using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrderService.Infrastructure.Messaging;

public static class RabbitMqConfiguration
{
    public static void ConfigureRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(Environment.GetEnvironmentVariable("RABBITMQ_HOST"), h =>
                    {
                        h.Username(Environment.GetEnvironmentVariable("RABBITMQ_USERNAME"));
                        h.Password(Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD"));
                    });

                });
            });
    }
}
