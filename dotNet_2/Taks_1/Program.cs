using System;
using System.Linq;
using System.Collections.Generic;
namespace Taks_1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            const int year = 2018;

            var allYearMonths = Enumerable.Range(1, 12);

            var allYearDates = Helper.GetAllYearDays(year);

            var vacations = Helper.GenerateVacations(10, year);

            Console.WriteLine("----------------All-----------------");
            foreach (var item in vacations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            #region Average vacation length

            var averageVacationInfo = vacations
                .GroupBy(vacation => vacation.EmployeeName)
                .Select(group => new { 
                    Name = group.Key, 
                    AverageLength = (int)group.Average(v => v.Length) 
                });


            Console.WriteLine("------------ Average Vacation Info ----------------");
            foreach (var item in averageVacationInfo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            #endregion


            #region Overall average vacation length

            var overallAverageVacationLength = (int)averageVacationInfo.Average(info => info.AverageLength);

            Console.WriteLine($"Overall average vacation length = {overallAverageVacationLength}");
            Console.WriteLine();

            #endregion


            #region Vocations Per Month

            var perMonthVacationsInfo = allYearMonths
                .Select(month => new { 
                    Month = month, 
                    EmployeesCount = vacations.Count(v => v.EndDate.Month >= month && v.StartDate.Month <= month) 
                });

            Console.WriteLine("------------ Per Month Vacations Info ----------------");
            foreach (var item in perMonthVacationsInfo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            #endregion


            #region Dates without vacations for all employess

            var noVacationDatesInfo = allYearDates.Where(date => !vacations.SelectMany(vac => vac).Contains(date));

            Console.WriteLine("------------ No Vacations Info ----------------");
            foreach (var item in noVacationDatesInfo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            #endregion


            #region Vacations Validation

            var validVacationsInfo = vacations
                .GroupBy(vacation => vacation.EmployeeName)
                .Select(group => new
                {
                    Name = group.Key,
                    ValidVacations = group.Count() == 1 || !group.SelectMany(v => v).ToList().HasDuplicates()
                });


            
            Console.WriteLine("------------ Vacations Validation Info ----------------");
            foreach (var item in validVacationsInfo)
            {
                Console.WriteLine($"Name = {item.Name}, Vacations are valid = {item.ValidVacations}");
            }

            Console.ReadLine();

            #endregion
        }
    }
}
