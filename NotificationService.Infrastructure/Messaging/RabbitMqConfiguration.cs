
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Infrastructure.Messaging.Consumers;

namespace NotificationService.Infrastructure.Messaging;

public static class RabbitMqConfiguration
{
    public static void ConfigureRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreatedConsumer>();
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(Environment.GetEnvironmentVariable("RABBITMQ_HOST"), h =>
                    {
                        h.Username(Environment.GetEnvironmentVariable("RABBITMQ_USERNAME"));
                        h.Password(Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD"));
                    });


                    config.ReceiveEndpoint("order-created-queue", e =>
                    {
                        e.ConfigureConsumer<OrderCreatedConsumer>(context);
                    });
                });
            });

    }
}
