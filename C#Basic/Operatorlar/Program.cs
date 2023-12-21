using System.Reflection.Emit;

public class Project
{
    public static void Main()
    {
        int son = 200;
        
        for (int i = 0; Fibonachchi(i) < son; i++)
        {
            Console.WriteLine(Fibonachchi(i));
        }
        /*int.TryParse("243", out int result);

        Console.WriteLine(result);

        int num = 5;
        //IncrementRef(ref num);
        IncrementOut("34",out num);
        Console.WriteLine(num);*/
    }

    public static int Fibonachchi(int son)
    {
        if (son == 0)
        {
            return 0;
        }
        else if (son == 1 || son == 2)
        {
            return 1;
        }
        else
        {
            return Fibonachchi(son - 1) + Fibonachchi(son - 2);
        }

    }



    private static void Increment(int num)
    {
        num += 1;
    }
    
    private static void IncrementRef(ref int num)
    {
        num += 1;
    }
    
    private static void IncrementOut(string numString,out int num)
    {
        num = int.Parse(numString);
    }


        /*Start: Console.WriteLine("Qale");
        string num = Console.ReadLine();
        Console.WriteLine(num);

        Start2: Console.WriteLine("Start2");

        goto Start2;*/

        /*int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        int c = int.Parse(Console.ReadLine()!);

        double D = Math.Pow(b,2) - 4 * a * c;
        double x1;
        double x2;
        double x;

        if (D > 0)
        {
            x1 = (-b + Math.Sqrt(D)) / (2 *a); 
            Console.WriteLine($"x1={x1}");
            
            x2 = (-b - Math.Sqrt(D)) / (2 *a); 
            Console.WriteLine($"x2={x2}");
        }
        else if(D == 0)
        {
            x = (-b) / (2 * a);
            Console.WriteLine($"x={x}");
        }
        else
        {
            Console.WriteLine("Yechim yo'q");
        }*/


       /* int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        int num4 = int.Parse(Console.ReadLine());
        int num5 = int.Parse(Console.ReadLine());
        int num6 = int.Parse(Console.ReadLine());
        int num7 = int.Parse(Console.ReadLine());

        Console.WriteLine($"Javob :{num1 ^ num2 ^ num3 ^ num4 ^ num5 ^ num6 ^ num7}");*/
        /*int bir = 1;

        Increment(bir);
        Console.WriteLine(bir);

        int birr = 1;
        IncrementRef(ref birr);
        Console.WriteLine(birr);

        IncrementOut(out int b);
        Console.WriteLine(b);*/

        //Ot

       /* int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        if((Math.Abs(x1 -x2) == 2 && Math.Abs(y1 -y2) == 1) || (Math.Abs(x1 - x2) == 1 && Math.Abs(y1 - y2) == 2))
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }*/


/*        //Xor vazifa
        Console.WriteLine("Sonlarni kiriting:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        int num4 = int.Parse(Console.ReadLine());
        int num5 = int.Parse(Console.ReadLine());

        Console.WriteLine(num1 ^ num2 ^ num3 ^ num4 ^ num5);*/

        /*string name = "Sardor";

        var a = name switch
        {
            "Sardor" => 4,
            "Sarvar" => 2,
        };*/

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


    /* public static void Increment(int a)
     {
         ++ a;
     }

     public static void IncrementRef(ref int value)
     {
         ++ value;
     }

     public static void IncrementOut(out int value)
     {
         value = 1;
         ++ value;
     }*/