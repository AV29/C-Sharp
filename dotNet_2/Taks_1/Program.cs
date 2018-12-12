using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;
namespace Taks_1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var months = Enumerable.Range(1, 12);
            
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
                    FreeMonths = months.Where(month => group.All(v => v.end.Month < month || v.start.Month > month))
                });

            var validVacationsInfo = vacations
                .GroupBy(vacation => vacation.name)
                .Select(group => {
                    var orderedVacations = group.OrderBy(vac => vac.start.Month).ToArray();
                    var notIntercectable = orderedVacations.TakeWhile((vac, i) => {
                        return i <= orderedVacations.Length - 1 && vac.end.Month > orderedVacations[i + 1].start.Month;
                    });
                    Console.WriteLine(notIntercectable.Count());
                    return new { Name = group.Key, ValidVacations = notIntercectable.Count() == orderedVacations.Count()};
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
                   Console.WriteLine($"Name = {item.Name}, FreeMonths = [{string.Join(" ", item.FreeMonths)}]");
            }
            Console.WriteLine();


            Console.WriteLine("------------ Valid Vacations Info ----------------");
            foreach (var item in validVacationsInfo)
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
                DateTime startDate = new DateTime(year, random.Next(5, 9), 15);
                DateTime endDate = new DateTime(year, random.Next(7, 10), 15);
                vacations.Add((startDate, endDate, names[random.Next(1, names.Length)]));
            }
            return vacations;
        }
    }
}
