using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.WIP.Part11
{
    public interface IPantry
    {
        public TIngredient Measure<TIngredient>(string searchName, Func<TIngredient> instantiate = null)
            where TIngredient : Ingredient;
    }
}
