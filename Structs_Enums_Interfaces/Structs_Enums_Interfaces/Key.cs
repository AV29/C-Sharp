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
            return obj != null && ((Key)obj).NoteNumber == NoteNumber;
        }

        public override string ToString()
        {
            string accidental = GetAccidentalName(Acc);
            Octave octave = GetOctaveFromNoteNumber(NoteNumber);
            Note note = GetNoteFromNoteNumber(NoteNumber, (sbyte)octave);

            return $"{note}{accidental} ({GetOctaveName(octave)})";
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

        private string GetOctaveName(Octave octave) 
        {
            return (sbyte)octave > 2 ? ((sbyte)octave - 2).ToString() : octave.ToString();
        }

        private string GetAccidentalName(Accidental acceidental) 
        {
            if(acceidental == Accidental.Sharp) {
                return "#";
            } else if(acceidental == Accidental.Flat) {
                return "b";
            } else {
                return string.Empty;
            }
        }

        private Octave GetOctaveFromNoteNumber(byte noteNumber)
        {
            return noteNumber - (sbyte)Acc < 4 ? Octave.Subcontra : (Octave)((noteNumber - (sbyte)Acc - 4) / 12);
        }

        private Note GetNoteFromNoteNumber(byte noteNumber, sbyte octave)
        {
            return octave != -1 ? (Note)(octave * 12 + 5 + (sbyte)Acc - noteNumber) : (Note)(9 - (sbyte)Acc + noteNumber);
        }
    }
}