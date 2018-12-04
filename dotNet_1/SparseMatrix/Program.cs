using System;

namespace SparseMatrixSpace
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SparseMatrix matrix = new SparseMatrix(15);

            Console.WriteLine(matrix);
            Console.WriteLine($"{matrix.FillPercentage}% of matrix is filled with non-Zero values");
            Console.WriteLine($"Sum of elements on main diagonal is: {matrix.Track()}");
            int randomNumber = (new Random()).Next(0, 10);
            Console.WriteLine($"Element {randomNumber} is met {matrix.CheckCount(randomNumber)} times");
            Console.WriteLine("Elements on main diagonal are: ");
            foreach(var item in matrix) {
                Console.Write($"{item} ");
            }
        }
    }
}
