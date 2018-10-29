using System;

namespace Task_1
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
