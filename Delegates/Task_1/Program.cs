using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] int_array = { -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6 };
            bool[] bool_array = { true, false, true, true, false };
            string[] string_array = { "Hello", "C#", "You", "are", "an", "awesome", "&", "great", "language", "!" };
            string[] specialSymbols = { "!", "#", "-", "$", "%", "^", "&", "*" };
            Person[] object_array = { new Person { Name = "John", Age = 15 }, new Person { Name = "Frank", Age = 29 }, new Person { Name = "Alfred", Age = 57 }, new Person { Name = "Francois", Age = 80 } };
            Person testObj = new Person { Name = "Alfred", Age = 59 };

            int_array.ArrayOutput().PrependWith("Integer Array: ").ToConsole();
            int_array.Filter(num => num % 2 == 0).ArrayOutput().PrependWith("Even Numbers:  ").ToConsole();
            int_array.Filter(num => num % 2 != 0).ArrayOutput().PrependWith("Odd Numbers:  ").ToConsole();
            int_array.Filter(num => num < 0).ArrayOutput().PrependWith("Negative Numbers:  ").ToConsole();
            int_array.Filter(num => num > 0).ArrayOutput().PrependWith("Positive Numbers:  ").ToConsole();

            Console.WriteLine();

            string_array.ArrayOutput().PrependWith("String Array: ").ToConsole();
            string_array.Filter(str => str.Length > 3).ArrayOutput().PrependWith("Words with more than 3 letters:  ").ToConsole();
            string_array.Filter(str => str.Length < 3).ArrayOutput().PrependWith("Words with less than 3 letters:  ").ToConsole();
            string_array.Filter(str => specialSymbols.Filter(symbol => str.Contains(symbol)).Length > 0).ArrayOutput().PrependWith("Words with special symbols (with Filter):  ").ToConsole();
            string_array.Filter(str => specialSymbols.Some(symbol => str.Contains(symbol))).ArrayOutput().PrependWith("Words with special symbols: (with Some):  ").ToConsole();

            Console.WriteLine();

            object_array.ArrayOutput().PrependWith("Object Array: ").ToConsole();
            object_array.Filter(obj => obj.Name.Length > 5).ArrayOutput().PrependWith("Persons name has more than 5 letters:  ").ToConsole();
            object_array.Filter(obj => obj.Age < 50).ArrayOutput().PrependWith("Persons younger than 50: ").ToConsole();
            object_array.Filter(obj => obj.Equals(testObj)).ArrayOutput().PrependWith("Same persons as Alfred, 57 years old:  ").ToConsole();

            Console.WriteLine();

            bool_array.ArrayOutput().PrependWith("Boolean Array: ").ToConsole();
            bool_array.Filter(obj => !obj).ArrayOutput().PrependWith("Only falsy values left:  ").ToConsole();

            Console.ReadLine();
        }
    }
}
