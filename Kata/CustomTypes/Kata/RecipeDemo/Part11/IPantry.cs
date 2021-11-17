using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part11
{
    public interface IPantry
    {
        public TIngredient Measure<TIngredient>(string searchName, Func<TIngredient> instantiate)
            where TIngredient : Ingredient;
    }
}
