using DI_Learning.Models;

namespace DI_Learning.Services
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Telefon", Description = "Zo'r telefon"},
                new Product { Id = 3, Name = "Mashina", Description = "Zo'r mashina"},
            };
        }
    }
}
