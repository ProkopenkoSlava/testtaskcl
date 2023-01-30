using System;
using System.Collections.Generic;
using TestTaskCL.Enums;

namespace TestTaskCL
{
    public class Person
    {
        private string _name;

        private DateTime _hireDate;

        public Person(string name, DateTime hireDate)
        {
            _name = name;
            _hireDate = hireDate;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public DateTime HireDate
        {
            get
            {
                return _hireDate;
            }
        }

    }
}
