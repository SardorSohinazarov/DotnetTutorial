using DI_Learning.Controlles;
using DI_Learning.DI;

internal class Program
{
    private static void Main(string[] args)
    {
        var controller = DIContainer.GetService<ProductController>();
        controller.GetProducts();
    }
}