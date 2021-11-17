using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part9
{
    public interface IPantry
    {
        Ingredient Measure(string name, string amount);
        TIngredient Measure<TIngredient>(Func<TIngredient> instantiate);
    }
}
