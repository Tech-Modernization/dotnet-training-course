﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Part8
{
    public class Pantry : IPantry
    {
        public Ingredient Measure(string name, string amount)
        {
            return new Ingredient(name, amount);
        }

        public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate)
        {
            return instantiate();
        }
    }
}
