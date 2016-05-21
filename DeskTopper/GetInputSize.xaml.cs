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
            //import desk object and make new deskOrderMethods object to provide access to methods.
            Desk desk = (Desk)Application.Current.Properties["Desk"];
            DeskOrderMethods dom = new DeskOrderMethods();
            
            //get user input from widthbox and lengthbox and validate
            int widthNumber = dom.validateIntInput(widthBox.Text);
            int lengthNumber = dom.validateIntInput(lengthBox.Text);
            bool validW = dom.checkValid(widthNumber);
            bool validL = dom.checkValid(lengthNumber);

            if ((validW != true)||(validL !=true))
            {
                MessageBox.Show("Sorry, we don't make desks to those dimensions. "
                    + "Please enter a number between 1 and 500.");
            }else
            {   
                //set desk width and length
                desk.deskWidth = widthNumber;
                desk.deskLength = lengthNumber;
                
                //continue to next page
                Uri uri = new Uri("DrawerCount.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
                
        
    }
}
