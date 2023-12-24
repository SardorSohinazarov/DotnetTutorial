internal class Program
{
    public delegate string Mydelegate2(string word1, string word2);
    private static void Main(string[] args)
    {
        Methods m = new Methods();
        Mydelegate2 mydelegate2 = new Mydelegate2(m.AddTwoWord);

        Console.WriteLine(InvokeMyDelegate(mydelegate2));
    }

    public static string InvokeMyDelegate(Mydelegate2 mydelegate)
    {
        return mydelegate.Invoke("Sardor", "Sohinazarov");
    }
}

public class Methods
{
    public string AddTwoWord(string word1, string word2)
    {
        return word1 + word2;
    }
}


