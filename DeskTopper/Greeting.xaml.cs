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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeskTopper
{
    /// <summary>
    /// Interaction logic for Greeting.xaml
    /// </summary>
    public partial class Greeting : Page
    {
        public Greeting()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
         
            // View Size Report
            GetInputSize getInputSizePage = new GetInputSize();
            this.NavigationService.Navigate(getInputSizePage);

        }
    }
}

