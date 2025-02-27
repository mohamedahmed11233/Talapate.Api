using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talapate.APi.Dtos;
using Talapate.APi.Error;
using Talapate.Core.Entities;
using Talapate.Core.Interfaces;
using Talapate.Core.specification;

namespace Talapate.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> ProductRepo ,IMapper mapper)
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetALL()
        {
            var spec = new ProductWithBrandAndTypeSpecifications();
            var product = await _productRepo.GetAllWithSpecAsync(spec);


            return Ok(_mapper.Map<IEnumerable <Product>, IEnumerable<ProductDto>>(product));
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetById(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecifications(id);

            var product = await _productRepo.GetByIdWithSpecAsync(spec);

            if(product == null)     
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(_mapper.Map<Product,ProductDto>( product)); 
        }
    }
}
