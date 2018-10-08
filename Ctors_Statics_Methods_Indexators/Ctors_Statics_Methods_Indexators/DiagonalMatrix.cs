using System;
using System.Text;

namespace Ctors_Statics_Methods_Indexators
{
    public class DiagonalMatrix
    {
        private int[] _mainDiagonal;

        public int Size { get; }

        public int this[int i, int j]
        {
            get => CheckIndex(i) && CheckIndex(j) && (i == j) ? _mainDiagonal[i] : 0;

            set
            {
                if (CheckIndex(i) && CheckIndex(j) && (i == j))
                {
                    _mainDiagonal[i] = value;
                }
            }
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

        public DiagonalMatrix(params int[] mainDiagonalElements)
        {
            if (mainDiagonalElements == null || mainDiagonalElements.Length == 0)
            {
                Size = 0;
                _mainDiagonal = new int[Size];
            }
            else
            {
                Size = mainDiagonalElements.Length;
                _mainDiagonal = new int[Size];
                for (int i = 0; i < Size; i++)
                {
                    _mainDiagonal[i] = mainDiagonalElements[i];
                }
            }
        }

        public int Track()
        {
            int sum = 0;
            foreach (var element in _mainDiagonal)
            {
                sum += element;
            }
            return sum;
        }

        public DiagonalMatrix Add(DiagonalMatrix addedMatrix)
        {
            int newMatrixLength = Math.Max(addedMatrix.Size, this.Size);
            int[] newMainDiagonal = new int[newMatrixLength];
            for (int i = 0; i < newMatrixLength; i++)
            {
                newMainDiagonal[i] = this[i, i] + addedMatrix[i, i];
            }

            return new DiagonalMatrix(newMainDiagonal);
        }

        public static DiagonalMatrix Identity(int n)
        {
            if (n < 0)
            {
                return new DiagonalMatrix(new int[0]);
            } else
            {
                int[] mainDiagonal = new int[n];
                for (int i = 0; i < n; i++)
                {
                    mainDiagonal[i] = 1;
                }
                return new DiagonalMatrix(mainDiagonal);
            }
        }

        private bool CheckIndex(int i) => i >= 0 && i < Size;
    }
}
