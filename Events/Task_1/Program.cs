using System;
using Anton.Events;
using Counters;
using static System.Console;


namespace Main
{
    public class MainClass
    {

        public static void HandleMinChangedPrint(Object sender, MinChangedEventArgs e)
        {
            WriteLine($"Min changed in '{sender}'; New min: {e.NewMin}");
        }

        public static void Main(string[] args)
        {
            var c = new Counter();
            c.Count(-10);
            c.MinChanged += HandleMinChangedPrint;
            c.MinChanged += HandleMinChangedPrint;
            c.MinChanged += HandleMinChangedPrint;
            c.MinChanged += HandleMinChangedPrint;
            c.Count(-20);
        }
    }
}