using System;
using System.Collections;
using System.Collections.Generic;
namespace Taks_1
{
    public class Vacation: IEnumerable<DateTime>
    {
        #region Properties

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Length { get; }

        public string EmployeeName { get; set; }

        #endregion

        #region Constructor

        public Vacation(DateTime startDate, DateTime endDate, string employeeName)
        {
            EmployeeName = employeeName;
            StartDate = startDate;
            EndDate = endDate;
            Length = (endDate - startDate).Days;
        }

        #endregion

        private static string GetFormattedDate(DateTime date) {
            return $"{date.Day}.{date.Month}.{date.Year}";
        }

        public override string ToString()
        {
            return $"{EmployeeName} - {GetFormattedDate(StartDate)} -> {GetFormattedDate(EndDate)}";
        }

        public IEnumerator<DateTime> GetEnumerator() {
            for (int i = 0; i < Length; i++) {
                yield return StartDate.AddDays(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
