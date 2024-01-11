namespace TestAPI.Services
{
    public class MockRepositoryService
    {
        private readonly List<Product> products;
        public MockRepositoryService()
        {
            products = new List<Product>();
        }

        public Product Add(Product product)
        {
            products.Add(product);

            return product;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product UpdateProduct(Product product, int id)
        {
            var p = products.FirstOrDefault(p => p.Id == id);
            if (p == null) { return null; }
            p.Name = product.Name;
            return p;
        }

        public Product DeleteProduct(int id)
        {
            var p = products.FirstOrDefault(p => p.Id == id);
            if (p == null) { return null; }
            products.Remove(p);
            return p;
        }
    }
}
