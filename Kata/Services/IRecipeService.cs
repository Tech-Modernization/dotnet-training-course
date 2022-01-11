using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServiceLayer
{
    public interface IRecipeService
    {
        Dictionary<string, string> LoadPantry();
    }
}
