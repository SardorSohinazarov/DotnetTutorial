namespace OOP_Intro;

public class LyuboyBitta
{
    public LyuboyBitta()
    {
        Console.WriteLine("Salom Constrictordan");
    }

    public static void SalomBer()
    {
        Console.WriteLine("Qaleslar endi");
    }

    ~LyuboyBitta(){
        Console.WriteLine("Salom Destruktordan");
    }
}
