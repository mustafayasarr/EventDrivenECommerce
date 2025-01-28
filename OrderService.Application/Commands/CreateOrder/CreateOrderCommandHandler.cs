using MassTransit;
using MediatR;
using OrderService.Application.Commands.CreateOrder;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistence;
using Shared.Events;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly ApplicationDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateOrderCommandHandler(ApplicationDbContext context, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;

    }
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var order = new Order(request.CustomerEmail, request.Items);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync(cancellationToken);
            var orderCreatedEvent = new OrderCreatedEvent(order.Id, request.CustomerEmail);
            await _publishEndpoint.Publish(orderCreatedEvent);
            Console.WriteLine($"OrderCreatedEvent yayınlandı: {order.Id}");

            return order.Id;
        }
        catch (Exception ex)
        {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            throw;
        }
    }
}
