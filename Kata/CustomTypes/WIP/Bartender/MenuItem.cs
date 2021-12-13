using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Bartender
{
    public class MenuItem
    {
        public string Text { get; }
        public DrinkMeasure Measure { get; }
        public decimal Price { get; }
        public MenuItem(string text, DrinkMeasure measure, decimal price)
        {
            Text = text;
            Measure = measure;
            Price = price;
        }
    }
}
