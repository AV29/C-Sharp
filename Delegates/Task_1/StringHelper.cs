using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public static class StringHelper
    {
        public static string PrependWith(this string input, string startMessage)
        {
            return new StringBuilder(startMessage).Append(input).AppendLine().ToString();
        }

        public static void ToConsole(this string input)
        {
            Console.WriteLine(input);
        }
    }
}
