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
    /// Interaction logic for DeskOrder.xaml
    /// </summary>
    public partial class DeskOrder : Page
    {
        public DeskOrder()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Desk d = (Desk)Application.Current.Properties["Desk"];
            OrderNameBox.Content = "Order for: " + d.buyerName;
            deskWidthBox.Content = "Desk width: " + d.deskWidth.ToString() + " inches";
            deskLengthBox.Content = "Desk Length: " + d.deskLength.ToString() + " inches";
            drawerBox.Content = "Number of Drawers: " + d.noOfDrawers.ToString();
            materialTypeBox.Content = "Material Type: " + d.deskTopType.ToString();
            rushOrderBox.Content = "Rush Order: " + d.rushOrder.ToString();
            priceEstimateBox.Content = "Estimated Cost: $" + d.priceEstimate.ToString();
        }
    }
}
