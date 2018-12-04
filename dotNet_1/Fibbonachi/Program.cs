using System;
using System.Linq;

namespace Fibbonachi
{
    static class MainClass
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("----------------- With Regular Method --------------------");
            Console.WriteLine("Hello World!");
            foreach (var i in FibonacciHelper.TakeNFibs(0, 1, 10)) {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------------- With LINQ --------------------");
            foreach (var i in FibonacciHelper.Fibonacchi(0, 1).Take(10))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------------- With Extension Method --------------------");
            foreach (var i in FibonacciHelper.Fibonacchi(0, 1).TakeFibs(10))
            {
                Console.WriteLine(i);
            }
        }
    }
}
