using System;

namespace SparseMatrixSpace
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            int randomNumber = (new Random()).Next(0, 10);

            SparseMatrix autoFilledMatrix = new SparseMatrix(15);
            SparseMatrix manualyFilledMatrix = new SparseMatrix(15, false);

            Console.WriteLine(autoFilledMatrix);
            Console.WriteLine($"Sum of elements on main diagonal is: {autoFilledMatrix.Track()}");
            Console.WriteLine($"Element {randomNumber} is met {autoFilledMatrix.CheckCount(randomNumber)} times");
            Console.Write("Elements on main diagonal are: ");
            foreach(var item in autoFilledMatrix) {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");

            Random number = new Random();
            int randomIndex = 0;
            for (int i = 0; i < manualyFilledMatrix.Size; i++) {
                randomIndex = number.Next(1, manualyFilledMatrix.Size);
                for (int j = 0; j < manualyFilledMatrix.Size; j++) {
                    manualyFilledMatrix[i, j] = j == randomIndex ? number.Next(1, 9) : 0;
                }
            }
            Console.WriteLine(manualyFilledMatrix);
            Console.WriteLine($"Sum of elements on main diagonal is: {manualyFilledMatrix.Track()}");
            Console.WriteLine($"Element {randomNumber} is met {manualyFilledMatrix.CheckCount(randomNumber)} times");
            Console.WriteLine("Elements on main diagonal are: ");
            foreach (var item in manualyFilledMatrix)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
