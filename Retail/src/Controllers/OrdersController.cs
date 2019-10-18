using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Orders.Data;

namespace gunnebo.Controllers
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
        [HttpGet("{OrderRegistrationNumber}")]
        public async Task<ActionResult<Order>> Get(long OrderRegistrationNumber)
        {
            // INFO: No indexed Unique combined key supported in EF, See Order DbContext.
            // TODO: Add unique constraint to combination of two columns.

            //var order = await _context.Orders.FirstAsync(o => o.OrderRegistrationNumber == OrderRegistrationNumber);
            //var order = await _context.Orders.FindAsync(OrderRegistrationNumber); // Primary key is not used in solution
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.OrderRegistrationNumber == OrderRegistrationNumber);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT api/orders/1
        [HttpPut("{OrderRegistrationNumber}")]
        public async Task<ActionResult<Order>> Put(long OrderRegistrationNumber, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (OrderRegistrationNumber != order.OrderRegistrationNumber)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH api/orders/1
        [HttpPatch("{OrderRegistrationNumber}")]
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

            value.OrderStatus = Orders.Enumerations.OrderStatusEnum.New;

            _context.Orders.Add(value);
            await _context.SaveChangesAsync();

            // TODO: Optimize with just one element (Get) if possible.
            return CreatedAtAction("GetAll", new { Id = value.OrderId }, value); // Trigger GetAll method
        }

    }
}
