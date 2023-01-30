using System;
using TestTaskCL.Classes.SalaryFactors;
using TestTaskCL.Enums;

namespace TestTaskCL.Classes.OrgNodes
{
    public class EmployeeOrgNode : OrgNode
    {
        public EmployeeOrgNode(Person person) 
           : base(person) { 
             _employeeType = EmployeeType.Employee;
             _salaryFactors = StaticInfoRepository.GetSalaryFactors(_employeeType);
             _salaryCounter = StaticInfoRepository.GetSalaryCounter(_employeeType);
        }

        protected override double GetSubordinatesSalaryCost(DateTime dateTime, OrgNode orgNode) { 
              return 0;
        }
    }
}
