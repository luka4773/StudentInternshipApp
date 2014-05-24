using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STudentInternshipApplication.Company
{
    class Company
    {
        private string _name;
        private string _email;
        private string _address;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
