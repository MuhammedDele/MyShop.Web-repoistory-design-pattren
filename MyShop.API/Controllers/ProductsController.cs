using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ProductsController(IUnitOfWork uow)
        {
            _uow=uow;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _uow.ProductRepository.All();
        }
        [HttpGet("id")]
        public ActionResult<Product> GetProduct(int id) {
            var product = _uow.ProductRepository.Get(id);

            if(product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _uow.ProductRepository.Add(product);
            _uow.SaveChanges();

            return CreatedAtAction("GetProduct", new {id =product.ProductID},product);
        }
    }
}
