using System;
using System.Linq;
using System.Collections.Generic;
namespace Taks_1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var months = Enumerable.Range(1, 12);
            
            var vacations = Helper.GenerateVacations(10, 2018);

            var averageVacationInfo = vacations
                .GroupBy(vacation => vacation.EmployeeName)
                .Select(group => new { 
                    Name = group.Key, 
                    AverageLength = (int)group.Average(v => v.Length) 
                });

            var overallAverageVacationLength = (int)averageVacationInfo.Average(info => info.AverageLength);

            var perMonthVacationsInfo = months
                .Select(month => new { 
                    Month = month, 
                    EmployeesCount = vacations.Count(v => v.EndDate.Month >= month && v.StartDate.Month <= month) 
                });

            var noVacationInfo = vacations
                .GroupBy(vacation => vacation.EmployeeName)
                .Select(group => new {
                    Name = group.Key,
                    FreeMonths = months.Where(month => group.All(v => v.EndDate.Month < month || v.StartDate.Month > month))
                });

            //var validVacationsInfo = vacations
                //.GroupBy(vacation => vacation.EmployeeName)
                //.Select(group => new {
                //    Name = group.Key,
                //    IsValidVacations = group
                //        .OrderBy(vac => vac.start.Month)
                //        .Aggregate(new List<int>(), (acc, item) => {
                //            acc.AddRange(new List<int>() { item.start.Month, item.end.Month });
                //            return acc;
                //        })
                //        .IsSorted()
                //});

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


            //Console.WriteLine("------------ Valid Vacations Info ----------------");
            //foreach (var item in validVacationsInfo)
            //{
            //    Console.WriteLine($"Name = {item.Name}, Vacations are valid = {string.Join(" ", item.IsValidVacations)}");
            //}
        }
    }
}
