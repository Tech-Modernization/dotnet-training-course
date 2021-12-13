using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.CustomTypes.Kata.Recipe.Part11
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Ingreds.Add(Pantry.Measure(" SP AG", "125g"));
            Ingreds.Add(Pantry.Measure("Beef Mince", "1/2lb"));
            var peaQuantity = "half a bag";
            Ingreds.Add(Pantry.Measure("peas", peaQuantity, () => new Peas(peaQuantity)));
            var tomQuantity = "half a dozen";
            Ingreds.Add(Pantry.Measure("TOMA", tomQuantity, () => new Tomato(tomQuantity, () => Console.WriteLine("Chopping the tomatoes"))));
        }
    }
}
