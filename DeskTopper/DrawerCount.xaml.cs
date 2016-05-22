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
        private List<String> _thingList;
        public DrawerCount()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   
            string[] thing = new string[8];
            for (int i=0; i<8; i++)
            {
                thing[i] = ""+i;
            }
            _thingList = thing.ToList();
            drawerListBox.ItemsSource = _thingList;
        }

        private void DCbtn_Click(object sender, RoutedEventArgs e)
        {
            Desk desk = (Desk)Application.Current.Properties["Desk"];
            DeskOrderMethods dom = new DeskOrderMethods();

            if (drawerListBox.SelectedIndex == -1)
                MessageBox.Show("Please make a selection from the list.");
            else
            {
                int drawers = int.Parse(drawerListBox.SelectedItem.ToString());
                desk.noOfDrawers = drawers;

                Uri uri = new Uri("chooseMaterial.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
               
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
