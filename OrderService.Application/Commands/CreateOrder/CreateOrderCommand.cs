using MediatR;
using OrderService.Domain.Entities;

namespace OrderService.Application.Commands.CreateOrder;

public record CreateOrderCommand(string CustomerEmail, List<OrderItem> Items) : IRequest<Guid>;
