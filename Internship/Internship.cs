using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STudentInternshipApplication.Internship
{
    class Internship
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private int _id;

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
