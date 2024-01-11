using System.Text.Json;

HttpClient httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json");
var response = httpClient.SendAsync(request).Result;
var body = response.Content.ReadAsStringAsync().Result;
var courses = JsonSerializer.Deserialize<List<Valyuta>>(body);

Console.Write("Qaysi pul birligidan: ");
string item1 = Console.ReadLine();
Console.Write("Pul miqdorini kiriting: ");
double item2 = double.Parse(Console.ReadLine());
Console.Write("Qaysi pul birligiga: ");
string item3 = Console.ReadLine();
if (item1 == item3)
{
    Console.WriteLine($"{item2} {item1} = {item2} {item3}");
}
else
{
    if (item1 == "UZS")
    {
        foreach (var c1 in courses)
        {
            if (item3 == c1.code.ToString())
            {
                Console.WriteLine($"{item2} {item1} = {item2 / double.Parse(c1.cb_price)} {item3}");
                return;
            }
        }
    }
    else
    {
        foreach (var c in courses)
        {
            if (item1 == c.code.ToString())
            {
                double item_1 = item2 * double.Parse(c.cb_price);

                foreach (var c1 in courses)
                {
                    if (item3 == c1.code.ToString())
                    {
                        double item_3 = item_1 / double.Parse(c1.cb_price);
                        Console.WriteLine($"{item2} {item1} = {item_3} {item3}");
                        return;
                    }
                    if (item1 == c1.code.ToString() && item3 == "UZS")
                    {
                        Console.WriteLine($"{item2} {item1} = {double.Parse(c.cb_price) * item2} {item3}");
                        return;
                    }
                }
            }
        }
    }
}
public class Valyuta
{
    public string title { get; set; }
    public string code { get; set; }
    public string cb_price { get; set; }
    public string nbu_buy_price { get; set; }
    public string nbu_cell_price { get; set; }
    public string date { get; set; }
}


/*using System.Text;

var BaseURL = "https://localhost:7010/Products/UpdateProduct?id=1";

//Birinchisi
*//*using System.Text;

var client = new HttpClient();
var request = new HttpRequestMessage();
request.RequestUri = new Uri("https://localhost:7010/Products/AddProduct");
request.Method = HttpMethod.Post;

var bodyString = "{\r  \"id\": 0,\r  \"name\": \"string\"\r}";
var content = new StringContent(bodyString, Encoding.UTF8, "application/json");
request.Content = content;

var response = await client.SendAsync(request);
var result = await response.Content.ReadAsStringAsync();
Console.WriteLine(result);*//*


//Ikkinchisi
*//*using System.Text;

HttpClient httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7010/Products/AddProduct");

request.Content = new StringContent("{\r\n  \"id\": 0,\r\n  \"name\": \"string\"\r\n}", Encoding.UTF8, "application/json");

var response = httpClient.SendAsync(request).Result;
var body = response.Content.ReadAsStringAsync().Result;
Console.WriteLine(body);*//*


//Put
*//*HttpClient httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7010/Products/UpdateProduct?id=1");

request.Content = new StringContent("{\r\n  \"id\": 0,\r\n  \"name\": \"string\"\r\n}", Encoding.UTF8, "application/json");

var response = httpClient.SendAsync(request).Result;
var body = response.Content.ReadAsStringAsync().Result;
Console.WriteLine(body);
*//*

//Put
*//*HttpClient httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7010/Products/DeleteProduct?id=1");

var response = httpClient.SendAsync(request).Result;
var body = response.Content.ReadAsStringAsync().Result;
Console.WriteLine(body);*//*



//HttpPost
int id = int.Parse(Console.ReadLine());
HttpClient httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Put, $"https://e5c9-89-236-218-41.ngrok-free.app/Products/UpdateProduct?id={id}");

request.Content = new StringContent("{\r\n  \"id\": 0,\r\n  \"name\": \"1009Peoduct\"\r\n}", Encoding.UTF8, "application/json");

var result = httpClient.SendAsync(request).Result;

var malumot = result.Content.ReadAsStringAsync().Result;

Console.WriteLine(malumot);

*/


