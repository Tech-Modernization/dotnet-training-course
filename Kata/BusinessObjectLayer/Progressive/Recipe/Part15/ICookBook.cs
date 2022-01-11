using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part15
{
    public interface ICookBook
    {
        Ingredient Measure(string strIngredient, string amount, Func<Ingredient> instantiator = null);
        DishBase LoadDish(string dishName);
    }
}
