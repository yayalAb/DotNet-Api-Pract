using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Web_Api.Data;
using MVC_Web_Api.models;

namespace MVC_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListsController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderListsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrderLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderList>>> GetOrderList()
        {
          if (_context.OrderList == null)
          {
              return NotFound();
          }
            return await _context.OrderList.ToListAsync();
        }
        // GET: api/OrderLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderList>> GetOrderList(int id)
        {
          if (_context.OrderList == null)
          {
              return NotFound();
          }
            var orderList = await _context.OrderList.FindAsync(id);

            if (orderList == null)
            {
                return NotFound();
            }

            return orderList;
        }

        // PUT: api/OrderLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderList(int id, OrderList orderList)
        {
            if (id != orderList.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderList>> PostOrderList(OrderList orderList)
        {
          if (_context.OrderList == null)
          {
              return Problem("Entity set 'DataContext.OrderList'  is null.");
          }
            _context.OrderList.Add(orderList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderList", new { id = orderList.Id }, orderList);
        }

        // DELETE: api/OrderLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderList(int id)
        {
            if (_context.OrderList == null)
            {
                return NotFound();
            }
            var orderList = await _context.OrderList.FindAsync(id);
            if (orderList == null)
            {
                return NotFound();
            }

            _context.OrderList.Remove(orderList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderListExists(int id)
        {
            return (_context.OrderList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
