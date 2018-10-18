using System;

namespace Structs_Enums_Interfaces
{
    public struct Key : IComparable
    {
        private readonly Note _noteBase;

        private readonly bool _outOfRange;

        public Note Note { get; }

        public Accidental Accidental { get; }

        public Octave Octave { get; }

        public override int GetHashCode()
        {
            return (byte)Note ^ (byte)Accidental;
        }

        public override bool Equals(object obj)
        {
            Key key = (Key)obj;
            if (obj == null)
            {
                return false;
            }

            if (key.Octave == Octave)
            {
                return key.Note == Note;
            } else if((key.Octave - Octave) == 1)
            {
                return (key.Note - Note) == 13 || key.Note == Note;
            } else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string octave;
            switch (Octave)
            {
                case Octave.Subcontra :
                    {
                        octave = "subcontra";
                        break;
                    }
                case Octave.Contra:
                    {
                        octave = "contra";
                        break;
                    }
                case Octave.Big:
                    {
                        octave = "big";
                        break;
                    }
                case Octave.Small:
                    {
                        octave = "small";
                        break;
                    }
                default:
                    octave = $"{(byte)Octave - 3}";
                    break;
            }
            return $"{_noteBase}{(char)Accidental} ({octave}) {(_outOfRange ? " - Out Of Range!!!" : "")}";
        }

        public int CompareTo(object obj) 
        {
            Key key = (Key)obj;
            return Math.Abs(((byte)key.Octave - (byte)Octave) * 12 + (byte)key.Note - (byte)Note);
        }

        public Key(Note note, Accidental accidental, Octave octave)
        {
            _noteBase = note;
            short accidentalOffset = 0;
            if (accidental == Accidental.Sharp)
            {
                accidentalOffset = 1;
            }
            else if (accidental == Accidental.Flat)
            {
                accidentalOffset = -1;
            }

            // Should consider throwing an exception here but let's just set corner values.

            if (octave == Octave.Subcontra && (byte)note + accidentalOffset < 10)
            {
                Note = (Note)10;
                _outOfRange = true;
            }
            else if (octave == Octave.Fifth && (byte)note + accidentalOffset > 1)
            {
                Note = (Note)1;
                _outOfRange = true;
            }
            else
            {
                Note = (Note)((byte)note + accidentalOffset);
                _outOfRange = false;
            }
            Accidental = accidental;
            Octave = octave;
        }
    }
}