using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.Extensions;
using Kata.DataServices;

namespace Kata.CustomTypes.RecipeDemo
{
    public class SpagBol : DishBase
    {
        public SpagBol() : base("Spaghetti Bolognese")
        {
            Add(Pantry.Measure("spag"));
            Add(Pantry.Measure("olive"));
            Add(Pantry.Measure("salt"));
            Add(Pantry.Measure(() =>
            {
                var ing = Pantry.Measure("b  eef");
                return new Ingredient(ing.Name, ing.Amount, () => Console.WriteLine("pulverise and season the meat"));
            }));

            Add(Pantry.Measure(() =>
            {
                var ing = Pantry.Measure("Button mushrooms", "Half a dozen");
                return new Ingredient(ing.Name, ing.Amount, () => Console.WriteLine("Put in whole - wash and add butter"));
            }));

            Add(Pantry.Measure(() =>
            {
                var ing = Pantry.Measure(" t o m");
                return new Tomato(ing.Amount, PrepTomato);
            }));

        }

        public void PrepTomato()
        {
            Console.WriteLine($"Soak tomatoes in boiling water\nRemove skin and mash");
        }
    }
}
