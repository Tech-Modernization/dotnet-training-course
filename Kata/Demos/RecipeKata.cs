using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Kata.CustomTypes.RecipeDemo;

namespace Kata.Demos
{
    public class RecipeKata : DemoBase
    {
        List<Ingredient> ingreds = new List<Ingredient>();
        public override void Run()
        {
            /*           AddPart(RunPart1, "encapsulate the smallest units of data");
                       AddPart(RunPart2, "practice using an anonymous method in isolation");
                       AddPart(RunPart3, "encapsulate the functionality to prepare an ingredient\n" +
                           "- practice coding interfaces");
                       AddPart(RunPart4, "- practice overriding a virtual method\n" +
                           "- practice providing a parameterless constructor while satisfying the requirements of the base constructor");
                      AddPart(RunPart5, "provide a means of reflecting the milestones in the preparation of a meal");
                       AddPart(RunPart10, "- using generic types with anonymous methods\n" +
                           "- practice inline anonymous methods");*/
            AddPart(RunPart11, "Implement Follow method");
            AddPart(RunPart12, "Specify alternate preparation methods");
            AddPart(RunPart13, "Load ingredients from a JSON file");
            AddPart(RunPart15, "Add dependency inversion/injection");
            base.Run();
        }

        private void RunPart1()
        {
            Console.WriteLine(new Ingredient("lettuce", "half"));
        }
        private void RunPart2()
        {
            
            Func<string, string, Ingredient> measure = (nam, amt) => new Ingredient(nam, amt);
            ingreds.Add(measure("egg", "5"));
            ingreds.Add(measure("salt", "a pinch"));
            ingreds.Add(measure("beef mince", "1/2lb"));
            ingreds.Add(measure("spaghetti", "250g"));

            foreach (var i in ingreds)
                dbg(i);
        }
        private void RunPart3()
        {
            foreach (var i in ingreds)
            {
                i.Prepare();
            }
        }
        private void RunPart4()
        {
            ingreds.Add(new Tomato("half a dozen"));
            RunPart3();
        }
        private void RunPart5()
        {
            dbg(new Stage("make the bed"));
        }
        private void RunPart6()
        {
            /*
            var r = new Recipe<string>("beans on toast");
            r.Process(ingreds =>
            {
                var s = new Stage("fake stage");
                dbg(s);
                s.Ready = true;
                dbg(s);
                return s;
            }, ingreds[0], ingreds[1]);
            */

        }
        private void RunPart7()
        {
            /*
            var r1 = new Recipe<SpagBol>(new SpagBol());
            Console.WriteLine(r1);
            var r2 = new Recipe<Salad>(new Salad());
            Console.WriteLine(r2);
            */
        }


        private void RunPart11()
        {
            var r = new Recipe<SpagBol>();
            r.Follow();
        }
        private void RunPart12()
        {
            var r = new Recipe<SpagBol>();
            r.Follow();
        }
        private void RunPart13()
        {
            var r = new Recipe<SpagBol>();
            foreach(var i in r.Dish)
            {
                Console.WriteLine($"{r.Dish.DishName} uses {i}");
            }
        }
        private void RunPart15()
        {
            RunPart13();
        }
    }
}
