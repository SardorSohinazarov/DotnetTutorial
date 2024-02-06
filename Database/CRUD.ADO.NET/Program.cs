using System.Data.SqlClient;

internal class Program
{
    public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CRUD.ADO.NET.DB;";
    private static void Main(string[] args)
    {
        AddProduct("Olma", 10000);
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
}