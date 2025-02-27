using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talapate.APi.Error;
using Talapate.Repository.Data.Context;

namespace Talapate.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly StoreContext _dbContext;

        public TestController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("notfound")]  // Api/Buggy/notfound 
        public ActionResult GetNotFound()
        {
            var products = _dbContext.products.Find(100);
            if (products is null) return NotFound(new ApiResponse(404));
            return Ok(products);
        }

        [HttpGet("servererror")] // Api/Buggy/servererror 
        public ActionResult GetServerError()
        {
            var products = _dbContext.products.Find(100);
            var productToReturn = products.ToString();
            return Ok(productToReturn);
        }

        [HttpGet("badrequest/{id}")] // Api/Buggy/badrequest/Five 
        public ActionResult GetBadRequest(int id) // validation Error 
        {
            return Ok(new ApiResponse(400)); // to return my message 
        }
    }
}
