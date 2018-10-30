using System;

namespace Anton.Events
{
    public class MinChangedEventArgs: EventArgs
    {
        public int NewMin { get; }

        public MinChangedEventArgs(int newMin)
        {
            NewMin = newMin;
        }
    }
}
