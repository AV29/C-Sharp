using System;
namespace Structs_Enums_Interfaces
{
    public struct Key_UPD
    {
        public char Representation { get; }

        public override int GetHashCode()
        {
        }

        public override bool Equals(object obj)
        {
            Key key = (Key)obj;
            if (obj == null)
            {
                return false;
            }
        }

        public override string ToString()
        {
            string octave;
            switch (Octave)
            {
                case Octave.Subcontra:
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

        }

        public Key_UPD(Note note, Accidental accidental, Octave octave)
        {

        }
    }
}
