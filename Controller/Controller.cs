using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STudentInternshipApplication.Data_access_layer___Data;

namespace STudentInternshipApplication.Controller
{
    class Controller
    {   
        Company.Company c = new Company.Company();
        Student.Student s = new Student.Student();
        DAL _access = new DAL();

        public ObservableCollection<Student.Student> GetStudents()
        {
            return _access.GetStudents();
        }

        public void AddStudent(Student.Student student)
        {
            _access.AddStudent(s);
        }

        public void AddCompany(Company.Company company)
        {
            _access.AddCompany(c);
        }

        public ObservableCollection<Company.Company> GetCompanies()
        {
            return _access.Getcompanies();
        }


    }
}
