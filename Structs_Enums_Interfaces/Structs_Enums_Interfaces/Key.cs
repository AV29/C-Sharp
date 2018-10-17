using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_Struct
{
    public struct Key
    {
        private Note _initialNote;
        public Note Note { get; }
        public Accidental Accidental { get; }
        public Octave Octave { get; }

        public override bool Equals(object obj)
        {
            Key key = (Key)obj;
            if (obj == null)
            {
                return false;
            }

            if (key.Octave == Octave)
            {
                return true;
            } else if(Math.Abs(key.Octave - Octave) == 1)
            {
                return Math.Abs(key.Note - Note) == 13 || (short)key.Note == (short)Note;
            } else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{_initialNote}{(char)Accidental} ({(byte)Octave})";
        }

        public Key(Note note, Accidental accidental, Octave octave)
        {
            _initialNote = note;
            if(accidental == Accidental.Sharp)
            {
                Note = (Note)((short)note + 1);
            } else if(accidental == Accidental.Flat)
            {
                Note = (Note)((short)note - 1);
            } else
            {
                Note = note;
            }
            
            Accidental = accidental;
            Octave = octave;
        }
    }
}