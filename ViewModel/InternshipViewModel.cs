using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using STudentInternshipApplication.Annotations;
using STudentInternshipApplication.Internship.InternshipViews;
using STudentInternshipApplication.View;

namespace STudentInternshipApplication.Internship
{
    class InternshipViewModel : INotifyPropertyChanged
    {
        private Student.Student _currentStudent;
        private Company.Company _currentCompany;
        private Internship _currentInternship;
        private InternshipDataDisplay _currentInternshipDataDisplay;
        Controller.Controller controller = new Controller.Controller();
        private ObservableCollection<Internship> _getInternships = new ObservableCollection<Internship>();
        private ObservableCollection<Student.Student> _getStudents = new ObservableCollection<Student.Student>();
        private ObservableCollection<Company.Company> _getCompanies = new ObservableCollection<Company.Company>();
        private ObservableCollection<InternshipDataDisplay> _getData = new ObservableCollection<InternshipDataDisplay>(); 

        #region Icommands

        private readonly ICommand _openAddInternshipCommand;
        private readonly ICommand _addInternshipCommand;
        private readonly ICommand _closeAddInternshipCommand;
        private readonly ICommand _openRemoveInternshipCommand;
        private readonly ICommand _removeInternshipCommand;
        private readonly ICommand _closeRemoveInternshipCommand;
        private readonly ICommand _openEditInternshipCommand;
        private readonly ICommand _editInternshipCommand;
        private readonly ICommand _closeEditInternshipCommand;


        public ICommand EditInternship
        {
            get { return _editInternshipCommand; }
        }
        public ICommand CloseEditInternship
        {
            get { return _closeEditInternshipCommand; }
        }

        public ICommand OpenEditInternship
        {
            get { return _openEditInternshipCommand; }
        }

        public ICommand CloseRemoveInternship
        {
            get { return _closeRemoveInternshipCommand; }
        }
        public ICommand RemoveInternship
        {
            get { return _removeInternshipCommand; }
        }
        public ICommand CloseAddInternship
        {
            get { return _closeAddInternshipCommand; }
        }
        public ICommand OpenRemoveInternship
        {
            get { return _openRemoveInternshipCommand; }
        }
        public ICommand AddInternship
        {
            get { return _addInternshipCommand; }
        }

        public ICommand OpenAddInternship
        {
            get { return _openAddInternshipCommand; }
        }

        
        private void CloseEditInternshipCommand()
        {
            var i = new Internships();
            i.Show();
        }
        private void RemoveInternshipCommand()
        {
            var c = new Company.Company()
            {
                Name = _currentCompany.Name
            };
            controller.RemoveInternship(c);
        }

        private void OpenEditInternshipCommand()
        {
            var i = new EditInternship();
            i.Show();
        }
        private void CloseRemoveInternshipCommand()
        {
            var i = new Internships();
            i.Show();
        }
        private void CloseAddInternshipCommand()
        {
            var i = new Internships();
            i.Show();
        }
        private void OpenRemoveInternshipCommand()
        {
            var i = new RemoveInternship();
            i.Show();
        }
        private void EditInternshipCommand()
        {
            var s = new Student.Student()
            {
                Cpr = _currentStudent.Cpr
            };

            var c = new Company.Company()
            {
                Name = _currentCompany.Name
            };
            var i = new Internship()
            {
                Id = _currentInternship.Id,
                StartDate = InternshipStartDate,
                EndDate = InternshipEndDate

            };
            controller.EditInternship(i, s ,c);
        }
        private void AddInternshipCommand()
        {
            var s = new Student.Student()
            {
                Cpr = _currentStudent.Cpr
            };

            var c = new Company.Company()
            {
                Name = _currentCompany.Name
            };
            var i = new Internship()
            {
                Id = InternshipId,
                StartDate = InternshipStartDate,
                EndDate = InternshipEndDate
            };
            controller.AddInternship(i, s, c);
        }

        private void OpenAddInternshipCommand()
        {
            var i = new AddInternship();
            i.Show();
        }

        #endregion


        #region Current Student/internship/company/internshipdatadisplay

        public InternshipDataDisplay CurrentInternshipDataDisplay
        {
            get { return _currentInternshipDataDisplay; }
            set
            {
                if (value != _currentInternshipDataDisplay)
                {
                    _currentInternshipDataDisplay = value;
                    OnPropertyChanged("CurrentInternshipDataDisplay");
                }
            }
        }

        public Student.Student CurrentStudent
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

        public Company.Company CurrentCompany
        {
            get { return _currentCompany; }
            set
            {
                if (value != _currentCompany)
                {
                    _currentCompany = value;
                    OnPropertyChanged("CurrentCompany");
                }
            }
        }

        public Internship CurrentInternship
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

        #endregion

        #region Properties

        private DateTime _internshipstartdate;
        private DateTime _internshipenddate;
        private int _internshipid;

        public DateTime InternshipStartDate
        {
            get { return _internshipstartdate; }
            set
            {
                _internshipstartdate = value;
                OnPropertyChanged("InternshipStartDate");
            }
        }

        public DateTime InternshipEndDate
        {
            get { return _internshipenddate; }
            set
            {
                _internshipenddate = value;
                OnPropertyChanged("InternshipEndDate");
            }
        }

        public int InternshipId
        {
            get { return _internshipid; }
            set
            {
                _internshipid = value;
                OnPropertyChanged("InternshipId");
            }
        }

        #endregion

        
        

        #region Observable Collections

        public ObservableCollection<InternshipDataDisplay> InternshipData
        {
            get { return _getData; }
            set
            {
                _getData = value;
                OnPropertyChanged("InternshipData");
            }
        }
        public ObservableCollection<Internship> Internships
        {
            get { return _getInternships; }
            set
            {
                _getInternships = value;
                OnPropertyChanged("Internships");
            }
        }

        public ObservableCollection<Student.Student> Students
        {
            get { return _getStudents; }
            set
            {
                _getStudents = value;
                OnPropertyChanged("Students");
            }
        }

        public ObservableCollection<Company.Company> Companies
        {
            get { return _getCompanies; }
            set
            {
                _getCompanies = value;
                OnPropertyChanged("Companies");
            }
        }

        #endregion

        public InternshipViewModel()
        {
            Students = controller.GetStudents();
            _currentStudent = Students[0];

            Companies = controller.GetCompanies();
            _currentCompany = Companies[0];

            Internships = controller.GetInternships();
            _currentInternship = Internships[0];

            InternshipData = controller.GetInternshipDataDisplays();
            _currentInternshipDataDisplay = InternshipData[0];

            


            _openAddInternshipCommand = new RelayCommand(OpenAddInternshipCommand){IsEnabled = true};
            _addInternshipCommand = new RelayCommand(AddInternshipCommand){IsEnabled = true};
            _closeAddInternshipCommand = new RelayCommand(CloseAddInternshipCommand){IsEnabled = true};
            _openRemoveInternshipCommand = new RelayCommand(OpenRemoveInternshipCommand){IsEnabled = true};
            _removeInternshipCommand = new RelayCommand(RemoveInternshipCommand){IsEnabled = true};
            _closeRemoveInternshipCommand = new RelayCommand(CloseRemoveInternshipCommand){IsEnabled = true};
            _openEditInternshipCommand = new RelayCommand(OpenEditInternshipCommand){IsEnabled = true};
            _closeEditInternshipCommand = new RelayCommand(CloseEditInternshipCommand){IsEnabled = true};
            _editInternshipCommand = new RelayCommand(EditInternshipCommand){IsEnabled = true};

        }

        #region InotifyPropCh

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
