using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bridge
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICopoun _copoun = null;
        public abstract int CaclculatePrice();
        public Menu(ICopoun copoun)
        {
            _copoun = copoun;
        }
    }
    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICopoun copoun) : base(copoun)
        {
        }
        public override int CaclculatePrice()
        {
            return 20 - _copoun.CopounValue;
        }
    }
    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class MeatBaseMenu : Menu
    {
        public MeatBaseMenu(ICopoun copoun) : base(copoun)
        {
        }
        public override int CaclculatePrice()
        {
            return 30 - _copoun.CopounValue;
        }
    }
    /// <summary>
    /// Implemetor
    /// </summary>
    public interface ICopoun
    {
         int CopounValue { get; }
    }
    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class NoCoupon : ICopoun
    {
        public int CopounValue { get => 0; }
    }
    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class OneEuroCopoun : ICopoun
    {
        public int CopounValue { get => 1; }

    }
    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class TwoEuroCopoun : ICopoun
    {
        public int CopounValue { get => 2; }

    }

}
