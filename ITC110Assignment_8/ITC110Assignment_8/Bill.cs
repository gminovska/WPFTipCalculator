using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITC110Assignment_8
{
    class Bill
    {
        public double MealCost { get; set; }
        public double TipPercent { get; set; }

        public readonly double Tax = 0.09;

        //private fields whose values are set by the tax and tip method, and used by the total method;
        private double tipAmount = 0;
        private double taxAmount = 0;
        

        //constructors
        public Bill() { }
        public Bill(double MealCost, double TipPercent)
        {
            this.MealCost = MealCost;
            this.TipPercent = TipPercent;
        }
        //methods
        public double CalculateTip()
        {
            double tipAmount = MealCost * (TipPercent * 0.01);
            this.tipAmount = tipAmount;
            return tipAmount;
        }

        public double CalculateTax()
        {
            double taxAmount = MealCost * Tax;
            this.taxAmount = taxAmount;
            return taxAmount;
        }
        public double CalculateTotal()
        {
            double total = MealCost + tipAmount + taxAmount;
            return total;
        }
    }
}
