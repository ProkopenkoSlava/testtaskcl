using System;
using System.Collections.Generic;
using TestTaskCL.Classes;
using TestTaskCL.Classes.SalaryFactors;
using TestTaskCL.Enums;

namespace TestTaskCL
{
    public static class StaticInfoRepository
    {
        public static double BaseRate { get; set; } = 500;

        private readonly static Dictionary<EmployeeType, SalaryFactors> _salaryFactors
            = new Dictionary<EmployeeType, SalaryFactors>() {
                {
                  EmployeeType.None, new SalaryFactors()
                  {
                    PercentRatioPerYear = 0,
                    MaxPercentRatio = 0,
                    SubordinatesPercentRatio = 0
                  }
                 },
                 {
                  EmployeeType.Employee, new SalaryFactors()
                  {
                    PercentRatioPerYear = 3,
                    MaxPercentRatio = 30,
                    SubordinatesPercentRatio = 0
                  }
                 },
                 {
                  EmployeeType.Manager, new SalaryFactors()
                  {
                    PercentRatioPerYear = 5,
                    MaxPercentRatio = 40,
                    SubordinatesPercentRatio = 0.5
                  }
                 },
                 {
                 EmployeeType.Sales, new SalaryFactors()
                  {
                    PercentRatioPerYear = 1,
                    MaxPercentRatio = 35,
                    SubordinatesPercentRatio = 0.3
                  }
                 }
                };

        private readonly static SalaryCounter _salaryCounter = new SalaryCounter();


        public static SalaryFactors GetSalaryFactors(EmployeeType employeeType)
        {
            return _salaryFactors[employeeType];
        }

        public static SalaryCounter GetSalaryCounter(EmployeeType employeeType)
        {
            if (employeeType == EmployeeType.None)
            {
                return default;
            }
            return _salaryCounter;
        }

        public static int FullYearsDiff(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }


    }
}
