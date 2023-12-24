namespace Delegates
{
    public class Methods
    {
        public void SalomBer()
            => Console.WriteLine("Salomat");

        public int RaqamBer()
            => new Random().Next(1,100);

        public bool MantiqBer(int num)
            => true;

        public void Start(Action action)
            => action.Invoke();
    }
}
