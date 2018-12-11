using System;
using System.Collections.Generic;
namespace Taks_1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var vacations = GenerateVacations(30, 2017, 2018);

            foreach (var item in vacations)
            {
                Console.WriteLine(item);
            }
        }

        public static List<Vacation> GenerateVacations(int count, int startYear, int endYear) {
            string[] names = new string[] {"John", "Peter", "Michael", "Anna", "Sara", "David", "Frank", "Alfred"};
            List<Vacation> vacations = new List<Vacation>(count);
            Random random = new Random();
            for (int i = 0; i < count; i ++) {
                DateTime startDate = new DateTime(startYear, random.Next(1, 13), random.Next(1, 30));
                DateTime endDate = new DateTime(endYear, random.Next(1, 13), random.Next(1, 30));
                vacations.Add(new Vacation(startDate, endDate, names[random.Next(1, names.Length)]));
            }
            return vacations;
        }
    }
}
