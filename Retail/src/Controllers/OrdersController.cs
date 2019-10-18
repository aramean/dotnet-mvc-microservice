using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Orders.Data;

namespace Orders.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly OrderContext _context;

        public OrdersController(OrderContext context, ILogger<OrdersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET api/orders
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET api/orders/1
        [HttpGet("{orderRegistrationNumber}")]
        public async Task<ActionResult<Order>> Get(long orderRegistrationNumber)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.OrderRegistrationNumber == orderRegistrationNumber);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT api/orders/1
        [HttpPut("{orderRegistrationNumber}")]
        public async Task<ActionResult<Order>> Put(long orderRegistrationNumber, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (orderRegistrationNumber != order.OrderRegistrationNumber)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH api/orders/1
        [HttpPatch("{orderRegistrationNumber}")]
        public async Task<ActionResult<Order>> Patch(Order order)
        {
            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.OrderRegistrationNumber == order.OrderRegistrationNumber);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            orderToUpdate.OrderStatus = Orders.Enumerations.OrderStatusEnum.Arrived;
            _context.Entry(orderToUpdate).Property("OrderStatus").IsModified = true;
            await _context.SaveChangesAsync();

            return Ok(orderToUpdate);
        }

        // POST api/orders
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkOrderNumberExists = await _context.Orders.FirstOrDefaultAsync(o => o.OrderNumber == value.OrderNumber);

            if (checkOrderNumberExists != null)
            {
                return Conflict();
            }

            value.OrderStatus = Orders.Enumerations.OrderStatusEnum.New;

            _context.Orders.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { Id = value.OrderId }, value); // Trigger GetAll method
        }

    }
}
