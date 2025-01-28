using System.ComponentModel.DataAnnotations;

namespace OrderService.Domain.Entities;

public class OrderItem
{
    [Key]
    public Guid Id { get; private set; }
    public Guid OrderId { get; set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

}
