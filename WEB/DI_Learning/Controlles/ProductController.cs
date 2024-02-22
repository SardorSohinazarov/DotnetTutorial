using DI_Learning.Services;
using System.Text.Json;

namespace DI_Learning.Controlles
{
    public class ProductController
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        public void GetProducts()
        {
            var products = _service.GetAllProducts();

            Console.WriteLine(JsonSerializer.Serialize(products));
        }
    }
}
