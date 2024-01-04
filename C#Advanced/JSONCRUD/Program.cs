using JSONCRUD.Entities;
using JSONCRUD.Services;

Product product = new Product();
product.Name = "Car";
product.Id = 2;
product.Description = "Name";


IProductCRUDService service = new ProductCRUDService();

service.AddProduct(product);