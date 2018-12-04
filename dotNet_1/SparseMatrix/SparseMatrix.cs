using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace SparseMatrixSpace
{
    public class SparseMatrix: IEnumerable<int>
    {
        private Dictionary<(int, int), int> store;

        public int Size { get; }

        public int FillPercentage { get; }

        public int this[int i, int j]
        {
            get { 
                if(CheckIndex(i) && CheckIndex(j)) {
                    return store.ContainsKey((i, j)) ? store[(i, j)] : 0;
                }  else {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public SparseMatrix(int size, int maxFillPersentage = 15)
        {
            Random random = new Random();
            int fillPercentage = random.Next(1, maxFillPersentage);
            FillPercentage = fillPercentage;
            Size = size;
            store = new Dictionary<(int, int), int>();
            for (int i = 0; i < size * size * fillPercentage / 100; i++)
            {
                store[((int)random.Next(0, Size), (int)random.Next(0, Size))] = (int)random.Next(1, 10);
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
            return result.ToString();
        }

        private bool CheckIndex(int i) => i >= 0 && i < Size;
    }
}
