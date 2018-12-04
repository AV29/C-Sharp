using System.Text;
using System.Collections.Generic;
using System;

namespace SparseMatrixSpace
{
    public class SparseMatrix
    {
        private Dictionary<(int, int), int> _store;

        public int Size { get; }

        public int FillPercentage { get; }

        public int this[int i, int j]
        {
            get { 
                if(CheckIndex(i) && CheckIndex(j)) {
                    return _store.ContainsKey((i, j)) ? _store[(i, j)] : 0;
                }  else {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public SparseMatrix(int size, int maxZerosPersentage = 85)
        {
            Random random = new Random();
            int fillPercentage = random.Next(7, 15);
            FillPercentage = fillPercentage;
            Size = size;
            _store = new Dictionary<(int, int), int>();
            for (int i = 0; i < size * size * fillPercentage / 100; i++)
            {
                _store[((int)random.Next(0, Size), (int)random.Next(0, Size))] = (int)random.Next(1, 10);
            }
        }

        public int CheckCount(int x) {
            if(x == 0) {
                return Size * Size - _store.Count;
            } else {
                int count = 0;
                foreach(int value in _store.Values) {
                    if (value == x) count++;
                }
                return count;
            }
        }

        public int Track() {
            int result = 0;
            for (int i = 0; i < Size; i++) {
                result += this[i, i];
            }
            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result.Append($"{this[i, j]} ");
                }
                result.AppendLine();
            }
            return result.ToString();
        }

        private bool CheckIndex(int i) => i >= 0 && i < Size;
    }
}
