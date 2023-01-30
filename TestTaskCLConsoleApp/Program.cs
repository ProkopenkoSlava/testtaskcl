using System;
using TestTaskCL;
using TestTaskCL.Classes.OrgNodes;

namespace TestTaskCLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double _baseRate = 500;
            StaticInfoRepository.BaseRate  =_baseRate;
        DateTime _dateBegin = new DateTime(2020, 1, 1);
        DateTime _dateBegin_SameYear = new DateTime(2020, 4, 1);
        DateTime _dateBegin_YearPlusOne = new DateTime(2021, 1, 1);
        DateTime _dateBegin_YearPlusTwo = new DateTime(2022, 7, 1);
        DateTime _dateBegin_YearPlusThree = new DateTime(2023, 1, 1);
        DateTime _dateBegin_YearPlusFive = new DateTime(2025, 5, 1);
        DateTime _dateBegin_YearPlusEleven = new DateTime(2031, 9, 1);
        DateTime _dateBegin_YearPlusThirtySeven = new DateTime(2057, 9, 1);
           SalesOrgNode so = new SalesOrgNode(new Person("Sales1", _dateBegin));
            ManagerOrgNode mo = new ManagerOrgNode(new Person("Manager1", _dateBegin_YearPlusOne));
            EmployeeOrgNode eo1 = new EmployeeOrgNode(new Person("Employee1", _dateBegin_YearPlusOne));
            EmployeeOrgNode eo2 = new EmployeeOrgNode(new Person("Employee2", _dateBegin));
            EmployeeOrgNode eo3 = new EmployeeOrgNode(new Person("Employee3", _dateBegin));
            mo.AddOrgNode(eo1);
            mo.AddOrgNode(eo2);
            mo.AddOrgNode(eo3);
            so.AddOrgNode(mo);
            var res = so.GetSalaryCost(_dateBegin_YearPlusFive);
        Console.WriteLine("{0}", res);
        }
}
}
