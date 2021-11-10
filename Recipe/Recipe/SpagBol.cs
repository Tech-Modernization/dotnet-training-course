using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe
{
    public class SpagBol : DishBase
    {
        List<Ingredient> innerList = new List<Ingredient>();
                 public SpagBol() : base("Spaghetti Bolognese")
        {
            Add(Pantry.Measure("Spaghetti", "125g"));
            Add(Pantry.Measure("Olive oil", "1 tbsp"));
            Add(Pantry.Measure("Salt", "a pinch"));
            Add(Pantry.Measure("Beef mince", "1/2lb"));
            Add(Pantry.Measure(() => new Tomato("half a dozen")));

            innerList.Add(new Ingredient("blagh blah", ""));
        }
    }
}
