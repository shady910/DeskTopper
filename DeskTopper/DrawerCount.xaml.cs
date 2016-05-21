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
    /// Interaction logic for DrawerCount.xaml
    /// </summary>
    public partial class DrawerCount : Page
    {
        public DrawerCount()
        {
            InitializeComponent();
        }

        private void DCbtn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("chooseMaterial.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
