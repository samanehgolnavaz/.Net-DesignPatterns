﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }
    /// <summary>
    /// ConcreateStrategy
    /// </summary>
    public class JsonExportService :IExportService 
    {
       public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to Json.");
        }
    }
    /// <summary>
    /// ConcreateStrategy
    /// </summary>
    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML.");
        }
    }
    /// <summary>
    /// ConcreateStrategy
    /// </summary>
    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV.");
        }
    }
    /// <summary>
    /// Context
    /// </summary>
    public class Order
    {
        public string  Customer { get; set; }
        public int Amount { get; set; }
        public string   Name { get; set; }
        public string? Description { get; set; }
       //public IExportService? ExportService { get; set; }   
        public Order(string customer, int amount, string name)
        {
            Customer = customer;
            Amount = amount;
            Name = name;
        }
        //First Implementation
        //public  void Export()
        //{
        //    ExportService?.Export(this);
        //}
        public void Export(IExportService exportService)
        {
            if(exportService is null)
            {
                throw new ArgumentNullException(nameof(exportService));
            }
            exportService.Export(this);
        }

    }

}
