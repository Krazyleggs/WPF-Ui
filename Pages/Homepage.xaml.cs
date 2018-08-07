using System.Windows.Controls;
using Uiprogramming.ViewModel;

namespace Uiprogramming
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
            this.DataContext = new HomepageViewModel();
        }
    }
}
