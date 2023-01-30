using System;
using System.Collections.Generic;
using TestTaskCL.Classes.SalaryFactors;
using TestTaskCL.Enums;

namespace TestTaskCL.Classes.OrgNodes
{
    public class SalesOrgNode : OrgNode
    {
        public SalesOrgNode(Person person)
            : base(person)
        {
            _subordinateOrgNodes = new List<OrgNode>();
            _employeeType = EmployeeType.Sales;
            _salaryFactors = StaticInfoRepository.GetSalaryFactors(_employeeType);
            _salaryCounter = StaticInfoRepository.GetSalaryCounter(_employeeType);
        }

        protected override double GetSubordinatesSalaryCost(DateTime dateTime, OrgNode orgNode)
        {
            double sum = 0;
            List<OrgNode> listOrgNodes = new List<OrgNode>();

            GetAllDepthSubordinateNodes(listOrgNodes, this);

            if (listOrgNodes == default || listOrgNodes.Count == 0)
            {
                return sum;
            }

            foreach (var node in listOrgNodes)
            {
                sum += node.GetSalaryCost(dateTime);
            }

            if (sum > 0)
            {
                sum = sum * (_salaryFactors.SubordinatesPercentRatio / 100);
            }

            return sum;

        }

        private void GetAllDepthSubordinateNodes(List<OrgNode> listOrgNodes, OrgNode orgNode)
        {
            if (orgNode.SubordinateOrgNodes == default)
            {
                return;
            }

            foreach (var node in orgNode.SubordinateOrgNodes)
            {

                listOrgNodes.Add(node);

                GetAllDepthSubordinateNodes(listOrgNodes, node);
            }
        }
    }
}
