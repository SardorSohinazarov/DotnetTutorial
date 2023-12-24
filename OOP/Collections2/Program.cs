using Collections2;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static void Main(string[] args)
    {
        string name = "Sardor";

        name.ConsolegaChiqar();

        int number = 7777;

        var number2 = number.IkkigaKopaytir();

        Console.WriteLine(number2);


        Product product = new Product()
        {
            Id = 1,
            Name = "TestProduct",
        };
        
        Product product2 = new Product()
        {
            Id = 1,
            Name = "TestProduct4",
        };

        Console.WriteLine(product.Taqqosla(product2));
    }
}