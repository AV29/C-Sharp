using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Key_Struct;

namespace Structs_Enums_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Key c = new Key(Note.C, Accidental.Sharp, Octave.First);
            Key d = new Key(Note.D, Accidental.Flat, Octave.First);

            Console.WriteLine(c);
            Console.WriteLine(c.Equals(d));
            Console.WriteLine(d.Equals(c));

            Console.ReadLine();
        }
    }
}
