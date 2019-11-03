using System;
using System.Collections.Generic;
using System.Linq;
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
        protected readonly ILogger<OrdersController> _logger;
        protected readonly OrderContext _context;
        protected readonly IRepository _repository;

        public OrdersController(OrderContext context, ILogger<OrdersController> logger, IRepository repository)
        {
            _context = context;
            _logger = logger;
            _repository = repository;
        }

        // GET api/orders
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllFull()
        {
            var posts = await _repository.FindAll<Order>();
            return posts;
        }

        // GET: api/orders/0/5
        [Route("{page:int}/{pageSize:int}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll(int page = 0, int pageSize = 5)
        {
            var posts = await _context.Orders.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return posts;
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
        /* [HttpPut("{orderRegistrationNumber}")]
         public async Task<ActionResult> Put([FromBody]Order order, long orderRegistrationNumber)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             if (order.OrderRegistrationNumber != orderRegistrationNumber)
             {
                 return BadRequest();
             }

             _context.Entry(order).State = EntityState.Modified;
             await _context.SaveChangesAsync();

             return NoContent();
         }*/

        // PUT api/orders/1
        [HttpPut("{orderRegistrationNumber}")]
        public async Task<IActionResult> Put(long orderRegistrationNumber, Order order)
        {
            if (order.OrderRegistrationNumber != orderRegistrationNumber)
            {
                _logger.LogError("Missmatch.");
                return BadRequest();
            }

            if (order != null && !ModelState.IsValid)
            {
                _logger.LogError("Invalid order object sent from client.");
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entity = ex.Entries.Single().GetDatabaseValues();

                if (entity == null)
                {
                    Console.WriteLine("The entity being updated is already deleted by another user...");
                }
                else
                {
                    Console.WriteLine("The entity being updated has already been updated by another user...");
                }

            }

            return Ok();
        }

        // PATCH api/orders/1
        [HttpPatch("{orderRegistrationNumber}")]
        public async Task<ActionResult> Patch(long orderRegistrationNumber, Order order)
        {
            if (order.OrderRegistrationNumber != orderRegistrationNumber)
            {
                _logger.LogError("Missmatch.");
                return BadRequest();
            }

            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.OrderRegistrationNumber == order.OrderRegistrationNumber);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            orderToUpdate.OrderStatus = Enumerations.OrderStatusEnum.Arrived;

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

            value.OrderStatus = Enumerations.OrderStatusEnum.New;

            _context.Orders.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { Id = value.OrderId }, value); // Trigger GetAll method
        }

    }
}
