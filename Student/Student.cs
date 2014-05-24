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
        private string _supervisor;
        private int _age;
        private int _cpr;
       


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Supervisor
        {
            get{ return _supervisor;}
            set { _supervisor = value; }
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

       
    }
}
