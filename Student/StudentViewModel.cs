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

namespace STudentInternshipApplication.Student
{
    class StudentViewModel : INotifyPropertyChanged
    {
        private string _studentname;
        private string _studentsupervisor;
        private int _studentage;
        private int _studentcpr;
       
        private readonly ICommand _removeStudentCommand;
        private readonly ICommand _editStudentCommand;
        private readonly ICommand _addStudentCommand;
        
        private ObservableCollection<Student> _getStudents = new ObservableCollection<Student>();
        Controller.Controller controller = new Controller.Controller();
        private Student _currentStudent;

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

        private void RemoveStudentCommand()
        {
            
        }

        private void EditStudentCommand()
        {
            
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
            MessageBox.Show("THIS BUTTON SHOULD FUCKING WORK");

        }

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

        public int StudentCpr
        {
            get { return _studentcpr; }
            set
            {
                _studentcpr = value; 
                OnPropertyChanged("StudentCpr");
            }
        }

      

        #endregion


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
            MessageBox.Show("" + Students.Count);           

            _removeStudentCommand = new RelayCommand(RemoveStudentCommand) { IsEnabled = true };
            _editStudentCommand = new RelayCommand(EditStudentCommand) { IsEnabled = true };
            _addStudentCommand = new RelayCommand(AddStudentCommand) { IsEnabled = true };
            _currentStudent = Students[0];

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
