using System;
namespace Task_1
{
    public class Counter
    {
        private int _counter;
        private int _min;

        public void Count(int count)
        {
            _counter += count;
            if(_counter < _min) 
            {
                _min = _counter;
                OnMinChanged(new MinChangedEventArgs(_min));
            }
        }

        public event EventHandler<MinChangedEventArgs> MinChanged;

        protected virtual void OnMinChanged(MinChangedEventArgs e) {
            MinChanged?.Invoke(this, e);
        }
    }
}
