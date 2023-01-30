using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestTaskCL;
using TestTaskCL.Classes.OrgNodes;

namespace NUnitTestTaskCLTests
{
    [TestFixture]
    public class SalaryCostNodeUnitTests
    {

        private static readonly double _baseRate = 500;
        private static readonly DateTime _dateBegin = new DateTime(2020,1,1);
        private static readonly DateTime _dateBegin_SameYear = new DateTime(2020,4,1);
        private static readonly DateTime _dateBegin_YearPlusOne = new DateTime(2021,1,1);
        private static readonly DateTime _dateBegin_YearPlusTwo = new DateTime(2022,7,1);
        private static readonly DateTime _dateBegin_YearPlusThree = new DateTime(2023,1,1);
        private static readonly DateTime _dateBegin_YearPlusFive = new DateTime(2025,5,1);
        private static readonly DateTime _dateBegin_YearPlusEleven = new DateTime(2031,9,1);
        private static readonly DateTime _dateBegin_YearPlusThirtySeven = new DateTime(2057,9,1);
        private static readonly int zero = 0;
        private static readonly int one = 1;
        private static readonly int two = 2;
        private static readonly int three = 3;
        private static readonly int five = 5;
        private static readonly int eleven = 11;
        private static readonly int thirty_seven = 37;

        private static IEnumerable<TestCaseData> DateCheckTestConfs()
        {

            yield return new TestCaseData(_dateBegin, _dateBegin, zero);
            yield return new TestCaseData(_dateBegin, _dateBegin_SameYear, zero);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusOne, one);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusTwo, two);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusThree, three);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusFive, five);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusEleven, eleven);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusThirtySeven, thirty_seven);

        }

        private static IEnumerable<TestCaseData> OneEmployeeTestConfs()
        {

            yield return new TestCaseData(_dateBegin, _dateBegin, 500);
            yield return new TestCaseData(_dateBegin, _dateBegin_SameYear, 500);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusOne, 515);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusTwo, 530);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusThree, 545);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusFive, 575);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusEleven, 650);

        }

        private static IEnumerable<TestCaseData> OneManagerTestConfs()
        {

            yield return new TestCaseData(_dateBegin, _dateBegin, 500);
            yield return new TestCaseData(_dateBegin, _dateBegin_SameYear, 500);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusOne, 525);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusTwo, 550);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusThree, 575);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusFive, 625);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusEleven, 700);

        }

        private static IEnumerable<TestCaseData> OneSalesTestConfs()
        {

            yield return new TestCaseData(_dateBegin, _dateBegin, 500);
            yield return new TestCaseData(_dateBegin, _dateBegin_SameYear, 500);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusOne, 505);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusTwo, 510);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusThree, 515);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusFive, 525);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusEleven, 555);
            yield return new TestCaseData(_dateBegin, _dateBegin_YearPlusThirtySeven, 675);

        }

        [SetUp]
        public void Setup()
        {
            StaticInfoRepository.BaseRate = _baseRate;
        }

        [Test, TestCaseSource("OneEmployeeTestConfs")]
        public void SalaryCostOneEmployee_Test(DateTime dateBegin, DateTime currentDate, double checkValue)
        {
            // Arrange
            EmployeeOrgNode eo = new EmployeeOrgNode(new Person("Employee1", dateBegin));
            // Act
            var res = eo.GetSalaryCost(currentDate);
            // Assert 
            Assert.AreEqual(res, checkValue);
        }

        [Test, TestCaseSource("OneManagerTestConfs")]
        public void SalaryCostOneManager_Test(DateTime dateBegin, DateTime currentDate, double checkValue)
        {
            // Arrange
            ManagerOrgNode mo = new ManagerOrgNode(new Person("Manager1", dateBegin));
            // Act
            var res = mo.GetSalaryCost(currentDate);
            // Assert 
            Assert.AreEqual(res, checkValue);
        }

        [Test, TestCaseSource("OneSalesTestConfs")]
        public void SalaryCostOneSales_Test(DateTime dateBegin, DateTime currentDate, double checkValue)
        {
            // Arrange
            SalesOrgNode so = new SalesOrgNode(new Person("Sales1", dateBegin));
            // Act
            var res = so.GetSalaryCost(currentDate);
            // Assert 
            Assert.AreEqual(res, checkValue);
        }

        [Test]
        public void SalaryCostManagerWithEmployees_Test()
        {
            // Arrange
            ManagerOrgNode mo = new ManagerOrgNode(new Person("Manager1", _dateBegin));
            EmployeeOrgNode eo1 = new EmployeeOrgNode(new Person("Employee1", _dateBegin_YearPlusOne));
            EmployeeOrgNode eo2 = new EmployeeOrgNode(new Person("Employee2", _dateBegin));
            EmployeeOrgNode eo3 = new EmployeeOrgNode(new Person("Employee3", _dateBegin));
            mo.AddOrgNode(eo1);
            mo.AddOrgNode(eo2);
            mo.AddOrgNode(eo3);
            // Act
            var res = mo.GetSalaryCost(_dateBegin_YearPlusTwo);
            // Assert 
            Assert.AreEqual(res, 557.875);
        }

        [Test]
        public void SalaryCostSalesWithEmployees_Test()
        {
            // Arrange
            SalesOrgNode so = new SalesOrgNode(new Person("Sales1", _dateBegin));
            EmployeeOrgNode eo1 = new EmployeeOrgNode(new Person("Employee1", _dateBegin_YearPlusOne));
            EmployeeOrgNode eo2 = new EmployeeOrgNode(new Person("Employee2", _dateBegin));
            EmployeeOrgNode eo3 = new EmployeeOrgNode(new Person("Employee3", _dateBegin));
            so.AddOrgNode(eo1);
            so.AddOrgNode(eo2);
            so.AddOrgNode(eo3);
            // Act
            var res = so.GetSalaryCost(_dateBegin_YearPlusThree);
            // Assert 
            Assert.AreEqual(res, 519.86);
        }

        [Test]
        public void SalaryCostSalesWithManagerWithEmployees_Test()
        {
            // Arrange
            SalesOrgNode so = new SalesOrgNode(new Person("Sales1", _dateBegin));
            ManagerOrgNode mo = new ManagerOrgNode(new Person("Manager1", _dateBegin_YearPlusOne));
            EmployeeOrgNode eo1 = new EmployeeOrgNode(new Person("Employee1", _dateBegin_YearPlusOne));
            EmployeeOrgNode eo2 = new EmployeeOrgNode(new Person("Employee2", _dateBegin));
            EmployeeOrgNode eo3 = new EmployeeOrgNode(new Person("Employee3", _dateBegin));
            mo.AddOrgNode(eo1);
            mo.AddOrgNode(eo2);
            mo.AddOrgNode(eo3);
            so.AddOrgNode(mo);
            // Act
            var res = so.GetSalaryCost(_dateBegin_YearPlusFive);
            // Assert 
            Assert.AreEqual(res, 531.95565);
        }

        // -------------------------------------------------------------------------------------

        // init values tests
        [Test]
        public void BaseRate_Test() { 
            Assert.AreEqual(StaticInfoRepository.BaseRate, 500);
        }

        [Test, TestCaseSource("DateCheckTestConfs")]
        public void YearDates_Test(DateTime dateBegin, DateTime nextDate, int checkValue) { 
            Assert.AreEqual(StaticInfoRepository.FullYearsDiff(dateBegin, nextDate), checkValue);
        }

    }
    }