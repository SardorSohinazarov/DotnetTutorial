internal class Program
{
    public static void Main(string[] args)
    {
        ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
        processBusinessLogic.ProcessCompleted += (sender, eventArgs) => Console.WriteLine("Sardor Sohinazarov");

        processBusinessLogic.StartProcess();
    }
}