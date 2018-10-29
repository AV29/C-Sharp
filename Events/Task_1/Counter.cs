using System;
namespace Task_1
{

    //public delegate void Handler(int x);

    public class Counter
    {
        private int _counter;
        private int _min;
        private  EventHandler<MinChangedEventArgs> Slots;

        public void Count(int count)
        {
            _counter += count;
            if(_counter < _min) 
            {
                _min = _counter;
                OnMinChanged(new MinChangedEventArgs(_min));
            }
        }

        public override string ToString()
        {
            return "Counter";
        }

        public event EventHandler<MinChangedEventArgs> MinChanged 
        {
            add
            {
                Delegate.Combine(Slots, value);
            }

            remove
            {
                Delegate.Remove(Slots, value);
            }
        }

        protected virtual void OnMinChanged(MinChangedEventArgs e) {
            MinChanged?.Invoke(this, e);
        }
    }
}
