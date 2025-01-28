using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Dtos;
using OrderService.Domain.Mappers;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Application.Queries.GetOrder;

public class GetOrdersQueryHandler(ApplicationDbContext context) : IRequestHandler<GetOrdersQuery, List<OrderResponse>>
{
    public async Task<List<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await context.Orders
            .Include(a => a.OrderItems)
            .AsNoTracking()
            .Select(a => a.ToResponse())
            .ToListAsync(cancellationToken);
    }
}
