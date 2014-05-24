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

namespace STudentInternshipApplication.Company.CompanyViews
{
    /// <summary>
    /// Interaction logic for Companies.xaml
    /// </summary>
    public partial class Companies : Window
    {
        CompanyViewModel companyViewModel = new CompanyViewModel();
        public Companies()
        {
            InitializeComponent();
            DataContext = companyViewModel;
        }
    }
}
