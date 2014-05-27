using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using STudentInternshipApplication.Annotations;
using STudentInternshipApplication.Data_access_layer___Data;
using STudentInternshipApplication.Student.StudentViews;

namespace STudentInternshipApplication.Student
{
    class StudentViewModel : INotifyPropertyChanged
    {
        private string _studentname;
        private string _studentsupervisor;
        private int _studentage;
        private string _studentcpr;
       
        private readonly ICommand _removeStudentCommand;
        private readonly ICommand _editStudentCommand;
        private readonly ICommand _addStudentCommand;
        private readonly ICommand _openAddStudent;
        private readonly ICommand _closeAddStudent;
        private readonly ICommand _openRemoveStudent;
        private readonly ICommand _closeRemoveStudent;
        private readonly ICommand _openEditStudent;
        private readonly ICommand _closeEditStudent;
       
        
        private ObservableCollection<Student> _getStudents = new ObservableCollection<Student>();
        private ObservableCollection<Internship.Internship> _getInternships = new ObservableCollection<Internship.Internship>();
        Controller.Controller controller = new Controller.Controller();
        private Student _currentStudent;
        private Internship.Internship _currentInternship;

        public Internship.Internship CurrentInternship
        {
            get { return _currentInternship; }
            set
            {
                if (value != _currentInternship)
                {
                    _currentInternship = value;
                    OnPropertyChanged("CurrentInternship");
                }
            }
        }

        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                if (value != _currentStudent)
                {
                    _currentStudent = value;
                    OnPropertyChanged("CurrentStudent");
                }
            }
        }
        #region Icommands

        public ICommand CloseEditStudent
        {
           get {return _closeEditStudent;} 
        }

        public ICommand OpenEditStudent
        {
            get { return _openEditStudent; }
        }
        public ICommand CloseRemoveStudent
        {
            get { return _closeRemoveStudent; }
        }
        public ICommand OpenRemoveStudent
        {
            get { return _openRemoveStudent; }
        }
        

        public ICommand Done
        {
            get { return _closeAddStudent; }
        }

        public ICommand OpenAdd
        {
            get { return _openAddStudent; }
        }
        public ICommand AddStudent
        {
            get { return _addStudentCommand; }
        }

        public ICommand EditStudent
        {
            get { return _editStudentCommand; }
        }

        public ICommand RemoveStudent
        {
            get { return _removeStudentCommand; }
        }

        #endregion

        #region Commands

        private void CloseEditStudentCommand()
        {
            var s = new Students();
            s.Show();
        }

        private void OpenEditStudentCommand()
        {
            var s = new EditStudent();
            s.Show();
        }

        private void OpenAddStudentCommand()
        {

            var s = new CreateStudent();
            s.Show();
        }

        private void RemoveStudentCommand()
        {
            var s = new Student
            {
                Cpr = _currentStudent.Cpr
            };
            controller.RemoveStudent(s);
        }

        private void EditStudentCommand()
        {
            var s = new Student
            {
                Cpr = _currentStudent.Cpr,
                Name = StudentName,
                Age = StudentAge,
                Supervisor = StudentSupervisor
            };
            controller.EditStudent(s);
        }

        private void CloseAddStudentCommand()
        {
            var s = new Students();
            s.Show();
        }

        private void AddStudentCommand()
        {
            
            var s = new Student
            {
                Name = StudentName,
                Age = StudentAge,
                Supervisor = StudentSupervisor,
                Cpr = StudentCpr,

            };
            controller.AddStudent(s);


        }

        private void CloseRemoveStudents()
        {
            var s = new Students();
            s.Show();
        }

        private void OpenRemoveStudents()
        {
            var s = new RemoveStudent();
            s.Show();
        }

        #endregion


        #region Properties

        public string StudentName
        {
            get { return _studentname; }
            set
            {
                _studentname = value;
                OnPropertyChanged("StudentName");
            }
        }

        public string StudentSupervisor
        {
            get { return _studentsupervisor; }
            set
            {
                _studentsupervisor = value;
                OnPropertyChanged("StudentSupervisor");
            }
        }

        public int StudentAge
        {
            get { return _studentage; }
            set
            {
                _studentage = value;
                OnPropertyChanged("StudentAge");
            }
        }

        public string StudentCpr
        {
            get { return _studentcpr; }
            set
            {
                _studentcpr = value; 
                OnPropertyChanged("StudentCpr");
            }
        }

      

        #endregion

        public ObservableCollection<Internship.Internship> Internships
        {
            get { return _getInternships; }
            set
            {
                _getInternships = value;
                OnPropertyChanged("Internships");
            }
        }
        public ObservableCollection<Student> Students
        {
            get
            {

                return _getStudents;
            }
            set
            {
                _getStudents = value;
                OnPropertyChanged("Students");
            }
        }


        public StudentViewModel()
        {



            Students = controller.GetStudents();
            Internships = controller.GetInternships();
            MessageBox.Show("" + Students.Count);           

            _removeStudentCommand = new RelayCommand(RemoveStudentCommand) { IsEnabled = true };
            _editStudentCommand = new RelayCommand(EditStudentCommand) { IsEnabled = true };
            _addStudentCommand = new RelayCommand(AddStudentCommand) { IsEnabled = true };
            _openAddStudent = new RelayCommand(OpenAddStudentCommand){IsEnabled = true};
            _closeAddStudent = new RelayCommand(CloseAddStudentCommand){IsEnabled = true};
            _openRemoveStudent = new RelayCommand(OpenRemoveStudents){IsEnabled = true};
            _closeRemoveStudent = new RelayCommand(CloseRemoveStudents){IsEnabled = true};
            _openEditStudent = new RelayCommand(OpenEditStudentCommand){IsEnabled = true};
            _closeEditStudent = new RelayCommand(CloseEditStudentCommand){IsEnabled = true};
            _currentStudent = Students[0];
            _currentInternship = Internships[0];


        }
        













        #region Inotifypropertychanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
