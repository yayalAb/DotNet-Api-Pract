using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Web_Api.Data;

namespace MVC_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
           _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<models.Product>>> Get()
        {
            //return Ok(await _context.Products.ToListAsync());
            return Ok(_context.Products);
           
        }

        [HttpGet]
        [Route("ExpireProducts")]
        public async Task<ActionResult<List<models.Product>>> ExpireProducts()
        {
            var Today = DateTime.Now;
            var product = _context.Products.Where(u=>u.ExpireDate < Today);
            return Ok(product);
        }

        [HttpGet]
        [Route("Finshed")]
        public async Task<ActionResult<List<models.Product>>> FinshedProducts()
        {
            var product = _context.Products.Where(u => u.Content == 0);
            return Ok(product);
        }

        [HttpGet]
        [Route("NearToFinshed")]
        public async Task<ActionResult<List<models.Product>>> NeatToFinshProducts()
        {
            var product = _context.Products.Where(u => u.Content <10);
            return Ok(product);
        }
       // [HttpGet, Authorize(Role = "Admin"]
        [HttpGet]
        [Route("NearToExpire")]
        public async Task<ActionResult<List<models.Product>>> NearToExpireProducts()
        {
            var Today = DateTime.Now.AddDays(10);
            var product = _context.Products.Where(u => u.ExpireDate < Today);
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<models.Product>>> Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Product Not found");
            }
            return Ok(product);

        }
        [HttpPost]
        public async Task<ActionResult<List<models.Product>>>AddProduct(models.Product Product)
        {
            //product.ProductionDate = requst.ProductionDate;
            //product.ExpireDate = requst.ExpireDate;
            //if (Product.ProductionDate<=DateTime.Now && Product.ExpireDate >= DateTime.Now)
            //{
                 
                _context.Products.Add(Product);
                _context.SaveChanges();
                return Ok(_context.Products);

            //}
            //else
            //{
            //    return BadRequest("Product Not found");
            //}
           

        }

        [HttpPut]
        public async Task<ActionResult<List<models.Product>>> Get(models.Product requst)
        {
            var product = _context.Products.Find(requst.Id);
            if (product == null)
            {
                return BadRequest("Product Not found");
            }  
            //  product = requst;
            //_context.Products.Update(product);
            
            product.ProductName = requst.ProductName;
            product.ProductCategory = requst.ProductCategory;
            product.ProductQuality = requst.ProductQuality;
            product.ProductionDate = requst.ProductionDate;
            product.ExpireDate = requst.ExpireDate;
            product.Content = requst.Content;
            product.UnitPrice = requst.UnitPrice;
            _context.SaveChanges();
            return Ok(_context.Products);

            }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<models.Product>>> DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Product Not found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(_context.Products);

        }

    }
}
