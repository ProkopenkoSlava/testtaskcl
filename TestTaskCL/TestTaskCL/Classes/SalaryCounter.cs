using System;
using System.Collections.Generic;
using System.Text;
using TestTaskCL.Interfaces;

namespace TestTaskCL.Classes
{
    public class SalaryCounter : ISalaryCounter
    {
        public double Count(DateTime dateTime, Person person, SalaryFactors.SalaryFactors salaryFactors, double baseRate)
        {
            double res = baseRate;
            double percentYearsDiff = StaticInfoRepository.FullYearsDiff(person.HireDate, dateTime) * salaryFactors.PercentRatioPerYear;
            res += res * (percentYearsDiff < salaryFactors.MaxPercentRatio ? percentYearsDiff : salaryFactors.MaxPercentRatio) / 100;
            return res;
        }
    }
}
