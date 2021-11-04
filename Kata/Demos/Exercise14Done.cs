using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;


namespace Kata.Demos
{
    public class Exercise14Done : IDemo
    {
        Action<object> CW = Console.WriteLine;

        List<Ingredient> ingreds;
        public void Run()
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
            var r = new Recipe<DishBase>();
            r.Process(ingreds =>
            {
                var s = new Stage("fake stage");
                CW(s);
                s.Ready = true;
                CW(s);
                return s;
            }, ingreds[0], ingreds[1]);


        }


        private void RunPart7()
        {
            throw new NotImplementedException();
        }
        private void RunPart8()
        {
            throw new NotImplementedException();
        }
        private void RunPart9()
        {
            throw new NotImplementedException();
        }
        private void RunPart10()
        {
            throw new NotImplementedException();
        }
        private void RunPart11()
        {
            var jsonText = File.ReadAllText("../../../ingredients.json");
            var ingredients = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);
        }



        public interface IPantry
        {
            Ingredient Measure(string name, string amount);
            public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate) where TIngredient : Ingredient;
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

            public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate) where TIngredient : Ingredient
            {
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

                if (flags.HasFlag(PreparationFlags.AppendToBasePrepare))
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

        public interface IRecipeFollower<T> where T : DishBase
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
                Add(pantry.Measure(() => new Tomato("half a dozen", () => Console.WriteLine("Soak in boiled water, peel and mash"))));

            }
        }

        public class Recipe<T> : IRecipeFollower<T> where T : DishBase, new()
        {
            T Dish;

            public Recipe()
            {
                Dish = new T();
            }

            public T Assemble(List<Stage> stages, List<Ingredient> ingredients, Action<T>[] step)
            {
                throw new NotImplementedException();
            }

            public void Follow()
            {
                foreach (var i in Dish)
                {
                    i.Prepare();
                }
            }

            public Stage Process(Func<Ingredient[], Stage> process, params Ingredient[] ingredients)
            {
                return process(ingredients);
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
            public Salad()
            {
                DishName = "Salad";
            }
        }
    }
}