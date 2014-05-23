using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using STudentInternshipApplication.Annotations;
using STudentInternshipApplication.Student;

namespace STudentInternshipApplication
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICommand _openStudentsCommand;


        public ICommand openStudents
        {
            get { return _openStudentsCommand; }
        }


        private void openStudentsCommand()
        {
          var s = new Students();
          s.Show();
        }


        public MainViewModel()
        {
                _openStudentsCommand = new RelayCommand(openStudentsCommand){IsEnabled = true};
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
