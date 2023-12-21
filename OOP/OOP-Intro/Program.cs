/*namespace OOP_Intro;

public class Program
{
    public static void Main(string[] args)
    {
        double bir = 0.1;
        double ikki = 0.2;

        Console.WriteLine(bir + ikki);
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        string A, B;
        Console.Write("A satrni kiriting: ");
        A = Console.ReadLine();
        Console.Write("B satrni kiriting: ");
        B = Console.ReadLine();

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == ',')
            {
                A = A.Insert(i, B);
                i = i + B.Length;
                Console.WriteLine(A);
            }
        }

        string S = A;

        Console.WriteLine("S satri: " + S);

        Console.WriteLine("Bosingiz...");
        Console.ReadLine();
    }
}
*//*

using System;
using System.Collections.Generic;

public class Program
{
    static int[,] moves = new int[,] { { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };
    static int[,] phone = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { -1, 0, -1 } };
    static List<int> result = new List<int>();

    public static void Main()
    {
        RaqamlarniHisobla(7, 0, 0);
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }

    static void RaqamlarniHisobla(int start, int depth, int num)
    {
        if (depth == 7)
        {
            result.Add(num);
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (phone[i, j] == start)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        int x = i + moves[k, 0];
                        int y = j + moves[k, 1];
                        if (x >= 0 && x < 4 && y >= 0 && y < 3 && phone[x, y] != -1)
                        {
                            RaqamlarniHisobla(phone[x, y], depth + 1, num * 10 + phone[x, y]);
                        }
                    }
                }
            }
        }
    }
}

*/
/*using System;

class Program
{
    static void Main()
    {
        int k, b, m, n, x;
        Console.Write("Kattalar soni: ");
        k = Convert.ToInt32(Console.ReadLine());

        Console.Write("Bolalar soni: ");
        b = Convert.ToInt32(Console.ReadLine());

        Console.Write("O'rindiqlar soni: ");
        m = Convert.ToInt32(Console.ReadLine());

        n = m - 2;
        x = b / n;

        if (k < 2 || b < 0 || m < 3)
        {
            Console.WriteLine("Impossible");
            return;
        }

        if (b % n != 0)
        {
            x = x + 1;
        }

        if (k >= x * 2 || k + b <= m)
        {
            Console.WriteLine("True");
            Console.WriteLine($"{x} ta kerak");
        }
        else
        {
            Console.WriteLine("Impossible");
        }
    }
}

*/