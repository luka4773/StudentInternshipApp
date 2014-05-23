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

namespace STudentInternshipApplication.MainWindow
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ICommand _openStudents;

        public ICommand openStudents
        { 
            get { return _openStudents; }
        }
        private void openStudentsCommand()
        {
            var s = new Students();
            s.Show();
        }
        public MainWindowViewModel()
        {
           _openStudents = new RelayCommand(openStudentsCommand) {IsEnabled = true};
        }






        #region InotifyPropertyChanged

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
