using System;
using System.Linq;
using System.Collections.Generic;
namespace Taks_1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var vacations = GenerateVacations(50, 2018);

            var averageVacationInfo = vacations
                .GroupBy(v => v.name)
                .Select(group => new { Name = group.Key, Average = (int)group.Average(v => (v.end - v.start).Days) });

            var overallAverageVacationLength = (int)averageVacationInfo.Average(info => info.Average);

            Console.WriteLine("----------------All-----------------");
            foreach (var item in vacations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("------------ Average Vacation Info ----------------");
            foreach (var item in averageVacationInfo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine($"Overall average vacation length = {overallAverageVacationLength}");
        }

        public static List<(DateTime start, DateTime end, string name)> GenerateVacations(int count, int year)
        {
            string[] names = new string[] { "John", "Peter", "Michael", "Anna", "Sara", "David", "Frank", "Alfred" };
            var vacations = new List<(DateTime, DateTime, string)>(count);
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                DateTime startDate = new DateTime(year, random.Next(5, 7), random.Next(1, 30));
                DateTime endDate = new DateTime(year, random.Next(7, 9), random.Next(1, 30));
                vacations.Add((startDate, endDate, names[random.Next(1, names.Length)]));
            }
            return vacations;
        }
    }
}
