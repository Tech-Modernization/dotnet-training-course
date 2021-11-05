using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe
{
    public class DishBase : List<Ingredient>
    {
        public string DishName { get; }
        public DishBase(string dishName)
        {
            DishName = dishName;
        }


    }
}
