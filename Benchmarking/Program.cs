using BenchmarkDotNet;
using System.Reflection;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run(Assembly.GetExecutingAssembly());
 
