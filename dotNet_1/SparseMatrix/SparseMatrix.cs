using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace SparseMatrixSpace
{
    public class SparseMatrix: IEnumerable<int>
    {
        private Dictionary<(int, int), int> store;

        private int fillPercentage;

        public int Size { get; }

        public int this[int i, int j]
        {
            get { 
                if(CheckIndex(i) && CheckIndex(j)) {
                    return store.ContainsKey((i, j)) ? store[(i, j)] : 0;
                }  else {
                    throw new ArgumentOutOfRangeException();
                }
            }

            set {
                if(CheckIndex(i) && CheckIndex(j) && value != 0) {
                    store[(i, j)] = value;
                }
            }
        }

        public SparseMatrix(int size, bool autoGenerate = true)
        {
            Size = size;
            store = new Dictionary<(int, int), int>();
            if (autoGenerate)
            {
                Random random = new Random();
                fillPercentage = random.Next(1, 15);
                for (int i = 0; i < size * size * fillPercentage / 100; i++)
                {
                    store[((int)random.Next(0, Size), (int)random.Next(0, Size))] = (int)random.Next(1, 10);
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                yield return this[i, i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CheckCount(int x) {
            if(x == 0) {
                return Size * Size - store.Count;
            } else {
                int count = 0;
                foreach(int value in store.Values) {
                    if (value == x) count++;
                }
                return count;
            }
        }

        public int Track() {
            int result = 0;
            foreach (var value in this) {
                result += value;
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
            result.AppendLine();
            if(fillPercentage != 0) {
                result.Append($"{fillPercentage}% of matrix is filled with non-Zero values");
            }
            return result.ToString();
        }

        private bool CheckIndex(int i) => i >= 0 && i < Size;
    }
}
