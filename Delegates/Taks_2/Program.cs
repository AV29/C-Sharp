using System;

namespace Taks_2
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Calendar(Season.Spring));

            Console.WriteLine(new Calendar(Season.Spring, Localization.Ru));

            Console.WriteLine(new Calendar(Season.Spring, Localization.Es));

            Console.ReadLine();

        }
    }
}