using System;

namespace Array_Basics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter words list length: ");
            int wordsCount = int.Parse(Console.ReadLine());
            string tempString = "";
            int tempInt = 0;
            int vowelWordsCount = 0;
            int[] vowelsCountArray = new int[wordsCount];
            string[] words = new string[wordsCount];

            Console.WriteLine($"Enter {wordsCount} words: ");
            for (int i = 0; i < wordsCount; i++)
            {
                int vowelsCounter = 0;
                words[i] = Console.ReadLine();
                foreach (var letter in words[i])
                {
                    if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u' || letter == 'y') vowelsCounter++;
                }
                vowelsCountArray[i] = vowelsCounter;
                if (vowelsCounter > 0) vowelWordsCount++;
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Here're your initial words: ");
            for (int i = 0; i < words.Length; i++) Console.WriteLine(words[i]);

            for (int i = 0; i < vowelsCountArray.Length - 1; i++)
            {
                for (int j = i; j < vowelsCountArray.Length; j++)
                {
                    if (vowelsCountArray[i] < vowelsCountArray[j])
                    {
                        tempInt = vowelsCountArray[i];
                        vowelsCountArray[i] = vowelsCountArray[j];
                        vowelsCountArray[j] = tempInt;

                        tempString = words[i];
                        words[i] = words[j];
                        words[j] = tempString;
                    }
                }
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Here're your only vowel words sorted by vowel letters: ");
            for (int i = 0; i < vowelWordsCount; i++) Console.WriteLine(words[i]);
        }
    }
}
