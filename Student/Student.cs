using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STudentInternshipApplication.Student
{
    class Student
    {
        private string _name;
        private string _address;
        private int _age;
        private int _cpr;
        private int _mobilephone;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get{ return _address;}
            set { _address = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Cpr
        {
            get { return _cpr; }
            set { _cpr = value; }
        }

        public int MobilePhone
        {
            get { return _mobilephone; }
            set { _mobilephone = value; }
        }
    }
}
