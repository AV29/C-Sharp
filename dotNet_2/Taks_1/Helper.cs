using System;
using System.Collections.Generic;

namespace Taks_1
{
    public static class Helper
    {
        public static bool IsSorted(this List<int> source)
        {
            for (int i = 0; i < source.Count - 1; i++)
            {
                if (source[i + 1] < source[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasDuplicates<T>(this List<T> source)
        {
            var buffer = new HashSet<T>();
            for (int i = 0; i < source.Count - 1; i++)
            {
                if (buffer.Contains(source[i]))
                {
                    return true;
                }
                buffer.Add(source[i]);
            }
            return false;
        }

        public static List<Vacation> GenerateVacations(int count, int year)
        {
            string[] names = new string[] { "John", "Peter", "Michael", "Anna", "Sara", "David", "Frank", "Alfred" };
            var vacations = new List<Vacation>(count);
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                DateTime startDate = new DateTime(year, random.Next(1, 9), 15);
                DateTime endDate = new DateTime(year, random.Next(7, 13), 15);
                vacations.Add(new Vacation(startDate, endDate, names[random.Next(1, names.Length)]));
            }
            return vacations;
        }

        public static HashSet<DateTime> GetAllYearDays(int year) {
            var result = new HashSet<DateTime>();
            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year, 12, 31);
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                result.Add(date);
            }
            return result;
        }
    }
}
