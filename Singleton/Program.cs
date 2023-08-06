﻿// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using Singleton;

Console.WriteLine("Hello, World!");
//can not new because of protected constructor
//var singletonTest=new Logger();
var instance1=Logger.Instance;
var instance2=Logger.Instance;
if (instance1 == instance2 && instance2==Logger.Instance)
{
    Console.WriteLine("Instances are the same.");
}
instance1.Log($"Message from {nameof(instance1)}");
//or
instance2.Log($"Message from {nameof(instance2)}");
//or
Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");
Console.ReadLine();