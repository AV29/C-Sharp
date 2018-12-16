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

        public static List<Vacation> GenerateVacations(int count, int year)
        {
            string[] names = new string[] { "John", "Peter", "Michael", "Anna", "Sara", "David", "Frank", "Alfred" };
            var vacations = new List<Vacation>(count);
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                DateTime startDate = new DateTime(year, random.Next(5, 9), 15);
                DateTime endDate = new DateTime(year, random.Next(7, 10), 15);
                vacations.Add(new Vacation(startDate, endDate, names[random.Next(1, names.Length)]));
            }
            return vacations;
        }
    }
}
