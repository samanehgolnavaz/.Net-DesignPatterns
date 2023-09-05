using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAdapter
{
    /// <summary>
    /// ExternalSystem
    /// </summary>
    public class CityFromExternalSystem
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Inhabitants { get; set; }
        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }
    }
    /// <summary>
    /// adaptee
    /// </summary>
    public class EcxternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Antwerp", "'t stad'", 500000);
        }
    }
    public class City
    {
        public string FullName { get; private set; }
        public long Inhabitants { get; private set; }
        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }
    }
    /// <summary>
    /// Target
    /// </summary>
    public interface ICityAdapter
    {
        City GetCity();
    }
    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdapter : EcxternalSystem, ICityAdapter
    {
        public City GetCity()
        {
            //call into the external system
            var cityFromExternalSystem = base.GetCity();
            //adapt the cityFromExternalCity to a City
            return new City(
                $"{cityFromExternalSystem.Name}-{cityFromExternalSystem.NickName}"
                , cityFromExternalSystem.Inhabitants);
        }
    }
}
