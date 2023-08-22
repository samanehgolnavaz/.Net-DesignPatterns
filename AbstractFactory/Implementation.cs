using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{

    /// <summary>
    /// AbstractFactory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

 
    /// <summary>
    /// AbstractProduct
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }
    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }

    }
    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }
    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumShippingCostService :IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }
    public class FranceShippingCostService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }

    /// <summary>
    /// ConcreteFactory
    /// </summary>
    public class FranceShoppingCartPurchaseFactory:IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }
        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostService();
        }
    }
    /// <summary>
    /// ConcreteFactory
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }
        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostService();
        }
    }
    /// <summary>
    /// Client Class
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;
        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService =factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total Costs=" +$"{_orderCosts - (_orderCosts /100 * _discountService.DiscountPercentage)+_shippingCostsService.ShippingCosts }");
        }
    }
}
