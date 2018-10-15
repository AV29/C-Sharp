using System;
using Overriding;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(5, new Color(255, 0, 0));
            Rectangle rect1 = new Rectangle(5, 10, new Color(0, 0, 255));

            Circle circle2 = new Circle(5);
            Rectangle rect2 = new Rectangle(5, 10);

            Circle circle3 = new Circle();
            Rectangle rect3 = new Rectangle();

            Rectangle rect4 = new Rectangle(5);

            Console.WriteLine($"Circle (all props): {circle1}");
            Console.WriteLine($"Rectangle (all props): {rect1}");
            Console.WriteLine();
            Console.WriteLine($"Circle (only size props): {circle2}");
            Console.WriteLine($"Rectangle (only size props): {rect2}");
            Console.WriteLine();
            Console.WriteLine($"Circle (no props): {circle3}");
            Console.WriteLine($"Rectangle (no props): {rect3}");
            Console.WriteLine();
            Console.WriteLine($"Rectangle (one size prop): {rect4}");
            Console.ReadLine();
        }
    }
}
