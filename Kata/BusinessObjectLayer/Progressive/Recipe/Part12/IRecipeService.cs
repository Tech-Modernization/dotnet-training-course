using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part12
{
    public interface IRecipeService
    {
        List<string> LoadPantry();
    }
}
