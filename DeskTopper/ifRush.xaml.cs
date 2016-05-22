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
    /// Interaction logic for ifRush.xaml
    /// </summary>
    public partial class ifRush : Page
    {
        private List<String> _thingList;
        public ifRush()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] thing = new string[4];
            thing[0] = "3 days";
            thing[1] = "5 days";
            thing[2] = "7 days";
            thing[3] = "14 days";

            _thingList = thing.ToList();
            rushListBox.ItemsSource = _thingList;
        }

        private void IRbtn_Click(object sender, RoutedEventArgs e)
        {
            Desk desk = (Desk)Application.Current.Properties["Desk"];
            DeskOrderMethods dom = new DeskOrderMethods();

            if (rushListBox.SelectedIndex == -1)
                MessageBox.Show("Please make a selection from the list.");
            else
            {
                
                string rushNumber = rushListBox.SelectedItem.ToString();
                desk.rushOrder = rushNumber;

                Uri uri = new Uri("GetName.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
