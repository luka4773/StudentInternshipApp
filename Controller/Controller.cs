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
        
        DAL _access = new DAL();

        public ObservableCollection<Student.Student> GetStudents()
        {
            return _access.GetStudents();
        }

        public void AddStudent(Student.Student student)
        {
            _access.AddStudent(student);
        }

        public void AddCompany(Company.Company company)
        {
            _access.AddCompany(company);
        }

        public ObservableCollection<Company.Company> GetCompanies()
        {
            return _access.Getcompanies();
        }

        public void RemoveStudent(Student.Student student)
        {
            _access.RemoveStudent(student);
        }

        public void RemoveCompany(Company.Company company)
        {
            _access.RemoveCompany(company);
        }

        public void EditStudent(Student.Student student)
        {
            _access.EditStudent(student);
        }
    }
}
