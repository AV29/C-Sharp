using System;

namespace Generics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Array limit");
            int lim = int.Parse(Console.ReadLine());
            Stack<int> int_stack = new Stack<int>(lim);
            Stack<string> string_stack = new Stack<string>(lim);

            int_stack.Push(10);
            int_stack.Push(12);
            int_stack.Push(15);

            string_stack.Push("Hello");
            string_stack.Push("World");
            string_stack.Push("!");
            string_stack.Pop();
            string_stack.Pop();
            Console.WriteLine(string_stack.IsEmpty());
            string_stack.Push("Anton");
            string_stack.Pop();
            string_stack.Pop();
            Console.WriteLine(string_stack.IsEmpty());
            string_stack.Push("World");

            Console.WriteLine(int_stack);
            Console.WriteLine(string_stack);

            Console.WriteLine(int_stack.Reverse());

        }
    }
}
