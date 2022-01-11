using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Recipe.Part12
{
    public interface IPantry
    {
        List<string> LookupIngredient(string name);
    }
}
