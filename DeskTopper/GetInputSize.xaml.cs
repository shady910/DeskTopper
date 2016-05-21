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
    /// Interaction logic for GetInputSize.xaml
    /// </summary>
    public partial class GetInputSize : Page
    {
        

        public GetInputSize()
        {
            InitializeComponent();
        }
        //on click, take input for width/length and check validity before moving on to next page
        private void GISPbtn_Click(object sender, RoutedEventArgs e)
        {
            Desk d = (Desk)Application.Current.Properties["Desk"];
            bool deskWidth = Desk.setDeskWidth(widthBox.Text, d);
            bool deskLength = Desk.setDeskLength(lengthBox.Text, d);

            if ((deskWidth != true)||(deskLength !=true))
            {
                MessageBox.Show("Sorry, we don't make desks to those dimensions. "
                    + "Please enter a number between 1 and 500.");
            }else
            {
                Uri uri = new Uri("DrawerCount.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
                
        
    }
}
