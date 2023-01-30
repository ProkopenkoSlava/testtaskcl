using System;
using System.Collections.Generic;
using TestTaskCL.Classes;
using TestTaskCL.Classes.SalaryFactors;
using TestTaskCL.Enums;
using TestTaskCL.Interfaces;

namespace TestTaskCL
{
    public abstract class OrgNode
    {
        protected SalaryFactors _salaryFactors;
        protected List<OrgNode> _subordinateOrgNodes;
        private Person _person;
        protected ISalaryCounter _salaryCounter;
        protected EmployeeType _employeeType;


        public OrgNode(Person person)
        {
            _person = person;
            _employeeType = EmployeeType.None;
        }

        public List<OrgNode> SubordinateOrgNodes
        {
            get
            {
                return _subordinateOrgNodes;
            }
        }

        public Person Person
        {
            get;
        }

        // add new org node as subordinate to current
        public bool AddOrgNode(OrgNode orgNode)
        {
            if (!CheckOrgNode(orgNode))
            {
                throw new Exception("OrgNode is always in org structure");
            }

            if (orgNode == default || _subordinateOrgNodes == default)
            {
                return false;
            }

            _subordinateOrgNodes.Add(orgNode);

            return true;

        }

        // org node checking if always exists in org sturcture
        public bool CheckOrgNode(OrgNode orgNode)
        {
            if (this == orgNode)
            {
                return false;
            }

            if (_subordinateOrgNodes != default && _subordinateOrgNodes.Count > 0)
            {
                foreach (var node in _subordinateOrgNodes)
                {
                    if (!node.CheckOrgNode(orgNode))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        // get current node salary cost without subordinates
        protected double GetOwnSalaryCost(DateTime dateTime)
        {
            double res = _salaryCounter?.Count(dateTime, _person, _salaryFactors, StaticInfoRepository.BaseRate) ?? 0;
            return res;
        }

        public double GetSalaryCost(DateTime dateTime)
        {

            return GetOwnSalaryCost(dateTime) + GetSubordinatesSalaryCost(dateTime, this);
        }

        // abstract method to get subordinates cost. must be implemented in derived classes
        protected abstract double GetSubordinatesSalaryCost(DateTime dateTime, OrgNode orgNode);

    }
}
