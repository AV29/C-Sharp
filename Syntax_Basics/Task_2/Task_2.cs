using System;

namespace Task_2
{
    class FindSpecialNumbers
    {

        private static string ConvertToBinary(int dec) 
        {
            string result = "";
            do
            {
                result = result.Insert(0, (dec % 2).ToString());
                dec /= 2;
            } while (dec != 0);

            return result;
        }

        public static void Main(string[] args)
        {

            const int numberOfOnes = 4;

            Console.WriteLine("Enter integer ranges: ");
            int lowerBound = int.Parse(Console.ReadLine());
            int upperBound = int.Parse(Console.ReadLine());

            int currentNumber = lowerBound;

            Console.WriteLine("-----------------------------");
            while (currentNumber <= upperBound)
            {
                int counter = 0;
                int binaryIndex = 0;
                string currentBinary = ConvertToBinary(currentNumber);
                if (currentBinary.Length < numberOfOnes)
                {
                    currentNumber++;
                    continue;
                }

                while (binaryIndex < currentBinary.Length)
                {
                    if(currentBinary[binaryIndex] == '1') {
                        counter++;
                    }
                    if(counter > numberOfOnes) {
                        break;
                    }
                    binaryIndex++;
                }

                if(counter == numberOfOnes) {
                    Console.Write(currentNumber); 
                    Console.WriteLine(' ');
                }
                currentNumber++;
            }

        }
    }
}
