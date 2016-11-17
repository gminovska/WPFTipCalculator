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

namespace ITC110Assignment_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tipCustom.IsChecked = true;
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            //get the meal cost
            double mealPrice = 0;
            double tipPercent = 0;
            bool validPrice = double.TryParse(mealPriceInput.Text, out mealPrice);
            bool validTip = true;
            //get data from the radio buttons
            if (tip10.IsChecked == true)
            {
                tipPercent = 10;
            }
            else if(tip15.IsChecked == true)
            {
                tipPercent = 15;
            }
            else if (tip20.IsChecked == true)
            {
                tipPercent = 20;
            }
            else
            {
                validTip = double.TryParse(customTipTextBox.Text, out tipPercent); 
            }
            //show error message if the input was not valid
            if (!validPrice && !validTip)
            {
                errorMsgText.Text = "That is not a valid price and tip. Please try again";
            }
            else if (!validTip)
            {
                errorMsgText.Text = "That is not a valid tip. Please try again";
            }
            else if (!validPrice)
            {
                errorMsgText.Text = "That is not a valid price. Please try again";
            }
            else
            {
                errorMsgText.Text = "";
            }

            //if the input is valid perform the calculations
            if (validPrice && validTip)
            {
                //create a Bill object to use the methods for calculation
                Bill myBill = new Bill(mealPrice, tipPercent);
                double tip = myBill.CalculateTip();
                double tax = myBill.CalculateTax();
                double total = myBill.CalculateTotal();
                //output the results, formatted to max 2 decimal places
                mealPriceOutput.Text = "$" + mealPrice.ToString("0.##");
                tipOutput.Text = "$" + tip.ToString("0.##");
                taxOutput.Text = "$" + tax.ToString("0.##");
                totalOutput.Text = "$" + total.ToString("0.##");
            }
            else
            {
                mealPriceOutput.Text = "";
                tipOutput.Text = "";
                taxOutput.Text = "";
                totalOutput.Text = "";
            }
        }
    }
}
