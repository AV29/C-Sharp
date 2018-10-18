using System.Text;

namespace Generics
{
    public class Stack<T> : IStack<T>
    {
        private readonly T[] data;

        private int _index;

        public int Limit { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _index; i++) {
                result.Append($"{(data[i])} ");
            }
            return result.ToString();
        }

        public Stack(int limit) 
        {
            Limit = limit;
            data = new T[limit];
        }

        public T Pop()
        {
            return !IsEmpty() ? data[--_index] : default(T);
        }

        public bool IsEmpty()
        {
            return _index == 0;
        }

        public void Push(T el)
        {
            if (_index < data.Length)
            {
                data[_index++] = el;
            }
        }
    }
}
