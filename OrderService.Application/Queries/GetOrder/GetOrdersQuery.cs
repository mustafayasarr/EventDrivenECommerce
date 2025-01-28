using MediatR;
using OrderService.Domain.Dtos;

namespace OrderService.Application.Queries.GetOrder;

public record GetOrdersQuery : IRequest<List<OrderResponse>>;
