//1
/*internal class Program
{
    private static void Main(string[] args)
    {
        Thread thread = new Thread(Iterate);

        //Shuni threadni ishga tushurish ham vaqt oladida ungacha hello world
        thread.Start();

        Console.WriteLine("Hello, World!");
    }

    public static void Iterate()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Thread.CurrentThread.Name ?? "Nomsiz" + " => " + i);
        }
    }
}*/


//2
/*
internal class Program
{
    private static void Main(string[] args)
    {
        Thread thread1 = new Thread(Iterate);
        thread1.Name = "Thread-1";
        Thread thread2 = new Thread(Iterate);
        thread2.Name = "Thread-2";

        //Xar hil natija kutishga qarab o'zgaradi
        thread1.Start();
        thread2.Start();

        Console.WriteLine("Hello, World!");
    }

    public static void Iterate()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Thread.CurrentThread.Name + " => " + i);
        }
    }
}*/


//3
/*
internal class Program
{
    private static void Main(string[] args)
    {
        Thread thread1 = new Thread(Iterate);
        thread1.Name = "Thread-1";
        Thread thread2 = new Thread(Iterate);
        thread2.Name = "Thread-2";

        thread1.Start();
        thread2.Start();

        Console.WriteLine("Hello, World!");
    }

    public static void Iterate()
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine(Thread.CurrentThread.Name + " => " + i);
        }
    }
}*/



//4
/*internal class Program
{
    private static void Main(string[] args)
    {
        Thread thread1 = new Thread(Iterate1);
        thread1.Name = "Thread-1";
        Thread thread2 = new Thread(Iterate2);
        thread2.Name = "Thread-2";

        thread1.Start();
        thread2.Start();

        Console.WriteLine("Hello, World!");
    }

    public static void Iterate1()
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine(Thread.CurrentThread.Name + " => " + i);
        }
    }


    public static void Iterate2()
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(300);
            Console.WriteLine(Thread.CurrentThread.Name + " => " + i);
        }
    }
}*/


//5
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Boshi:" + Thread.CurrentThread.ThreadState.ToString() + Thread.CurrentThread.Name);
        Thread thread1 = new Thread(Iterate1);
        thread1.Name = "Thread-1";
        Console.WriteLine("Yaratildi:" + Thread.CurrentThread.ThreadState.ToString() + Thread.CurrentThread.Name);

        //Xar hil natija kutishga qarab o'zgaradi
        thread1.Start();
        Console.WriteLine("Started:" + Thread.CurrentThread.ThreadState.ToString() + Thread.CurrentThread.Name);

        Thread.Sleep(1000);

        Console.WriteLine("Hello, World!");
        Console.WriteLine("Tugadi:" + Thread.CurrentThread.ThreadState.ToString() + Thread.CurrentThread.Name);
    }

    public static void Iterate1()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString() + Thread.CurrentThread.Name);
            Thread.Sleep(300);
            Console.WriteLine(Thread.CurrentThread.Name + " => " + i);
        }
    }
}