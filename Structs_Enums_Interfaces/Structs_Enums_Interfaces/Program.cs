using System;

namespace Structs_Enums_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Key c = new Key(Note.C, Accidental.Sharp, Octave.First);
            Key d = new Key(Note.D, Accidental.Flat, Octave.First);

            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(d.Equals(c));
            Console.WriteLine(d.CompareTo(c));
        }
    }
}
