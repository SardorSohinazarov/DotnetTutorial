using Library.Interfaces;

namespace Library.Models
{
    public partial class Kitob:IKitobService
    {
        public Kitob(string nom, string muallif)
        {
            Nomi = nom;
            Muallifi = muallif;
        }
    }
}
