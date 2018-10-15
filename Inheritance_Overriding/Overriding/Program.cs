using System;

namespace Overriding
{
    class Program
    {
        static void Main(string[] args)
        {
            Color redColor = new Color(255, 0, 0);
            Color redColor2 = new Color(255, 0, 0);
            Color greenColor = new Color(0, 255, 0);
            Color blueColor = new Color(0, 0, 255);
            Color whiteColor = new Color(255, 255, 255);
            Color blackColor = new Color(0, 0, 0);
            Color randomColor = new Color(29, 37, 100);

            Console.WriteLine(randomColor);
            Console.WriteLine(blueColor);
            Console.WriteLine(greenColor);
            Console.WriteLine(blackColor);
            Console.WriteLine(redColor);
            Console.WriteLine(whiteColor);

            Console.WriteLine($"Is redColor equals redColor1 BEFORE reassigning reference: {redColor.Equals(redColor2)}");

            redColor = redColor2;
            Console.WriteLine($"Is redColor equals redColor1 AFTER reassigning reference: {redColor.Equals(redColor2)}");
            Console.ReadLine();
        }
    }
}
