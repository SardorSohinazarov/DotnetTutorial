using Microsoft.AspNetCore.Mvc;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly MockRepositoryService _repositoryService;

        public ProductsController(MockRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(product);
            }

            _repositoryService.Add(product);

            return Ok(product);
        }

        [HttpPost("image")]
        public async Task<IActionResult> AddImage(IFormFile image)
        {
            return Ok(image);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = _repositoryService.GetProducts();

            return Ok(products);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product, int id)
        {
            _repositoryService.UpdateProduct(product, id);

            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _repositoryService.DeleteProduct(id);

            return Ok();
        }
    }
}
