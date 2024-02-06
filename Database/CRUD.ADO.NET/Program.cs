using System.Data.SqlClient;

internal class Program
{
    public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CRUD.ADO.NET.DB;";
    private static void Main(string[] args)
    {
        //AddProduct("Olma", 10000);
        //GetProduct(1);
        //GetProducts();
        UpdateProduct(1, "Nok", 5000);
    }

    private static void AddProduct(string name, int price)
    {
        string query = "insert into Products(name,price) values(@name,@price)";

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@price", price);

            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }

    private static void GetProduct(int id)
    {
        string query = "select * from Products where id = @id";

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", id);

            sqlCommand.Connection.Open();
            var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["id"]} | {reader["name"].ToString().Trim()} , {reader["Price"]}");
            }
        }
    }

    private static void GetProducts()
    {
        string query = "select * from Products";

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Connection.Open();
            var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["id"]} | {reader["name"].ToString().Trim()} , {reader["Price"]}");
            }
        }
    }

    private static void UpdateProduct(int id, string name, int price)
    {
        string query = "Update Products SET Name=@name, Price=@price where id=@id";

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@price", price);

            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Dispose();
        }
    }
}