using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part9
{
    public interface IPantry
    {
        Ingredient Measure(string name, string amount);
        TIngredient Measure<TIngredient>(Func<TIngredient> instantiator) where TIngredient : Ingredient;
    }
}
