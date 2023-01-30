using System;
using System.Collections.Generic;
using System.Text;
using TestTaskCL.Classes.SalaryFactors;

namespace TestTaskCL.Interfaces
{
    public interface ISalaryCounter
    {
        double Count(DateTime dateTime, Person person, SalaryFactors salaryFactors, double baseRate);
    }
}
