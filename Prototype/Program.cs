// See https://aka.ms/new-console-template for more information
using Prototype;

Console.WriteLine("Hello, World!");
var manager = new Manager("Cindy");
var managerClone=(Manager)manager.Clone();
Console.WriteLine($"Manager was Clones :{managerClone.Name}");
var employee = new Employee("Kevin", manager);
var employeeClone = (Employee)managerClone.Clone(true);
Console.WriteLine($"Employee was Clones :{employeeClone.Name}"+
    $"with manager{employeeClone.Manager.Name}");
Console.ReadKey();