using MassTransit;
using NotificationService.Domain.Dtos;
using Shared.Events;

namespace NotificationService.Infrastructure.Messaging.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        Console.WriteLine($"Receive Message: {context.Message}");

        var message = context.Message;

        var notification = new OrderNotificationDto(message.OrderId, message.CustomerEmail);

        await SendEmail(notification);

    }
    private async Task SendEmail(OrderNotificationDto dto)
    {
        Console.WriteLine($"Yeni Sipariş Bildirimi: {dto.Message} (Tarih: {dto.NotificationDate})");

        // Buraya gerçek bir e-posta servisi entegrasyonu ekleyebilirsiniz.

        Console.WriteLine($"E-posta gönderildi: {dto.CustomerEmail}");

        await Task.CompletedTask;
    }
}
