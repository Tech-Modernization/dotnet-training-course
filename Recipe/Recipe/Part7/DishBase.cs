﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe.Part7
{
    public class DishBase : List<Ingredient>
    {
        public string DishName { get; }

        public DishBase(string dishName)
        {
            DishName = dishName;
        }

        public override string ToString()
        {
            return $"DishBase({this.GetType().Name}): {DishName} \n" + string.Join("    \n", this.Select(ing => ing.Name));
        }
    }
}
