using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;


namespace Kata.Demos
{
    public class Exercise14Done : DemoBase
    {
        Action<object> CW = Console.WriteLine;

        List<Ingredient> ingreds;
        public override void Run()
        {
            
            RunPart1();
            RunPart2();
            RunPart3();
            RunPart4();
            RunPart5();
            RunPart6();
            RunPart7();
            RunPart8();
            RunPart9();
            RunPart10();
            RunPart11();

        }
        private void RunPart1()
        {
            Console.WriteLine(new Ingredient("lettuce", "half"));
        }
        private void RunPart2()
        {
            ingreds = new List<Ingredient>();
            Func<string, string, Ingredient> measure = (nam, amt) => new Ingredient(nam, amt);
            ingreds.Add(measure("egg", "5"));
            ingreds.Add(measure("salt", "a pinch"));
            ingreds.Add(measure("beef mince", "1/2lb"));
            ingreds.Add(measure("spaghetti", "250g"));
        }
        private void RunPart3()
        {
            foreach (var i in ingreds)
                Console.WriteLine(i);
        }
        private void RunPart4()
        {
            ingreds.Add(new Tomato("half a dozen"));
            RunPart3();
        }
        private void RunPart5()
        {
            CW(new Stage("make the bed"));
        }
        private void RunPart6()
        {
            /*
            var r = new Recipe<string>("beans on toast");
            r.Process(ingreds =>
            {
                var s = new Stage("fake stage");
                CW(s);
                s.Ready = true;
                CW(s);
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
        private void RunPart8()
        {
            var r = new Recipe<SpagBol>();
            CW(r);
        }
        private void RunPart9()
        {
            var r = new Recipe<SpagBol>();
            r.Follow();
        }
        private void RunPart10()
        {
            var r = new Recipe<SpagBol>();
        }
        private void RunPart11()
        {


            var emptyJsonObjectStr = "{}";
            var emptyJObject = JsonConvert.DeserializeObject(emptyJsonObjectStr);

            var recipes = new List<object>();
            recipes.Add(new Recipe<SpagBol>());
            recipes.Add(new Recipe<Salad>());
            recipes.Add(new Recipe<FryUp>());

            recipes.Add(new SpagBol());
            recipes.Add(new Salad());
            recipes.Add(new FryUp());

            File.WriteAllText("e14p11.json", JsonConvert.SerializeObject(recipes));



            var jsonText = File.ReadAllText("../../../ingredients.json");
            var ingredients = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);
        }



        public interface IPantry
        {
            Ingredient Measure(string name, string amount);
            Ingredient Measure<TIngredient>(Func<Ingredient> instantiate);
        }

        public interface IIngredient
        {
            void Prepare(PreparationFlags flags);
        }


        public class Pantry : IPantry
        {
            public Ingredient Measure(string name, string amount)
            {
                return new Ingredient(name, amount);
            }

            public Ingredient Measure<TIngredient>(Func<Ingredient> instantiate)
            //public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate)
            //public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate) where TIngredient : Ingredient
            //public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate) where TIngredient : new()
            {
                //if (instantiate == null) instantiate = () => new TIngredient();
                return instantiate();
            }
        }

        [Flags]
        public enum PreparationFlags { None, ReplaceWithAltPrepare, AppendToBasePrepare }
        public class Ingredient : IIngredient
        {
            public string Amount { get; }
            public bool Prepared { get; set; }
            public string Name { get; }

            private Action AltPrepare;
            public Ingredient()
            {
            }
            public Ingredient(string name, string amount)
            {
                Amount = amount;
                Name = name;
            }
            public Ingredient(string name, string amount, Action altPrepare) : this(name, amount)
            {
                AltPrepare = altPrepare;
            }

            public virtual void Prepare(PreparationFlags flags = PreparationFlags.None)
            {
                if (AltPrepare != null)
                {
                    if (flags.HasFlag(PreparationFlags.ReplaceWithAltPrepare))
                    {
                        Prepared = true;
                        return;
                    }

                }
                if (AltPrepare == null || flags.HasFlag(PreparationFlags.AppendToBasePrepare))
                {
                    Console.WriteLine($"Preparing the {Name}");
                    Prepared = true;
                }
            }

            public override string ToString()
            {
                return $"Ingredient: {Amount} of {Name}";
            }
        }
        public class Egg : Ingredient
        {
            public Egg(string amount) : base("Egg", amount)
            {
            }

            public Egg(string name, string amount, Action altPrepare) : base(name, amount, altPrepare)
            {
            }

            public override void Prepare(PreparationFlags flags = PreparationFlags.None)
            {
                base.Prepare(PreparationFlags.ReplaceWithAltPrepare);
                Console.WriteLine("Beating the egg");
                Prepared = true;
            }
        }

        public class Tomato : Ingredient
        {
            public Tomato(string amount) : base("Tomato", amount)
            {
            }

            public Tomato(string amount, Action altPrepare) : base("Tomato", amount, altPrepare)
            {
            }

            public override void Prepare(PreparationFlags flags = PreparationFlags.None)
            {
                base.Prepare(PreparationFlags.ReplaceWithAltPrepare);

                Console.WriteLine("Slicing the tomato");
                Prepared = true;
            }
        }

        public class Stage
        {
            public bool Ready;
            public string Name;

            public Stage(string name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return $"{Name} stage is {(Ready ? "ready" : "not ready")}";
            }
        }

        public interface IRecipeFollower<T>
        {
            void Follow();
            Stage Process(Func<Ingredient[], Stage> process, params Ingredient[] ingredients);
            T Assemble(List<Stage> stages, List<Ingredient> ingredients, Action<T>[] step);
        }
        public class Lettuce : Ingredient
        {
            public Lettuce(string amount) : base("Lettuce", amount)
            {
            }

            public override void Prepare(PreparationFlags flags = PreparationFlags.None)
            {
                base.Prepare(PreparationFlags.AppendToBasePrepare);
                Console.WriteLine("Shredding the lettuce");
            }
        }

        public class DishBase : List<Ingredient>
        {
            protected Pantry pantry = new Pantry();
            public string DishName { get; set; }
        }
        public class SpagBol : DishBase
        {
            public SpagBol()
            {
                DishName = "Spaghetti Bolognese";
                Add(pantry.Measure("Spaghetti", "125g"));
                Add(pantry.Measure("Olive oil", "1 tbsp"));
                Add(pantry.Measure("Salt", "a pinch"));
                Add(pantry.Measure("Beef mince", "1/2lb"));
                Add(pantry.Measure<Tomato>(() => new Tomato("half a dozen")));
                Add(pantry.Measure<List<DateTime>>(() => new List<DateTime>());

                var ldt = pantry.Measure<List<DateTime>>(() => new List<DateTime>());
            }
        }

        public class Recipe<TDish> : IRecipeFollower<TDish>
                   where TDish : DishBase, new()
        {
            TDish Dish;

            public Recipe()
            {
                Dish = new TDish();
            }
            public Recipe(TDish dish)
            {
                Dish = dish;
            }

            public TDish Assemble(List<Stage> stages, List<Ingredient> ingredients, Action<TDish>[] step)
            {
                throw new NotImplementedException();
            }

            public void Follow()
            {
                foreach (var i in Dish)
                {
                    i.Prepare();
                    System.Threading.Thread.Sleep(2000);
                }

            }

            public Stage Process(Func<Ingredient[], Stage> process, params Ingredient[] ingredients)
            {
                return process(ingredients);
            }

            public override string ToString()
            {
                var d = Dish as DishBase;
                return $"Following recipe for {d.DishName}";
            }
        }
        public class FryUp : DishBase
        {
            public FryUp()
            {
                DishName = "Cooked Breakfast";
            }
        }
        public class Salad : DishBase 
        {
            public string SaladName { get; }
            public Salad()
            {
                SaladName = "Salad";
            }
        }
    }
}