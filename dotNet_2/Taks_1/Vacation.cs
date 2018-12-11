using System;
namespace Taks_1
{
    public class Vacation
    {
        #region Properties

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string EmployeeName { get; set; }

        #endregion

        #region Constructor

        public Vacation(DateTime startDate, DateTime endDate, string employeeName)
        {
            EmployeeName = employeeName;
            StartDate = startDate;
            EndDate = endDate;
        }

        #endregion

        public override string ToString()
        {
            return $"{EmployeeName} - {StartDate} -> {EndDate}";
        }
    }
}
