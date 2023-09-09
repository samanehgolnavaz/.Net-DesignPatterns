namespace _02_Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var noCoupon=new NoCoupon();
            var oneEuroCoupon = new OneEuroCopoun();
            var meatBaseMenu=new MeatBaseMenu(noCoupon);
            Console.WriteLine($"Meat based menu, no copun:{meatBaseMenu.CaclculatePrice()}euro.");
            meatBaseMenu = new MeatBaseMenu(oneEuroCoupon);
            Console.WriteLine($"Meat based menu, one euro copun:{meatBaseMenu.CaclculatePrice()}euro.");
            var vegetarianMenu=new VegetarianMenu(noCoupon);
            Console.WriteLine($"Vegetarian menu, no copun:{vegetarianMenu.CaclculatePrice()}euro.");
             vegetarianMenu = new VegetarianMenu(oneEuroCoupon);
            Console.WriteLine($"Vegetarian menu, one euro copun:{vegetarianMenu.CaclculatePrice()}euro.");
            Console.ReadKey();


        }
    }
}