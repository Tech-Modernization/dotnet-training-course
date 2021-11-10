using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Kata.Helpers;

using Newtonsoft.Json;

using static Kata.Demos.RecipeDemo;

namespace Kata.Demos
{
    public class RecipeDemo : DemoBase
    {
        Action<object> CW = Console.WriteLine;
        const string dbDir = "../../../../CustomTypes/WIP/RecipeDemo/";

        List<Ingredient> ingreds;

               
        public override void Run()
        {
            RunPart1();
            RunPart2();
            RunPart3();
            RunPart4();
            RunPart5();
        //    RunPart6();
        //    RunPart7();
        //    RunPart8();
        //    RunPart9();
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
        }
        private void RunPart10()
        {
            var r = new Recipe<SpagBol>();
        }
        private void RunPart11()
        {
            var spagBol = new Recipe<SpagBol>();
            spagBol.Follow();
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

        public class Stage : List<Ingredient>, IIngredientIndexer
        {
            public bool Ready;
            public string Name;
            public Func<bool> Process;

            public Stage(string name)
            {
                Name = name;
                Ready = false;
            }

            public Ingredient this[string name] => this.SingleOrDefault(i => i.Name.ToLower() == name.ToLower());

            public override string ToString()
            {
                return $"{Name} stage is {(Ready ? "ready" : "not ready")}";
            }
        }

        public interface IIngredientIndexer
        {
            Ingredient this[string name]
            {
                get;
            }
        }
        public interface IRecipeBuilder
        {
            void AddStage(string name, Func<bool> process, params Ingredient[] ingredients);
        }
        public interface IRecipeFollower<T>
        {
            void Follow();
            void Assemble(params Action<T>[] steps);
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

        public class DishBase : List<Ingredient>, IIngredientIndexer
        {
            protected Pantry pantry = new Pantry();

            public Ingredient this[string name] => this.SingleOrDefault(i => i.Name.ToLower() == name.ToLower())
                                                    ?? this.FirstOrDefault(i => i.Name.ToLower().StartsWith(name.ToLower()));


            public string DishName { get; set; }
            public List<Stage> Stages { get; }
            public DishBase()
            {
                Stages = new List<Stage>();
            }

        }

        public class InterruptionService : IInterrupter
        {
            Dictionary<string, int> interruptions;
            Random rand = new Random();
            public InterruptionService()
            {
                interruptions = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("../../../interruptions.json"));
            }

            public int MaxInterruptions => 5;

            public int GetInterruption()
            {
                var next = rand.Next(0, interruptions.Count - 1);
                if (next > 0)
                {
                    Console.WriteLine($"Drat!  And double drat!!  Interrupted by {interruptions.Keys.ToList()[next]}!  Delayed by {next} minutes!");
                }
                return next * 1000;
            }

          }
        public interface IInterrupter
        {
            int GetInterruption();
            int MaxInterruptions { get; }
        }
        public class SpagBol : DishBase, IRecipeBuilder
        {
            IInterrupter Interrupter = new InterruptionService();
            public SpagBol()
            {
                DishName = "Spaghetti Bolognese";
                Add(pantry.Measure("Spaghetti", "125g"));
                Add(pantry.Measure("Olive oil", "1 tbsp"));
                Add(pantry.Measure("Salt", "a pinch"));
                Add(pantry.Measure("Beef mince", "1/2lb"));
                Add(pantry.Measure<Tomato>(() => new Tomato("half a dozen")));

                AddStage("Ragu", () => {
                    Console.WriteLine($"Add seasoning and brown the {this["beef mince"]}");
                    Console.WriteLine($"Stir {this["tomato"]} into the {this["beef mince"]}");
                    return this.All(i => i.Prepared);
                }, this["beef"], this["salt"], this["tomato"]);

                AddStage("Pasta", () => {
                    Console.WriteLine($"Boil the kettle and put the {this["spaghetti"]} in a saucepan with {this["olive oil"]}");
                    Console.WriteLine($"Add {this["salt"]} and pour the boiling water over the {this["spaghetti"]}");
                    return this.All(i => i.Prepared);
                }, this["beef"], this["salt"], this["tomato"]);
            }

            public void AddStage(string name, Func<bool> process, params Ingredient[] ingredients)
            {
                var stage = new Stage(name) { Process = process };
                stage.AddRange(ingredients);
                Stages.Add(stage);
            }

        }

        public class Recipe<TDish> : IRecipeFollower<TDish>
                   where TDish : DishBase, new()
        {
            TDish Dish;
            IInterrupter Interrupter = new InterruptionService();
            private List<Stage> Stages = new List<Stage>();
            public Recipe()
            {
                Dish = new TDish();
            }

            public void Assemble(params Action<TDish>[] steps)
            {
                foreach(var step in steps)
                {
                    step(Dish);
                }
            }

            public void Follow()
            {
                foreach (var i in Dish)
                {
                    i.Prepare();
                }
                
                foreach(var s in Dish.Stages)
                {
                    var attempts = 1;
                    while (!s.Ready)
                    {
                        Console.WriteLine($"Attempt #{attempts} to complete the {s.Name} stage");
                        var waitMillis = Interrupter == null ? 0 : Interrupter.GetInterruption();
                        if (waitMillis > 0)
                        {
                            Thread.Sleep(waitMillis);
                            attempts++;
                            continue;
                        }
                        else if (attempts == 1)
                        {
                            Console.WriteLine($"Woohoo!  Completed the {s.Name} without interruption!");
                        }
                        s.Ready = s.Process();
                    }
                }

                Assemble();
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