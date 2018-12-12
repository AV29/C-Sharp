using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace Taks_1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var months = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var vacations = GenerateVacations(10, 2018);

            var averageVacationInfo = vacations
                .GroupBy(vacation => vacation.name)
                .Select(group => new { 
                    Name = group.Key, 
                    AverageLength = (int)group.Average(v => (v.end - v.start).Days) 
                });

            var overallAverageVacationLength = (int)averageVacationInfo.Average(info => info.AverageLength);

            var perMonthVacationsInfo = months
                .Select(month => new { 
                    Month = month, 
                    EmployeesCount = vacations.Count(v => v.end.Month >= month && v.start.Month <= month) 
                });

            var noVacationInfo = vacations
                .GroupBy(vacation => vacation.name)
                .Select(group => new {
                    Name = group.Key,
                    FreeMonths = string.Join(" ", months
                                             .Where(month => group
                                                    .All(v => v.end.Month < month || v.start.Month > month)
                                                   )
                                            )
                });

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
            Console.WriteLine();
            Console.WriteLine("------------ Per Month Vacations Info ----------------");
            foreach (var item in perMonthVacationsInfo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("------------ No Vacations Info ----------------");
            foreach (var item in noVacationInfo)
            {
                Console.WriteLine(item);
            }
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
