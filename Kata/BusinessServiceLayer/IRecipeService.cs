using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Services
{
    public interface IRecipeService
    {
        Dictionary<string, string> LoadPantry();
    }
}
