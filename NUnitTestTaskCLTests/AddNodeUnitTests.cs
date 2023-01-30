using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestTaskCL;
using TestTaskCL.Classes.OrgNodes;

namespace NUnitTestTaskCLTests
{
    [TestFixture]
    public class AddNodeUnitTests
    {
        private static IEnumerable<TestCaseData> AddOrgNodesSuccessConfs() { 
            
            ManagerOrgNode mo = new ManagerOrgNode(new Person("Manager1", new System.DateTime(2020,1,1)));
            SalesOrgNode so = new SalesOrgNode(new Person("Sales1", new System.DateTime(2020,1,1)));
            EmployeeOrgNode eo = new EmployeeOrgNode(new Person("Employee1", new System.DateTime(2020,1,1)));
            yield return new TestCaseData(mo, eo);
            yield return new TestCaseData(so, eo);
            yield return new TestCaseData(mo, so);
            yield return new TestCaseData(so, mo);
            
            }
        private static IEnumerable<TestCaseData> AddOrgNodesNoActionConfs() { 
            
            ManagerOrgNode mo = new ManagerOrgNode(new Person("Manager1", new System.DateTime(2020,1,1)));
            SalesOrgNode so = new SalesOrgNode(new Person("Sales1", new System.DateTime(2020,1,1)));
            EmployeeOrgNode eo = new EmployeeOrgNode(new Person("Employee1", new System.DateTime(2020,1,1)));
            yield return new TestCaseData(eo, so);
            yield return new TestCaseData(eo, mo);
            yield return new TestCaseData(eo, null);
            yield return new TestCaseData(mo, null);
            yield return new TestCaseData(so, null);
            
        }

        private static IEnumerable<TestCaseData> AddOrgNodesExceptionConfs() { 
            
            ManagerOrgNode mo = new ManagerOrgNode(new Person("Manager1", new System.DateTime(2020,1,1)));
            SalesOrgNode so = new SalesOrgNode(new Person("Sales1", new System.DateTime(2020,1,1)));
            EmployeeOrgNode eo = new EmployeeOrgNode(new Person("Employee1", new System.DateTime(2020,1,1)));
            yield return new TestCaseData(eo, eo);
            yield return new TestCaseData(mo, mo);
            yield return new TestCaseData(so, so);
            
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("AddOrgNodesSuccessConfs")]
        public void AddOrgNodesSuccessTest(OrgNode orgNode, OrgNode orgNodeToAdd)
        {
            // Arrange
            // Act
            var res = orgNode.AddOrgNode(orgNodeToAdd);
            // Assert 
            Assert.IsTrue(res);
        }

        [Test, TestCaseSource("AddOrgNodesNoActionConfs")]
        public void AddOrgNodesNoActionTest(OrgNode orgNode, OrgNode orgNodeToAdd)
        {
            // Arrange
            // Act
            var res = orgNode.AddOrgNode(orgNodeToAdd);
            // Assert 
            Assert.IsFalse(res);
        }

        [Test, TestCaseSource("AddOrgNodesExceptionConfs")]
        public void AddOrgNodesExceptionTest(OrgNode orgNode, OrgNode orgNodeToAdd)
        {
            Assert.Throws(Is.TypeOf<Exception>(), () => orgNode.AddOrgNode(orgNodeToAdd));
        }
    }
}