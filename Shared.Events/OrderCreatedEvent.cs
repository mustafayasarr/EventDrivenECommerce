namespace Shared.Events;

public record OrderCreatedEvent(Guid OrderId, string CustomerEmail);
