using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Kata.Recipe.Part15
{
    public interface IRecipeService
    {
        List<string> LoadPantry();
        List<DishBase> LoadDishes();
    }
}
