using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.WIP.Recipe.Part12
{
    public interface IPantry
    {
        public TIngredient Measure<TIngredient>(string searchName, Func<TIngredient> instantiate = null)
            where TIngredient : Ingredient;
    }
}
