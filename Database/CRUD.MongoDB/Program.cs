using MongoDB.Bson;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        /* InsertProduct(new Product()
         {
             Name = "Telefon2",
             Description = "Yaxshi telefon",
             Price = 93483.43423M
         });*/

        var products = GetProducts();

        foreach (var product in products)
        {
            Console.WriteLine(product.Id);
        }


        //DeleteProduct(Console.ReadLine());

        //UpdateProduct(new Product() { Name = "Sardor", Description = "Qales", Price = 3824.9843M }, Console.ReadLine());
    }

    private static Product GetProduct(string id)
    {
        IMongoCollection<Product> collection = GetCollection();

        var product = collection.Find(x => x.Name == id).FirstOrDefault();

        return product;
    }

    private static List<Product> GetProducts()
    {
        IMongoCollection<Product> collection = GetCollection();

        var product = collection.Find(new BsonDocument()).ToList();

        return product;
    }

    private static IMongoCollection<Product> GetCollection()
    {
        string connectionString = "mongodb://localhost:27017";

        MongoClient mongoDB = new MongoClient(connectionString);

        var database = mongoDB.GetDatabase("CrudMongo");

        var collection = database.GetCollection<Product>("Products");
        return collection;
    }

    public static void InsertProduct(Product product)
    {
        IMongoCollection<Product> collection = GetCollection();
        collection.InsertOne(product);
    }

    public static void DeleteProduct(string Id)
    {
        IMongoCollection<Product> collection = GetCollection();
        var deleteResult = collection.DeleteOne(x => x.Id == Id);
        Console.WriteLine(deleteResult.DeletedCount + " ta qator o'chdi");
    }

    public static void UpdateProduct(Product product, string Id)
    {
        IMongoCollection<Product> collection = GetCollection();
        var updateResult = collection.ReplaceOne(x => x.Id == Id, product);
        Console.WriteLine(updateResult.ModifiedCount + " ta qator update bo'ldi");
    }
}