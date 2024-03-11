using BenchmarkDotNet.Running;

namespace ERS.playground.Lists.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run<AnyVsExistsBenchmark>();
            Console.WriteLine("Sucess!!!");
        }
    }
}
