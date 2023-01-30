using System;
using System.Collections.Generic;
using TestTaskCL.Classes.SalaryFactors;
using TestTaskCL.Enums;

namespace TestTaskCL.Classes.OrgNodes
{
    public class ManagerOrgNode : OrgNode
    {
        public ManagerOrgNode(Person person)
               : base(person)
        {
            _subordinateOrgNodes = new List<OrgNode>();
            _employeeType = EmployeeType.Manager;
            _salaryFactors = StaticInfoRepository.GetSalaryFactors(_employeeType);
            _salaryCounter = StaticInfoRepository.GetSalaryCounter(_employeeType);
        }

        protected override double GetSubordinatesSalaryCost(DateTime dateTime, OrgNode orgNode)
        {
            double sum = 0;
            if (orgNode.SubordinateOrgNodes == default || orgNode.SubordinateOrgNodes.Count == 0)
            { 
                return sum;
            }
            foreach (var node in orgNode.SubordinateOrgNodes)
            {
                sum += node.GetSalaryCost(dateTime);
            }
            if (sum > 0)
            {
                sum = sum * (_salaryFactors.SubordinatesPercentRatio / 100);
            }
            return sum;
        }
    }
}
