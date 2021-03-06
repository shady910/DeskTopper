﻿using System;
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
            DeskOrderMethods dom = new DeskOrderMethods();

            String buyerName = buyerNameBox.Text.Trim();
            bool check = dom.checkValidString(buyerName);
            if (check != true)
            {
                d.buyerName = buyerName;
                Uri uri = new Uri("DeskOrder.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
