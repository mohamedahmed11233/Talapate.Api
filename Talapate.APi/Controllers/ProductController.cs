using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talapate.Core.Entities;
using Talapate.Core.Interfaces;

namespace Talapate.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> ProductRepo)
        {
            _productRepo = ProductRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetALL()
        {
            var product = await _productRepo.GetAllAsync();

            return Ok(product);
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetById(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            return Ok(product);
        }
    }
}
