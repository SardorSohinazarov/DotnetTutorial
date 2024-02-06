using System.Data.SqlClient;

internal class Program
{
    public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CRUD.ADO.NET.DB;";
    private static void Main(string[] args)
    {
        //AddProduct("Olma", 10000);
        GetProduct(1);
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
}