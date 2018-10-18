using System;

namespace Structs_Enums_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Key z = new Key(Note.C, Accidental.Flat, Octave.Contra);
            Key y = new Key(Note.C, Accidental.Flat, Octave.Fifth);

            Console.WriteLine(z);
            Console.WriteLine(y);
            Console.WriteLine(y.Equals(z));
            Console.WriteLine(z.Equals(y));
            Console.WriteLine(y.CompareTo(z));
            Console.WriteLine(z.CompareTo(y));
            Console.ReadLine();
        }
    }
}
