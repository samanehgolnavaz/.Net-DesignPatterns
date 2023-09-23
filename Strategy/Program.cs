// See https://aka.ms/new-console-template for more information

using Strategy;

var order = new Order("Marvin Software", 5, "Visual Studion License");
//order.ExportService=new CSVExportService();
//order.Export();
order.Export(new CSVExportService());

//order.ExportService=new JsonExportService();
//order.Export();
order.Export(new JsonExportService());
Console.ReadKey();
