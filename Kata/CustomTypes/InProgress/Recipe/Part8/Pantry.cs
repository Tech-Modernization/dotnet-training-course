﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part8
{
    public class Pantry : IPantry
    {
        public Ingredient Measure(string name, string amount)
        {
            return new Ingredient(name, amount);
        }

        public TIngredient Measure<TIngredient>(Func<TIngredient> instantiator) where TIngredient : Ingredient
        {
            return instantiator();
        }
    }
}
