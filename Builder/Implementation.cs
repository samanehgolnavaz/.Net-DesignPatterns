using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    /// <summary>
    /// product
    /// </summary>
    public  class Car 
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType; 
        }
        public void AddPart(string part)
        {
            _parts.Add(part);
        }
        public override string ToString()
        {
            var sb=new StringBuilder();
            foreach (string  part in _parts)
            {
                sb.Append($"Car of type {_carType} has part {part}.");
            }
            return sb.ToString();
        }
    }
    /// <summary>
    /// Builder
    /// </summary>
    public abstract class CarBuilder
    {
        public CarBuilder(string  carType)
        {
            Car = new Car(carType);
        }

        public Car Car { get;  set; }
        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }
    /// <summary>
    /// Concrete Builder
    /// </summary>
    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder(): base ("Mini") 
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'not a V8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'3-door with stripes'");
        }
    }
    /// <summary>
    /// Concreate Builder
    /// </summary>
    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder():base("BMW")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'a fancy V* engine'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'5-door with metallic finish'");
        }
    }
    /// <summary>
    /// Director
    /// </summary>
    public class Garage
    {
        private CarBuilder? _builder;
        public Garage()
        {
            
        }
        ///inject doing with construct method
        public void Construct(CarBuilder builder)
        {
            _builder = builder;
            _builder.BuildEngine();
            _builder.BuildFrame();
        }
        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }
    }
}
