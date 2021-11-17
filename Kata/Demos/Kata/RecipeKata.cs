using System;
using System.Collections.Generic;

using Part1 = Kata.CustomTypes.Kata.Recipe.Part1;
using Part2 = Kata.CustomTypes.Kata.Recipe.Part2;
using Part3 = Kata.CustomTypes.Kata.Recipe.Part3;
using Part4 = Kata.CustomTypes.Kata.Recipe.Part4;
using Part5 = Kata.CustomTypes.Kata.Recipe.Part5;
using Part6 = Kata.CustomTypes.Kata.Recipe.Part6;
using Part7 = Kata.CustomTypes.Kata.Recipe.Part7;
using Part8 = Kata.CustomTypes.Kata.Recipe.Part8;
using Part9 = Kata.CustomTypes.Kata.Recipe.Part9;
using Part10 = Kata.CustomTypes.Kata.Recipe.Part10;
using Part11 = Kata.CustomTypes.Kata.Recipe.Part11;
using Part12 = Kata.CustomTypes.Kata.Recipe.Part12;
//using Part13 = Kata.CustomTypes.Kata.Recipe.Part13;


namespace Kata.Demos
{
    public class RecipeKata : DemoBase
    {
        public override void Run()
        {
            AddPart(Part1, "Set up a basic ingredient");
            AddPart(Part2, "Use an anon method to create a list of ingredients");
            AddPart(Part3, "Create an interface to prepare the ingredients");
            AddPart(Part4, "Add a child ingredient to the list");
            AddPart(Part5, "Introduce an intermediate stage of meal preparation");
            AddPart(Part6, "Create a means of following the recipe");
            AddPart(Part7, "Allow the recipe to instantiate the dish and protect it from abuse of generics");
            AddPart(Part8, "Create a data source for the Dish by introducing the Pantry");
            AddPart(Part9, "Provide a way to specify an alternate preparation method for ingredients");
            AddPart(Part10, "Load the ingredients from a JSON file");
            AddPart(Part11, "Decouple the data source and load from CSV instead");
            AddPart(Part12, "Write a JsonRecipeService and witness the beauty of Dependency Inversion!");
            base.Run();
        }

        public void Part1()
        {
            var ing = new Part1.Ingredient("eggs", "2");
            dbg(ing);
        }
        public void Part2()
        {
            var ingList = new List<Part2.Ingredient>();
            Func<string, string, Part2.Ingredient> measure = (name, amount) => new Part2.Ingredient(name, amount);

            ingList.Add(measure("eggs", "4"));
            ingList.Add(measure("salt", "a pinch"));
            ingList.Add(measure("beef mince", "1/2 lb"));
            ingList.Add(measure("spaghetti", "125g"));

            foreach (var ing in ingList)
            {
                dbg(ing);
            }
        }

        public void Part3()
        {
            var ingList = new List<Part3.Ingredient>();
            Func<string, string, Part3.Ingredient> measure = (name, amount) => new Part3.Ingredient(name, amount);

            ingList.Add(measure("eggs", "4"));
            ingList.Add(measure("salt", "a pinch"));
            ingList.Add(measure("beef mince", "1/2 lb"));
            ingList.Add(measure("spaghetti", "125g"));

            foreach (var ing in ingList)
            {
                dbg(ing);
                ing.Prepare();
            }
        }
        public void Part4()
        {
            var ingList = new List<Part4.Ingredient>();
            Func<string, string, Part4.Ingredient> measure = (name, amount) => new Part4.Ingredient(name, amount);

            ingList.Add(measure("eggs", "4"));
            ingList.Add(measure("salt", "a pinch"));
            ingList.Add(measure("beef mince", "1/2 lb"));
            ingList.Add(measure("spaghetti", "125g"));
            ingList.Add(new Part4.Tomato("half a dozen"));

            foreach (var ing in ingList)
            {
                dbg(ing);
                ing.Prepare();
            }
        }

        public void Part5()
        {
            var stage = new Part5.Stage("roux", true);
            dbg(stage);
        }

        public void Part6()
        {
            var r = new Part6.Recipe<string>("beans on toast");
            r.Follow();
        }
        public void Part7()
        {
            var spagBol = new Part7.Recipe<Part7.SpagBol>();
            var salad = new Part7.Recipe<Part7.Salad>();

            dbg(spagBol);
            dbg(salad);
        }

        public void Part8()
        {
            var r = new Part8.Recipe<Part8.SpagBol>();
            r.Follow();
        }

        public void Part9()
        {
            var r = new Part9.Recipe<Part9.SpagBol>();
            r.Follow();
        }

        public void Part10()
        {
            var r = new Part10.Recipe<Part10.SpagBol>();
            r.Follow();
        }

        public void Part11()
        {
            var r = new Part11.Recipe<Part11.SpagBol>();
            r.Follow();
        }

        public void Part12()
        {
            var r = new Part12.Recipe<Part12.SpagBol>();
            r.Follow();
        }

    }

}
