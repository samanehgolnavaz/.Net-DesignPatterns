namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICityAdapter adapter = new CityAdapter();
            var city=adapter.GetCity();
            Console.WriteLine($"{city.FullName},{city.Inhabitants}");
            Console.ReadKey();
        }
    }
}