using System;
using Anton.Events;

namespace Counters
{

    public class Counter
    {
        private int _counter;

        private int _min;

        private event EventHandler<MinChangedEventArgs> _minChangedEvent;

        public override string ToString()
        {
            return "Counter";
        }

        public event EventHandler<MinChangedEventArgs> MinChanged
        {
            add
            {
                if (_minChangedEvent == null || _minChangedEvent.GetInvocationList().Length < 3)
                {
                    _minChangedEvent += value;
                }
                else
                {
                    Console.WriteLine("Use of more than 3 subscribers for MinChanged event is forbidden.");
                }
            }

            remove => _minChangedEvent -= value;
        }

        protected virtual void OnMinChanged(MinChangedEventArgs e) {
            _minChangedEvent?.Invoke(this, e);
        }

        public void Count(int count)
        {
            _counter += count;
            if(_counter < _min) 
            {
                _min = _counter;
                OnMinChanged(new MinChangedEventArgs(_min));
            }
        }
    }
}
