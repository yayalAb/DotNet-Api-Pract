using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Web_Api.Data;

namespace MVC_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DataContext _context;
        public DriversController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<models.driver>>> Get()
        {
            //return Ok(await _context.Products.ToListAsync());
            return Ok(_context.Drivers);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<models.driver>>> Get(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null)
            {
                return BadRequest("Product Not found");
            }
            return Ok(driver);

        }
        [HttpPost]
        public async Task<ActionResult<List<models.driver>>> AddDriver(models.driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();

            return Ok(_context.Drivers);

        }

        [HttpPut]
        public async Task<ActionResult<List<models.driver>>> Get(models.driver requst)
        {
            var driver = _context.Drivers.Find(requst.Id);
            if (driver == null)
            {
                return BadRequest("Product Not found");
            }
            //  product = requst;
            //_context.Products.Update(product);

            driver.Name = requst.Name;
            driver.Email = requst.Email;
            driver.Phone = requst.Phone;
            driver.Age = requst.Age;
            _context.SaveChanges();
            return Ok(_context.Drivers);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<models.driver>>> DeleteDriver(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null)
            {
                return BadRequest("Product Not found");
            }
            _context.Drivers.Remove(driver);
            _context.SaveChanges();

            return Ok(_context.Drivers);

        }

    }
}