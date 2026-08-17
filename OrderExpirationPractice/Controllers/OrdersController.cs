using Microsoft.AspNetCore.Mvc;
using OrderExpirationPractice.Data;
using OrderExpirationPractice.DTOs;
using OrderExpirationPractice.Enum;
using OrderExpirationPractice.Models;

namespace OrderExpirationPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                TotalAmount = dto.TotalAmount,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(CreateOrder),
                new { id = order.Id },
                order);
        }
    }
}
