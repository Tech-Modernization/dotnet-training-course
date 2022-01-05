using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part10
{
    public interface IPantry
    {
        Ingredient Measure(string strIngredient, string amount, Func<Ingredient> instantiator = null);
    }
}
