internal class Program
{
    private static void Main(string[] args)
    {
        Home().Wait();
    }

    public static async Task Home()
    {
        var task1 = Iterate();
        var task2 = Iterate();
        var task3 = Iterate();

        await task1;
        await task2;
        await task3;
    }

    public static async Task Iterate()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);
        }
    }
}