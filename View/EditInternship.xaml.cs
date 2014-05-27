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
using STudentInternshipApplication.Internship;

namespace STudentInternshipApplication.View
{
    /// <summary>
    /// Interaction logic for EditInternship.xaml
    /// </summary>
    public partial class EditInternship : Window
    {
        InternshipViewModel i = new InternshipViewModel();
        public EditInternship()
        {
            InitializeComponent();
            DataContext = i;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
