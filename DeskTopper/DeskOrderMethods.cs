using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeskTopper
{
    class DeskOrderMethods : IDesk
    {
        static int MIN_VALUE_DeskSize = 1;
        static int MAX_VALUE_DeskSize = 500;

        //save users order info to external file
        public void saveOrderInfo(Desk desk)
        {
            bool printCheck = true;
            string orderName = desk.buyerName;
            try
            {
                //organize order info into JSON format

                string deskOrderInfo = JsonConvert.SerializeObject(desk, Formatting.Indented);
                string[] stringArray = new string[1] { deskOrderInfo };

                //write order info to external file
                File.WriteAllLines("DeskQuote_" + orderName + ".txt", stringArray);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                printCheck = false;

            }
            if (printCheck != false)
                MessageBox.Show("Order for " + desk.buyerName + " has been confirmed.");
        }
        //trim and parse string into int
        public int validateIntInput(string iInput)
        {
            int number = 0;
            try
            {
                number = int.Parse(iInput.Trim());
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            return number;
        }
        //check that value is within reasonable range
        public bool checkValid(int value)
        {
            if ((value < MIN_VALUE_DeskSize) || (value > MAX_VALUE_DeskSize))
            {
                return false;
            }
            else
                return true;
        }
        //check that string is not blank or a number
        public bool checkValidString(string input)
        {
            bool test;
            int placeholder;
            test = int.TryParse(input, out placeholder);
            if (test == true)
                MessageBox.Show("Error: Please enter a name, not a number.");
            else if (input == "")
            {
                test = true;
                MessageBox.Show("Error: Please enter a name in the box.");
            }
            return test;
        }

        public void CalcTotalCost(Desk desk)
        {
            desk.priceEstimate = CalcAreaCost(desk) + CalcDrawerCost(desk) + CalcMaterialCost(desk) + CalcRushOrderCost(desk);
        }

        private int CalcDrawerCost(Desk desk)
        {
            int cost = desk.noOfDrawers * 50;
            return cost;
        }

        //determine rush order pricing using size of desk and rush order timing.
        private int CalcRushOrderCost(Desk desk)
        {
            int deskArea = getArea(desk.deskWidth, desk.deskLength);
            int rushCost = 0;
            int i = 0, j = 0;


            if (desk.rushOrder.Equals("14 days"))
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
                switch (desk.rushOrder)
                {
                    case "3 days":
                        i = 0;
                        break;
                    case "5 days":
                        i = 1;
                        break;
                    case "7 days":
                        i = 2;
                        break;
                }

                //read in rush order pricing file
                int[,] rushOrderPricing = new int[3, 3];
                GetRushOrderInfo(rushOrderPricing);

                //use i and j values to pull up appropriate pricing from 2D array
                rushCost = rushOrderPricing[i, j];

                return rushCost;
            }

        }

        private int getArea(int width, int length)
        {
            int area = width * length;
            return area;
        }

        //determine material price based on user selection and return price
        private int CalcMaterialCost(Desk desk)
        {
            int price = 0;
            switch (desk.deskTopType)
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
                    MessageBox.Show("Invalid material choice detected during calculations.");
                    return 0;
            }
            return price;
        }

        //calculate a price based on desk surface area and return price
        private int CalcAreaCost(Desk desk)
        {
            int deskArea = getArea(desk.deskWidth, desk.deskLength);
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
        private void GetRushOrderInfo(int[,] array)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"rushOrderPrices.txt");
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
                MessageBox.Show(e.Message);
            }
        }

    }
}
