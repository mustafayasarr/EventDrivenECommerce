using Bogus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Commands.CreateOrder;
using OrderService.Application.Queries.GetOrder;
using OrderService.Domain.Entities;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController(ISender mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var fakeOrder = new Faker<OrderItem>()
            .RuleFor(o => o.ProductName, f => f.Commerce.ProductName())
            .RuleFor(o => o.Quantity, f => f.Random.Int(1, 10))
            .RuleFor(o => o.Price, f => Convert.ToDecimal(f.Commerce.Price(10m, 1000m)))
            .Generate(2);

           await mediator.Send(new CreateOrderCommand(new Faker().Internet.Email(), fakeOrder));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await mediator.Send(new GetOrdersQuery()));
        }
    }
}
