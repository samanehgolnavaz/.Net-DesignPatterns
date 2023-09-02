using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    /// <summary>
    /// Prototype
    /// </summary>
    public abstract class Person
    {
        public abstract string Name { get; set; }
        public abstract Person Clone(bool deepClone);

    }
    /// <summary>
    /// ConcreatePrototype
    /// </summary>
    public class Manager : Person
    {
        public override string Name {get;set; }
        public Manager(string name )
        {
            Name = name;
        }
        public override Person Clone(bool deepClone=false)
        {
            if( deepClone )
            {
              var objectAsJson=JsonConvert.SerializeObject(this);
               return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }

            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public Manager Manager { get; set; }
        public override string Name { get; set; }
        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }
        public override Person Clone(bool deepClone=false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }

            return (Person)MemberwiseClone();
        }
    }
}
