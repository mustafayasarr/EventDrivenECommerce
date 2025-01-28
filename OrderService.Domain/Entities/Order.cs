using System.ComponentModel.DataAnnotations;

namespace OrderService.Domain.Entities;

public class Order
{
    [Key]
    public Guid Id { get; private set; }
    public string CustomerEmail { get; private set; }
    public List<OrderItem> OrderItems { get; private set; }
    private Order() { }

    public Order(string customerEmail, List<OrderItem> items)
    {
        CustomerEmail = customerEmail;
        OrderItems = items ?? new List<OrderItem>();
    }
}
