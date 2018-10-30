using System;
using TwoDimensionalCollections;
using CustomEventArgs;
using static System.Console;

namespace Main
{
    public class MainClass
    {
        public static void MatrixChangedHandler<T>(Object sender, MatrixChangedEventArgs<T> e) {
            WriteLine($"Indexes {e.I} : {e.J}");
            WriteLine($"Old Value = {e.OldValue}");
            WriteLine($"New Value = {e.NewValue}");
            WriteLine("Current matrix state: ");
            WriteLine(sender);
        }

        public static void Main(string[] args)
        {
            Matrix<int> int_matrix = new Matrix<int>(4);
            int_matrix.ItemChanged += MatrixChangedHandler;
            WriteLine(int_matrix);

            int_matrix[2, 3] = 5; // Changed. Event raised.

            int_matrix[4, 4] = 10; // Won't execute because out of bounds

            int_matrix[0, 0] = 29; // Changed. Event raised.


            Matrix<string> string_matrix = new Matrix<string>(4);
            string_matrix.ItemChanged += MatrixChangedHandler;
            WriteLine(string_matrix);

            string_matrix[2, 3] = "Cat"; // Changed. Event raised.

            string_matrix[4, 4] = "Dog"; // Won't execute because out of bounds

            string_matrix[0, 0] = "Mouse"; // Changed. Event raised.
        }
    }
}