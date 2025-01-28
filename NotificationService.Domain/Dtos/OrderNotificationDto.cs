namespace NotificationService.Domain.Dtos;

public class OrderNotificationDto
{
    public Guid OrderId { get; set; }
    public string CustomerEmail { get; set; }
    public string Message { get; set; }
    public DateTime NotificationDate { get; set; }

    public OrderNotificationDto(Guid orderId, string customerEmail)
    {
        OrderId = orderId;
        CustomerEmail = customerEmail;
        Message = $"{orderId} sipariş numaralı siparişiniz başarıyla oluşturuldu!";
        NotificationDate = DateTime.UtcNow;
    }
}
