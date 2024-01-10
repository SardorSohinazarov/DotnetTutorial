
using HttpClients.Models;
using System.Text.Json;
internal class Program
{
    private static void Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json");

        var response = httpClient.SendAsync(request).Result;

        var body = response.Content.ReadAsStringAsync().Result;

        var courses = JsonSerializer.Deserialize<List<Valyuta>>(body);

        foreach (var c in courses)
        {
            Console.WriteLine(c.title);
        }
    }
}