using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace STudentInternshipApplication.Student.StudentViews
{
    /// <summary>
    /// Interaction logic for RemoveStudent.xaml
    /// </summary>
    public partial class RemoveStudent : Window
    {
        StudentViewModel s = new StudentViewModel();
        public RemoveStudent()
        {
            InitializeComponent();
            DataContext = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
