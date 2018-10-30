using System;

namespace CustomEventArgs
{
    public class MatrixChangedEventArgs<T> : EventArgs
    {
        public int I { get; }

        public int J { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        public MatrixChangedEventArgs(int i, int j, T oldValue, T newValue)
        {
            I = i;
            J = j;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
