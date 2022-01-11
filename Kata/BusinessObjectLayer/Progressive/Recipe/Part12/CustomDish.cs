using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part12
{
    public class CustomDish : DishBase
    {
        public CustomDish() : base("Fish pie")
        {

        }
        public CustomDish(string dishName) : base(dishName)
        {
        }
    }
}
