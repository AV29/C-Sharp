using System;
using System.Text;
using CustomEventArgs;

namespace TwoDimensionalCollections
{
    public class Matrix<T>
    {
        private readonly T[,] _matrix;

        public int Size { get; }

        public T this[int i, int j]
        {
            get => (CheckIndex(i) && CheckIndex(j)) ? _matrix[i, j] : default(T);

            set
            {
                if (CheckIndex(i) && CheckIndex(j))
                {
                    T oldValue = _matrix[i, j];
                    _matrix[i, j] = value;
                    OnItemChanged(new MatrixChangedEventArgs<T>(i, j, oldValue, value));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result.Append(CheckIfEmptyString(i, j) ? "\"\" " : $"{this[i, j]} ");
                }
                result.AppendLine();
            }
            return result.ToString();
        }

        public event EventHandler<MatrixChangedEventArgs<T>> ItemChanged;

        protected virtual void OnItemChanged(MatrixChangedEventArgs<T> e)
        {
            ItemChanged?.Invoke(this, e);
        }

        public Matrix(int size)
        {
            Size = size;
            _matrix = new T[size, size];
        }

        private bool CheckIndex(int i) => i >= 0 && i < Size;

        private bool CheckIfEmptyString(int i, int j) {
            return typeof(T) == typeof(string) && this[i, j] as string == null;
        }
    }
}