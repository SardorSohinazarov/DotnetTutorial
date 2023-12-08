public class Project
{
    public static void Main()
    {
        string name = "Sardor";

        var a = name switch
        {
            "Sardor" => 4,
            "Sarvar" => 2,
        };

        /*//Darajaga oshirish
        Console.WriteLine(Math.Pow(2, 10));

        //Ildiz
        Console.WriteLine(Math.Sqrt(625));

        //Butun
        Console.WriteLine(Math.Floor(3.56));

        //Ceil
        Console.WriteLine(Math.Ceiling(9.81));

        //Fail
        Console.WriteLine(Math.Floor(-43.7));

        //sin
        Console.WriteLine(Math.Sin(0));

        //cos
        Console.WriteLine(Math.Cos(0));

        //Equels
        Console.WriteLine(Math.Equals("S","33"));

        Console.WriteLine(Math.Log2(9));

        //
        Console.WriteLine(Math.ILogB(17));*/

    }
}