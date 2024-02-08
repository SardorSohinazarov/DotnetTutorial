using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "mongodb://localhost:27017";

        MongoClient mongoDB = new MongoClient(connectionString);

        var database = mongoDB.GetDatabase("CrudMongo");

        var collection = database.GetCollection<Product>("Products");

        Console.WriteLine(collection.Count(_ => true));

        collection.InsertOne(new Product()
        {
            Name = "Telefon",
            Description = "Yaxshi telefon",
            Price = 93483.43423M
        });

        Console.WriteLine(collection.Count(_ => true));
    }
}