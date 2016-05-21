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
    /// Interaction logic for chooseMaterial.xaml
    /// </summary>
    public partial class chooseMaterial : Page
    {
        private List<string> _surfaceMaterial;
        public chooseMaterial()
        {
            InitializeComponent();
        }
        
        //get material list and display
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] thing = Enum.GetNames(typeof (SurfaceMaterial));
            _surfaceMaterial = thing.ToList();
            materialListBox.ItemsSource = _surfaceMaterial;
        }

        private void MCbtn_Click(object sender, RoutedEventArgs e)
        {
            SurfaceMaterial material = (SurfaceMaterial)Enum.Parse(typeof(SurfaceMaterial), materialListBox.SelectedItem.ToString());
            //set surface material here
            Desk d = (Desk)Application.Current.Properties["Desk"];
            d.deskTopType = material;

            Uri uri = new Uri("ifRush.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        
    }
}
