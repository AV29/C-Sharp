using System;

namespace Task_3
{
    class ISBN
    {
        public static void Main(string[] args)
        {
            const int isbnLength = 9;
            Console.WriteLine($"Enter {isbnLength}-digit number to generate ISBN");
            int checkSum = 0;
            string isbn = "";
            do
            {
                isbn = Console.ReadLine();
                if(isbn.Length != isbnLength) Console.WriteLine($"It should be {isbnLength} digit number");
            } while (isbn.Length != isbnLength);
            for (int i = isbn.Length - 1, j = 1; i >= 0; i--, j++) {
                int n;
                if(!int.TryParse(isbn[i].ToString(), out n)) {
                    Console.Write("You've entered invalid number");
                    return;
                }
                checkSum += (n * j);
            }
            Console.WriteLine();
            isbn += checkSum % 11 == 10 ? "X" : (checkSum % 11).ToString();

            Console.Write("Result ISBN is: ");
            Console.WriteLine(isbn);
        }
    }
}
