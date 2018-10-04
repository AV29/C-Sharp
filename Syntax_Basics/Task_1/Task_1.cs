using System;

namespace Task_1
{
    class EffectiveTemperatureCalculator
    {
        private static double GetCelcius(double fahrenheits) 
        {
            return (fahrenheits - 32) / 1.8;
        }

        private static double GetFahrenheits(double celcius)
        {
            return celcius * 1.8 + 32;
        }

        static double GetMPH(double kmhSpeed)
        {
            return kmhSpeed * 0.621371;
        }

        private static double CalculateEffectiveTemperature(double temp, double windSpeed)
        {
            double mphSpeed = GetMPH(windSpeed);
            double fahrenheitTemp = GetFahrenheits(temp);
            double fahrenheitResult = 35.74 + (fahrenheitTemp * 0.6215) + ((fahrenheitTemp * 0.4275) - 35.75) * Math.Pow(mphSpeed, 0.16);
            return GetCelcius(fahrenheitResult);
        }

        public static void Main(string[] args) 
        {
            Console.WriteLine("Enter temperature in celcius: ");
            double temp = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter wind speed in kmh: ");
            double windSpeed = double.Parse(Console.ReadLine());

            Console.Write("Effective temperature is: ");
            Console.WriteLine(CalculateEffectiveTemperature(temp, windSpeed));

            if (windSpeed < 3 || windSpeed > 120)
            {
                Console.WriteLine("Note that for correct calculation wind speed should be in range (3, 120)");
            }

            if (Math.Abs(temp) > 50)
            {
                Console.WriteLine("Note that for correct calculation temperature should be in range [-50, 50]");
            }
        }
    }
}
