using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part11
{
    public interface IPantry
    {
        Ingredient Measure(string strIngredient, string amount, Func<Ingredient> instantiator = null);
    }
}
