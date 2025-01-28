using OrderService.Domain.Dtos;
using OrderService.Domain.Entities;

namespace OrderService.Domain.Mappers;

public static class OrderMapper
{
    public static OrderResponse ToResponse(this Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            CustomerEmail = order.CustomerEmail,
            Items = order.OrderItems.Select(item => new OrderItemDto
            {
                Id = item.Id,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList()
        };
    }
}
