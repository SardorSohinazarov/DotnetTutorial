namespace Collections2
{
    public static class Extensions
    {
        public static void ConsolegaChiqar(this string value)
        {
            Console.WriteLine(value);
        }

        public static int IkkigaKopaytir(this int value)
        {
            return 2 * value;
        }

        public static bool Taqqosla(this Product product, Product product1)
        {
            return product.Id == product1.Id && product.Name == product1.Name;
        }
    }
}
