using System;
using TestTaskCL;
using TestTaskCL.Classes.OrgNodes;

namespace TestTaskCLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeOrgNode employeeOrgNode1 = new EmployeeOrgNode(new Person("Employee1", new DateTime(2020,1,1)));
            EmployeeOrgNode employeeOrgNode2 = new EmployeeOrgNode(new Person("Employee2", new DateTime(2020,1,1)));
            EmployeeOrgNode employeeOrgNode3 = new EmployeeOrgNode(new Person("Employee3", new DateTime(2020,1,1)));
            ManagerOrgNode managerOrgNode1 = new ManagerOrgNode(new Person("Manager1", new DateTime(2020,1,1)));
            SalesOrgNode salesOrgNode1 = new SalesOrgNode(new Person("Sales1", new DateTime(2020,1,1)));
            //managerOrgNode1.AddOrgNode(employeeOrgNode1);
            //managerOrgNode1.AddOrgNode(employeeOrgNode2);
            //salesOrgNode1.AddOrgNode(employeeOrgNode3);
            //salesOrgNode1.AddOrgNode(managerOrgNode1);
            //salesOrgNode1.AddOrgNode(salesOrgNode1);
            double res = salesOrgNode1.GetSalaryCost(new DateTime(2020,2,1));
            Console.WriteLine("{0}", res);
        }
    }
}
