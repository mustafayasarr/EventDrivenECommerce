namespace OrderService.Domain.ValueObjects;

public class OrderNumber
{
    public string Value { get; private set; }
    public OrderNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Order number cannot be empty");
        Value = value;
    }
}
