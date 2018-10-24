using System;

namespace Task_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var f = Generator("f");
            f();
            f();
            f();
            var g = Generator("g");
            g();
            g();
        }

        private static Action Generator(string funcName)
        {
            int callCounter = 0;
            return () => Console.WriteLine($"{funcName} was called {++callCounter} times");
        }
    }
}
