using System;

namespace Structs_Enums_Interfaces
{
    public struct Key : IComparable
    {
        public byte NoteNumber { get; }

        public Accidental Acc { get; }

        public override int GetHashCode()
        {
            return (byte)NoteNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Key key = (Key)obj;
            if (obj == null)
            {
                return false;
            }
            return key.NoteNumber == NoteNumber;
        }

        public override string ToString()
        {
            string octave;
            string accidental;
            Octave oct = GetOctaveFromNoteNumber(NoteNumber);
            Note note = GetNoteFromNoteNumber(NoteNumber);
            switch (oct)
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
                    octave = $"{(byte)oct - 2}";
                    break;
            }
            switch (Acc)
            {
                case Accidental.Sharp:
                    {
                        accidental = "#";
                        break;
                    }
                case Accidental.Flat:
                    {
                        accidental = "b";
                        break;
                    }
                default:
                    accidental = string.Empty;
                    break;
            }
            return $"{note}{accidental} ({octave})";
        }

        public int CompareTo(object obj) 
        {
            Key key = (Key)obj;
            return key.NoteNumber - NoteNumber;
        }

        public Key(Note note, Accidental accidental, Octave octave)
        {
            Acc = accidental;
            NoteNumber = GetNoteNumber(note, accidental, octave);
        }

        private static byte GetNoteNumber(Note note, Accidental accidental, Octave octave)
        {
            if (octave == Octave.Subcontra && (byte)note + (sbyte)accidental < (byte)Note.A)
            {
                return 1;
            }
            else if (octave == Octave.Fifth && (byte)note + (sbyte)accidental > (byte)Note.C)
            {
                return 88;
            }
            else
            {
                return (byte)((byte)octave * 12 + (byte)note + (sbyte)accidental + 3);
            }
        }

        private Octave GetOctaveFromNoteNumber(byte noteNumber)
        {
            if(noteNumber - (sbyte)Acc < 4)
            {
                return Octave.Subcontra;
            } else
            {
                return (Octave)((noteNumber - (sbyte)Acc - 4) / 12);
            }
        }

        private Note GetNoteFromNoteNumber(byte noteNumber)
        {
            sbyte octave = (sbyte)GetOctaveFromNoteNumber(NoteNumber);
            return octave != -1 ? (Note)(octave * 12 + 5 + (sbyte)Acc - noteNumber) : (Note)(9 - (sbyte)Acc + noteNumber);
        }
    }
}