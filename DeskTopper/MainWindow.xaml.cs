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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private Desk newDeskQuote;
        public MainWindow()
        {
            InitializeComponent();

            newDeskQuote = new Desk();
            this.DataContext = newDeskQuote;
        }
        // new class
        

        public interface deskOrder
        {
            void saveOrderInfo(Desk desk);
            int CalcRushOrder(int[,] rushOrderPricing, int rushOrder, int deskArea);
            int CalcMaterialPrice(SurfaceMaterial material);
            int CalcAreaPrice(int deskArea);
            void GetRushOrder(int[,] array);
            int GetIntegerOption(string prompt, int opt1, int opt2, int opt3, int opt4);
            SurfaceMaterial GetSurfaceType(string prompt);
            string GetStringOption(string prompt, string opt1, string opt2);
            int GetIntegerInRange(string prompt, int minValue, int maxValue);
            string GetInput(string prompt);
        }
        
        class Program
        {
            static void Main(string[] args)
            {   //set up do...while loop to allow users to restart the process

                DeskOrderMethods d = new DeskOrderMethods();

                //get user input
                newDeskQuote.deskWidth = d.GetIntegerInRange(1, 500);
                newDeskQuote.deskLength = d.GetIntegerInRange(1, 500);



                //calculate surface area of desk
                int deskArea = newDeskQuote.deskWidth * newDeskQuote.deskLength;
                int areaPrice = d.CalcAreaPrice(deskArea);

                //calculate drawer pricing
                int drawerPrice = 50 * newDeskQuote.noOfDrawers;

                //calculate material cost
                int materialPrice = d.CalcMaterialPrice(newDeskQuote.deskTopType);

                //read in rush order pricing file
                int[,] rushOrderPricing = new int[3, 3];
                d.GetRushOrder(rushOrderPricing);

                //calculate rush order pricing if applicable.
                int rushOrderPrice = d.CalcRushOrder(rushOrderPricing, newDeskQuote.rushOrder, deskArea);

                //total up the various costs and display total to user.
                newDeskQuote.priceEstimate = areaPrice + drawerPrice + materialPrice + rushOrderPrice;
            }
          
            public class DeskOrderMethods
            {

                public int CalcRushOrder(int[,] rushOrderPricing, int rushOrder, int deskArea)
                {

                    int rushCost = 0;
                    int i = 0, j = 0;

                    if (rushOrder == 0)
                        return 0;
                    else
                    {
                        //use desk area to set i
                        if (deskArea <= 1000)
                            j = 0;
                        else if ((deskArea > 1000) && (deskArea < 2000))
                            j = 1;
                        else
                            j = 2;
                        //use rush order timing to set j
                        switch (rushOrder)
                        {
                            case 3:
                                i = 0;
                                break;
                            case 5:
                                i = 1;
                                break;
                            case 7:
                                i = 2;
                                break;
                        }
                        //use i and j values to pull up appropriate pricing from 2D array
                        rushCost = rushOrderPricing[i, j];

                        return rushCost;
                    }

                }

                //determine material price based on user selection and return price
                public int CalcMaterialPrice(SurfaceMaterial material)
                {
                    int price = 0;
                    switch (material)
                    {
                        case SurfaceMaterial.Oak:
                            price = 200;
                            break;
                        case SurfaceMaterial.Laminate:
                            price = 100;
                            break;
                        case SurfaceMaterial.Pine:
                            price = 50;
                            break;
                        case SurfaceMaterial.Marble:
                            price = 500;
                            break;
                        case SurfaceMaterial.Walnut:
                            price = 250;
                            break;
                        case SurfaceMaterial.Metal:
                            price = 300;
                            break;
                        default:
                            Console.WriteLine("Invalid material choice detected during calculations.");
                            return 0;
                    }
                    return price;
                }

                //calculate a price based on desk surface area and return price
                public int CalcAreaPrice(int deskArea)
                {
                    int price = 0;
                    if (deskArea > 1000)
                    {
                        price = 5 * (deskArea - 1000) + 200;
                    }
                    else
                        price = 200;
                    return price;
                }

                //read in pricing info file and place it into a 2D array
                public void GetRushOrder(int[,] array)
                {
                    try
                    {
                        string[] lines = System.IO.File.ReadAllLines("rushOrderPrices.txt");
                        int count = 0;
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            for (int j = 0; j < array.GetLength(1); j++)
                            {
                                array[i, j] = int.Parse(lines[count]);
                                count++;
                            }
                        }


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }



            }
        }
    }
}

