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
using STudentInternshipApplication.Company.CompanyViews;

namespace STudentInternshipApplication.Company
{
    class CompanyViewModel : INotifyPropertyChanged
    {
        Controller.Controller controller = new Controller.Controller();
        private ObservableCollection<Company> _getCompanies = new ObservableCollection<Company>();
        private Company _currentCompany;

        public Company CurrentCompany
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


        #region Commands

        private readonly ICommand _addCompanyCommand;
        private readonly ICommand _editCompanyCommand;
        private readonly ICommand _removeCompanyCommand;
        private readonly ICommand _openAddCompanyCommand;
        private readonly ICommand _closeAddCompanyCommand;
        private readonly ICommand _openRemoveCompanyCommand;
        private readonly ICommand _closeRemoveCompanyCommand;


        public ICommand OpenRemoveCompanyCommand
        {
            get { return _openRemoveCompanyCommand; }
        }

        public ICommand CloseRemoveCompanyCommand
        {
            get { return _closeRemoveCompanyCommand; }
        }

        public ICommand CloseAddCompany
        {
            get { return _closeAddCompanyCommand; }
        }
        public ICommand OpenAddCompany
        {
            get { return _openAddCompanyCommand; }
        }
        public ICommand AddCompany
        {
            get { return _addCompanyCommand; }
        }

        public ICommand RemoveCompany
        {
            get { return _removeCompanyCommand; }
        }

        public ICommand EditCompany
        {
            get { return _editCompanyCommand; }
        }

        private void OpenRemoveCompaniesCommand()
        {
            var c = new RemoveCompany();
            c.Show();
        }

        private void CloseRemoveCompaniesCommand()
        {
            var c = new Companies();
            c.Show();
        }
        private void CloseAddCompanyCommand()
        {
            
            var c = new Companies();
            c.Show();
        }
        private void OpenAddCompanyCommand()
        {
            var c = new AddCompany();
            c.Show();
        }
        private void AddCompanyCommand()
        {
            var c = new Company
            {
                Name = CompanyName,
                Email = CompanyEmail,
                Address = CompanyAddress
            };
            controller.AddCompany(c);

        }

        private void RemoveCompanyCommand()
        {
            var c = new Company
            {
                Name = CompanyName
            };
            controller.RemoveCompany(c);
        }

        private void EditCompanyCommand()
        {

        }

        #endregion

        #region Properties

        private string _companyName;
        private string _companyEmail;
        private string _companyAddress;


        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public string CompanyEmail
        {
            get { return _companyEmail; }
            set
            {
                _companyEmail = value;
                OnPropertyChanged("CompanyEmail");
            }
        }

        public string CompanyAddress
        {
            get { return _companyAddress; }
            set
            {
                _companyAddress = value;
                OnPropertyChanged("CompanyAddress");
            }
        }

        #endregion


        public ObservableCollection<Company> Companies
        {
            get { return _getCompanies; }
            set
            {
                _getCompanies = value;
                OnPropertyChanged("Companies");
            }
        }


        public CompanyViewModel()
        {
            Companies = controller.GetCompanies();
            MessageBox.Show("" + Companies.Count);

            _addCompanyCommand = new RelayCommand(AddCompanyCommand){IsEnabled = true};
            _editCompanyCommand = new RelayCommand(EditCompanyCommand){IsEnabled = true};
            _removeCompanyCommand = new RelayCommand(RemoveCompanyCommand){IsEnabled = true};
            _openAddCompanyCommand = new RelayCommand(OpenAddCompanyCommand){IsEnabled = true};
            _closeAddCompanyCommand = new RelayCommand(CloseAddCompanyCommand){IsEnabled = true};
            _openRemoveCompanyCommand = new RelayCommand(OpenRemoveCompaniesCommand){IsEnabled = true};
            _closeRemoveCompanyCommand = new RelayCommand(CloseRemoveCompaniesCommand){IsEnabled = true};
            _currentCompany = Companies[0];
        }


        #region propertychanged


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
