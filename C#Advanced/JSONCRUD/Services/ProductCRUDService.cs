using JSONCRUD.Entities;
using System.Text.Json;

namespace JSONCRUD.Services
{
    public class ProductCRUDService : IProductCRUDService
    {
        string path = "C:\\Users\\sardo\\OneDrive\\Рабочий стол\\Database";
        string filename = "users.json";
        public void AddProduct(Product product)
        {
            var products = ReadAllProducts();

            var ids = products.Select(x => x.Id);

            if (ids.Contains(product.Id))
            {
                return;
            }

            products.Add(product);
            WriteAllProducts(products);
        }

        public void UpdateProduct(int id, Product product1)
        {
            var products = ReadAllProducts();

            var product = products.FirstOrDefault(x => x.Id == id);

            product.Name = product1.Name;
            product.Description = product1.Description;

            WriteAllProducts(products);
        }

        public void DeleteProduct(int id)
        {
            var products = ReadAllProducts();

            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return;
            }

            products.Remove(product);
            WriteAllProducts(products);
        }

        private void WriteAllProducts(List<Product> products)
        {
            var jsonData = JsonSerializer.Serialize(products);
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, filename)))
            {
                sw.Write(jsonData);
            }
        }

        private List<Product> ReadAllProducts()
        {
            string jsonData;

            using (StreamReader reader = new StreamReader(Path.Combine(path, filename)))
            {
                jsonData = reader.ReadToEnd();
            }

            List<Product> productList;
            try
            {
                productList = JsonSerializer.Deserialize<List<Product>>(jsonData);
            }
            catch
            {
                return new List<Product>();
            }

            return productList;
        }
    }
}