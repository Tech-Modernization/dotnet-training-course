using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part10
{
    public interface IPantry
    {
        TIngredient Measure<TIngredient>(string searchName, Func<TIngredient> instantiate)
            where TIngredient : Ingredient;
    }
}
