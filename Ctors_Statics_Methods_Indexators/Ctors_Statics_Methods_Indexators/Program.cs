using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctors_Statics_Methods_Indexators
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix matrix_1 = new DiagonalMatrix(5, 3, 4, 2);
            Console.WriteLine("Here's matrix 1: ");
            Console.WriteLine(matrix_1);
            Console.WriteLine($"Diagonal elements Sum for matrix_1 is: {matrix_1.Track()}");

            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Enter indexes to look for an element in matrix: ");
            int i = int.Parse(Console.ReadLine());
            int j = int.Parse(Console.ReadLine());
            Console.WriteLine($"Element on {i}:{j} position is - {matrix_1[i, j]}");

            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Enter size for the second matrix: ");
            int sizeMatrix_2 = int.Parse(Console.ReadLine());
            int[] mainDiagonalMatrix_2 = new int[sizeMatrix_2];

            Console.WriteLine("Enter diagonal elements for the second matrix: ");
            for(int k = 0; k < sizeMatrix_2; k++)
            {
                mainDiagonalMatrix_2[k] = int.Parse(Console.ReadLine());
            }

            DiagonalMatrix matrix_2 = new DiagonalMatrix(mainDiagonalMatrix_2);
            Console.WriteLine("Here's matrix 2: ");
            Console.WriteLine(matrix_2);
            Console.WriteLine($"Diagonal elements Sum for matrix_2 is: {matrix_2.Track()}");

            Console.WriteLine("Sum of matrix_1 and matrix_2 is: ");
            Console.WriteLine(matrix_1.Add(matrix_2));

            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Enter size for identity matrix: ");
            int identitySize = int.Parse(Console.ReadLine());
            Console.WriteLine("Your Identity Matrix: ");
            Console.WriteLine(DiagonalMatrix.Identity(identitySize));
            Console.ReadLine();
        }
    }

    class DiagonalMatrix
    {
        private int[] mainDiagonal;
        public int Size {get;}

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Size; i++) 
            {
                for(int j = 0; j < Size; j++)
                {
                    result += $"{this[i, j]} ";
                }
                result += "\n";
            }
            return result;
        }

        public DiagonalMatrix(params int[] mainDiagonalElements)
        {
            if (mainDiagonalElements == null)
            {
                Size = 0;
                mainDiagonal = new int[Size];
            }
            else
            {
                Size = mainDiagonalElements.Length;
                mainDiagonal = new int[Size];
                for (int i = 0; i < Size; i++)
                {
                    mainDiagonal[i] = mainDiagonalElements[i];
                }
            }

        }

        public int this[int i, int j]
        {
            get
            {
                if(i >= Size || j >= Size)
                {
                    return 0;
                }

                if (i != j)
                {
                    return 0;
                }
                else
                {
                    return mainDiagonal[i];
                }
            }

            set
            {
                if ((i < Size || j < Size) && i == j)
                {
                    mainDiagonal[i] = value;
                }
            }
        }

        public int this[int i]
        {
            get => i >= Size || i < 0 ? 0 : mainDiagonal[i];
        }

        public int Track()
        {
            int sum = 0;
            foreach (var element in mainDiagonal)
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
                newMainDiagonal[i] = this[i] + addedMatrix[i];
            }

            return new DiagonalMatrix(newMainDiagonal);
        }

        public static DiagonalMatrix Identity(int n)
        {
            int[] mainDiagonal = new int[n];
            for (int i = 0; i < n; i++)
            {
                mainDiagonal[i] = 1;
            }
            return new DiagonalMatrix(mainDiagonal);
        }
    }
}
