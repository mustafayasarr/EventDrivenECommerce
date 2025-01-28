namespace OrderService.Domain.Dtos;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string CustomerEmail { get; set; } = string.Empty;
    public List<OrderItemDto> Items { get; set; } = new();
    public decimal TotalAmount => Items.Sum(i => i.Price * i.Quantity);
}
