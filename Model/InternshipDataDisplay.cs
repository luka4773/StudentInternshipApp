using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STudentInternshipApplication
{
    class InternshipDataDisplay
    {
        private string _name;
        private string _cpr;
        private DateTime _startdate;
        private DateTime _enddate;



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Cpr
        {
            get { return _cpr; }
            set { _cpr = value; }
        }

        public DateTime StartDate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }
    }
}
