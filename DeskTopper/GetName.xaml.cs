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
    /// Interaction logic for GetName.xaml
    /// </summary>
    public partial class GetName : Page
    {
        public GetName()
        {
            InitializeComponent();
        }
        private void GNbtn_Click(object sender, RoutedEventArgs e)
        {
            Desk d = (Desk)Application.Current.Properties["Desk"];
            d.buyerName = buyerNameBox.Text.Trim();

            Uri uri = new Uri("DeskOrder.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
