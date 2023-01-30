using System;
using System.Collections.Generic;
using TestTaskCL;
using TestTaskCL.Classes.OrgNodes;

namespace TestTaskCLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double _baseRate = 500;
            StaticInfoRepository.BaseRate = _baseRate;
            DateTime _dateBegin = new DateTime(2020, 1, 1);
            DateTime _dateBegin_SameYear = new DateTime(2020, 4, 1);
            DateTime _dateBegin_YearPlusOne = new DateTime(2021, 1, 1);
            DateTime _dateBegin_YearPlusTwo = new DateTime(2022, 7, 1);
            DateTime _dateBegin_YearPlusThree = new DateTime(2023, 1, 1);
            DateTime _dateBegin_YearPlusFive = new DateTime(2025, 5, 1);
            DateTime _dateBegin_YearPlusEleven = new DateTime(2031, 9, 1);
            DateTime _dateBegin_YearPlusThirtySeven = new DateTime(2057, 9, 1);

            // organization get salary sample
            SalesOrgNode so1 = new SalesOrgNode(new Person("Sales1", _dateBegin));
            ManagerOrgNode mo1 = new ManagerOrgNode(new Person("Manager1", _dateBegin_YearPlusOne));
            ManagerOrgNode mo2 = new ManagerOrgNode(new Person("Manager2", _dateBegin));
            EmployeeOrgNode eo1 = new EmployeeOrgNode(new Person("Employee1", _dateBegin_YearPlusOne));
            EmployeeOrgNode eo2 = new EmployeeOrgNode(new Person("Employee2", _dateBegin));
            EmployeeOrgNode eo3 = new EmployeeOrgNode(new Person("Employee3", _dateBegin));
            EmployeeOrgNode eo4 = new EmployeeOrgNode(new Person("Employee4", _dateBegin_YearPlusTwo));
            EmployeeOrgNode eo5 = new EmployeeOrgNode(new Person("Employee5", _dateBegin_YearPlusTwo));
            mo1.AddOrgNode(eo1);
            mo1.AddOrgNode(eo2);
            mo1.AddOrgNode(eo3);
            so1.AddOrgNode(mo1);
            mo2.AddOrgNode(eo4);
            mo2.AddOrgNode(eo5);

            // simplified a bit for example. but we can get all org nodes from roots (so1, mo2)
            // if it's necessary, similar to SalesOrgNode.GetAllDepthSubordinateNodes
            List<OrgNode> organization = new List<OrgNode>() { so1, mo1, mo2, eo1, eo2, eo3, eo4, eo5 };

            double res = 0;
            foreach (var node in organization)
            {
                res += node.GetSalaryCost(_dateBegin_YearPlusFive);
            }

            Console.WriteLine("{0}", res);
        }
    }
}
