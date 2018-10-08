using System;

namespace Ctors_Statics_Methods_Indexators
{
    public class Program
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
}
