using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part15
{
    public interface IRecipeService
    {
        List<string> LoadPantry();
        List<DishBase> LoadDishes();
    }
}
