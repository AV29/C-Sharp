using System;

namespace Class_Basics
{
    public static class Const
    {
        public const int DIMENSIONS = 3;
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            int[] inputCoords = new int[Const.DIMENSIONS];
            double inputMass = 0.0;

            //Get the first point
            Console.WriteLine($"Enter {Const.DIMENSIONS} Coordinates for Point_1");
            for (int i = 0; i < Const.DIMENSIONS; i++)
            {
                inputCoords[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter Mass for Point_1: ");
            inputMass = double.Parse(Console.ReadLine());

            Point point1 = new Point(inputMass, inputCoords);

            //Get the second point
            Console.WriteLine($"Enter {Const.DIMENSIONS} Coordinates for Point_2");
            for (int i = 0; i < Const.DIMENSIONS; i++)
            {
                inputCoords[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter Mass for Point_2: ");
            inputMass = double.Parse(Console.ReadLine());

            Point point2 = new Point(inputMass, inputCoords);

            Console.WriteLine($"Point 1: {point1}");
            Console.WriteLine($"Point 2: {point2}");

            Console.WriteLine($"Is Point_1 a zero-point: {point1.IsZero()}");
            Console.WriteLine($"Distance between Point_1 and Point_2 is: {point1.GetDistanceTo(point2)}");

            Console.WriteLine("Change X coordinate for Point_1 to see the differences: ");
            point1.X = int.Parse(Console.ReadLine());

            Console.WriteLine($"Point 1: {point1}");

            Console.WriteLine($"Are all coordinates from Point_1 equal to zero: {point1.IsZero()}");
            Console.WriteLine($"Distance between Point_1 and Point_2 is: {point1.GetDistanceTo(point2)}");
        }
    }

    public class Point
    {
        private double mass = 0.0;
        private int[] coordinates = new int[Const.DIMENSIONS];

        public override string ToString()
        {
            return $"Coordinates: X = {X}, Y = {Y}, Z = {Z}; Mass = {Mass};";
        }

        public Point(double _mass, params int[] values)
        {
            Mass = _mass;
            for (int i = 0; i < Const.DIMENSIONS; i++)
            {
                coordinates[i] = values[i];
            }
        }

        public int X
        {
            get => coordinates[0];
            set { coordinates[0] = value; }
        }

        public int Y
        {
            get => coordinates[1];
            set { coordinates[1] = value; }
        }

        public int Z
        {
            get => coordinates[2];
            set { coordinates[2] = value; }
        }

        public double Mass
        {
            get => mass;
            set => mass = value < 0 ? 0.0 : value;
        }

        public double GetDistanceTo(Point destinationPoint)
        {
            double sqrSum = 0;
            for (int i = 0; i < Const.DIMENSIONS; i++)
            { 
                sqrSum += Math.Pow((coordinates[i] - destinationPoint.coordinates[i]), 2); 
            }
            return Math.Sqrt(sqrSum);
        }

        public bool IsZero()
        {
            return (int)(X*X + Y*Y + Z*Z) == 0;
        }
    }
}
