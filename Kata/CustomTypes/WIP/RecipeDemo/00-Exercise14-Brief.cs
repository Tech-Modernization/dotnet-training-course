using System;
using System.Collections.Generic;
using System.Text;

/*
Intro 

Exercise objectives are to practice:

- abstraction of a process 
- interface segregation principle
- use of anonymous methods/lambda expressions
- use of generic type parameters at class, interface and method level

This exercise also introduces:
- local file i/o
- JSON (javascript object notation)
- generic type constraints 
   * "where" : a means of filtering the number of types that can be passed as the generic type argument(s)
   * "new()" : a means of enabling a generic type to be instantiated
- cursory introduction to specifying "attribute" syntax
   * applying the [Flags] attribute to an enum

Simulate the process of cooking a meal from getting the ingredients out to dishing up.

Part 1

objective: encapsulate the smallest units of data

- create a class Ingredient, with 2 readonly string properties Name and Amount
- generate a constructor to initialise the properties
- override ToString to return "Ingredient" with "amount" of "name"

Part 2

objectives: 
- practice using an anonymous method in isolation 

in your main program (or the Run method of your demo class if you're using my template)

- declare a list of ingredient
- declare an anonymous method, "measure" that returns an Ingredient and accepts 2 strings as arguments 
- make the body of the method instantiate and return an ingredient using the 2 strings as the name and amount of the ingredient.
- call the method with the following sample data:

    egg                     4
    salt                    a pinch
    beef mince              1/2 lb
    spaghetti               250g

- add the ingredients created to the list 
- loop thru the inredients, writing them to the console

Part 3

objective:
- encapsulate the functionality to prepare an ingredient
- practice coding interfacess

steps:
- create an interface IIngredient with a single method Prepare accepting no arguments
- implement the interface in the Ingredient class 
- make the Prepare method virtual
- have the Prepare method output a message saying it is preparing the ingredient, specifying its name
- update your program to loop thru the list, calling the Prepare method on each

Part 4 

objectives:
- practice overriding a virtual method 
- practice providing a parameterless constructor while satisfying the requirements of the base constructor

steps:
- declare a class Tomato inheriting from Ingredient
- generate the appropriate constructor
- remove the name argument and pass the literal "Tomato" to the base class
- in your program, instantiate the class and add it to the list 
- loop thru the list again.

Part 5 

objective: 
- provide a means of reflecting the milestones in the preparation of a meal

steps:
- declare class Stage to reperesent the combinations of ingredients at various points
- add a bool Ready to it
- add a string Name
- override ToString() to show the state of the Stage
- instantiate a stage and output it

Part 6

conceptual objectives:
- practice class-level generics 
- practice interface-level generics
- practice anonymous methods

functional objective:
- provide a means of abstracting and encapsulating the functionality of following a recipe

steps:
- declare an interface IRecipeFollower<T> 
- add a void method Follow with no arguments
- add a method Process returning Stage 
  * parameter: an anonymous method "process" that receives an array of Ingredients and return a Stage
  * parameter: a variable argument list of Ingredients
- declare a class Recipe<TDish>
- declare a private member Dish of the generic type
- generate a contructor
- have Recipe implement IRecipeFollower and pass TDish on to it
- instantiate a Recipe of string and code a call to the Process method

Part 7

conceptual objectives:
- introduce generic type constraints

functional objectives:
- protect the Recipe class from abuse 

steps:

* instantiating the Recipe class with a string as the generic type is an abuse of the class

- create a class DishBase that inherits from List<Ingredient>
- add a public string property DishName
- create a class SpagBol that inherits from DishBase 
- create a class Salad that doesn't inherit anything
- add a public string property SaladName to Salad
- override ToString in Recipe and output the DishName property of Dish
- test this with both SpagBol and Salad 

* see that Salad crashes
* differently from the menu, we don't want to deal with non-conformant types

- insert this line between the class declaration of Recipt<TDish> and it's opening brace

       where TDish: DishBase

- test with SpagBol and Salad again

* see that the code won't even compile 
  - and if you've still got your Recipe<string> in there, that is now also a problem.

Part 8

conceptual objectives:
- more on generic type constraints.

functional objectives:
- avoid having to pass in an instance of the DishBase to the Recipe constructor

you may remember from the first demo of generics that it wasn't possible to instantiate T.
well, it's not - unless you use the new() constraint

steps:
- add ", new()" to the "where" constraint on the Recipe class
- remove the constructor argument
- change the constructor code to Dish = new TDish();
- remove the Recipe<string> 
- have Salad inherit from DishBase
- retest

part 9

conceptual objectives:
- using generic types with anonymous methods
- practice generic type constraints
- practice anonymous methods 

functional objectives:
- provide a means of instantiating the ingredients for the dish

(if you're stuck on these, the answers are at the end of the step)

steps: 
- create an interface IPantry 
- add a method Measure returning Ingredient and accepting name and amount as 
  with the anonymous version of measure.
- add an overload for Measure taking a generic type parameter TIngredient and returning TIngredient (9A)
- add an anonymous method "instantiate" as an argument to the Measure overload, returning TIngredient (9B)
- declare a class Pantry that implements IPantry (9C)
- add a pantry to DishBase that inheritors can access but not external code (9D)
- in the Spagbol constructor call pantry.Measure with string arguments and add the result to the list (9E)
- then call the generically typed pantry.Measure for a Tomato and add that to the list(9E)
- then call it for a List of DateTime.(9E)

* it won't work cuz the element add to the List *must* be an Ingredient.  

- but what if you move the call to Measure outside?

   var listDateTime = pantry.Measure<List<DateTime>>(() => new List<DateTime>());

* hmmm.  it seems the Measure overload can be abused too.

- add a generic type constraint to the Measure overload in IPantry ensuring that TIngredient "is" always an Ingredient (9F)
- you'll need to add this to the implementation in Pantry as well
- you now have 2 compiler errors for different but related reasons.
- remove the List<DateTime> code from the SpagBol constructor to resolve them.

9A:
TIngredient Measure<TIngredient>();

9B:
TIngredient Measure<TIngredient>(Func<TIngredient> instantiate);

9C:

        public class Pantry : IPantry
        {
            public Ingredient Measure(string name, string amount)
            {
                return new Ingredient(name, amount);
            }

            public TIngredient Measure<TIngredient>(Func<TIngredient> instantiate) 
            {
                return instantiate();
            }
        }

9D:
public class DishBase
{
   protected Pantry pantry { get; }
   public DishBase(string name)
   {
      pantry = new Pantry();
   }
}

9E:
        public class SpagBol : DishBase
        {
            public SpagBol() : base("Spaghetti Bolognese")
            {
                Add(pantry.Measure("Spaghetti", "125g"));
                Add(pantry.Measure("Olive oil", "1 tbsp"));
                Add(pantry.Measure("Salt", "a pinch"));
                Add(pantry.Measure("Beef mince", "1/2lb"));
                Add(pantry.Measure(() => new Tomato("half a dozen")));
                Add(pantry.Measure<List<DateTime>>(() => new List<DateTime>());
            }
        }

9F:
TIngredient Measure<TIngredient>(Func<TIngredient> instantiate) where TIngredient : Ingredient

part 10

conceptual objectives
- using generic types with anonymous methods
- practice inline anonymous methods 

functional objectives
- solve the problem of slicing tomatoes being the wrong preparation method for spaghetti bolognese

steps:
- update your call to Measure<Tomato>() so that it instantiates TIngredient

          Add(pantry.Measure<Tomato>(() => new TIngredient()));

* it won't compile.  why doesn't it know what TIngredient is?  

| by the time this anonymous method is called, the name TIngredient has no meaning.
| that's because the "instantiate()" method *code* is "decoupled" from the Measure signature.
| 
| I'll go thru this in more detail on Monday but for now, just accept that 
| the Measure method passes on TIngredient to instantiate() and since the
| SpagBol constructor has already realised the type as Tomato
|
|     Add(pantry.Measure<Tomato>(...
|
| our inline code knows for sure that's the type it needs to instantiate.  So there's no need
| for a generic reference.

- so, all that's needed is:

        Add(pantry.Measure<Tomato>(() => new Tomato("half a dozen"));

* test it - it "just works" :-)

| it's true that this is overkill.  we always want an ingredient back, so we didn't need a generic 
| type parameter on this method.  but...for demo purposes...


part 11

conceptual objectives:
- introduce file i/o
- use "using" for memory management


functional objectives:
- none, right now :-)

steps:

-- work thru these code snippets, one comment at a time, keeping the file e14p11.txt open in VS2019 or another editor so can you can see it changing as you add more things.

                Action<object> CW = Console.WriteLine;

            // create a text file and write to it
            var outFile = File.CreateText("e14p11.txt");
            outFile.WriteLine("blah blah blah");
            outFile.Close();

            // read the text file back
            var inFile = File.OpenText("e14p11.txt");
            var buf = inFile.ReadToEnd();
            inFile.Close();

            // create a file that happens to be a text file
            var newfile = File.Create("e14p11.txt");
            // create a stream to write to it
            var newStream = new StreamWriter(newfile);
            // write somethign to the stream
            newStream.WriteLine("bish bash bosh");
            // flush it to disk
            newStream.Flush();
            // close the stream
            newStream.Close();
            // close the file
            newfile.Close();

            // allow .net to manage flushing and closing of files and streams
            using (var newfile2 = File.Create("e14p11.txt"))
            {
                using (var newStream2 = new StreamWriter(newfile2))
                {
                    for (var i = 32; i < 91; i++)
                        newStream2.WriteLine((char) i);
                }
            }
            
            // deal with files that may or may not already exist
            using (var oldFile = File.Open("e14p11.txt", FileMode.OpenOrCreate))
            {
                using (var oldStream = new StreamReader(oldFile))
                {
                    var i = 1;
                    while (!oldStream.EndOfStream)
                    {
                        buf = oldStream.ReadLine();
                        CW($"line {i++}: {buf}");
                    }
                }
            }

            // append to an existing file
            using (var oldFile = File.Open("e14p11.txt", FileMode.Append))
            {
                using (var oldStream = new StreamWriter(oldFile))
                {
                    for(var i = 91; i < 127; i++)
                    {
                        oldStream.WriteLine((char) i);
                    }
                }
            }

Part 12

conceptual objective:
- directories

            Action<object> CW = Console.WriteLine;

            // get a list of files from a given directory
            var files = Directory.GetFiles(".");
            var filesInRoot = Directory.GetFiles("/");

            foreach (var f in files)
                CW(f);
            foreach (var f in filesInRoot)
                CW(f);

            // get a list of files from directories stored in an environment  variable
            var env = Environment.GetEnvironmentVariable("PATH");
            var dirList = env.Split(";");
            foreach (var dir in dirList)
            {
                if (string.IsNullOrEmpty(dir))
                    continue;
                try
                {
                    var filesInMyRoot = Directory.GetFiles(dir);

                    foreach (var f in filesInMyRoot)
                        CW(f);
                }
                catch
                {
                    CW($"problem with {dir}");
                    continue;
                }
            }

            // get directories in current directory
            Directory.GetDirectories(".");

            // set default place to look for files to the parent directory of the current default
            Directory.SetCurrentDirectory("..");

            // work with the elements of a file name and its directory path
            var fullPath = Path.GetFullPath("e14p11.txt");
            var ext = Path.GetFileExtension(fullPath);

            // get a list of files to select from  - i've written this to work on your VDI 
            // but that means I can't test it properly.  so modify "/h/" as need be to get it to work...
            var files = Directory.GetFiles("/h/");

            var i = 0;
            foreach(var f in files)
            {
                Console.WriteLine($"{i++} {f}");
            }
            Console.Write($"Pick a file between 0 and {files.Length}:  ");
            var fileSelected = files[int.Parse(Console.ReadLine())];

            Console.WriteLine(fileSelected);
            // read the contents of selected file
            var textInOneGo = File.ReadAllText(fileSelected);

            var lineByLine = File.ReadAllLines(fileSelected);

            // display contents
            Console.WriteLine($"Preview of {fileSelected}:");
            for(var i = 0; i < (10 > lineByLine.Length ? lineByLine.Length : 10); i++)
            {
                Console.WriteLine(lineByLine[i]);
            }
*/

/*

- 
- 
- add this:

     var emptyJsonObjectStr = "{}";
     var emptyJObject = JsonConvert.DeserializeObject(emptyJsonObjectStr);

- if you get NewstonSoft namespace suggested, take it.  If not, then we'll deal with Nuget.

- set a breakpoint on line 2 and step over it
- expand the view in the debugger



part 12 

conceptual objectives:


Part 15

- if you're not working in the Kata.sln solution, 
  add the file "ingredients.json" to your main project
- (I'll explain all this in the session - for now just do it) 
  add the following lines to your program

// this goes at the top, hopefully obviously :-) 

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// this goes in your Main method 
var jsonText = File.ReadAllText("../../../ingredients.json");
var ingredients = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);

- you now have a dictionary with a bunch of ingredients I've set up for use in this exercise
- clear the list of ingredients
- loop thru the dictionary, instantiating the ingredients with calls to your measure function
- now add this line of code and see how much easier it is with Linq

var ingredientList = ingredients.Select(kvp => measure(kvp.Key, kvp.Value)).ToList();

Part 3

- up


Part 2

write a draft interface containing  method signatures for the following:

- create the required measures of an ingdredient to be added to a dish
- create the required measures of a specific ingredient derivatives
- create measured ingredients for a dish
- specify a preparation method for an ingredient
- create measures of types deriving from ingredient
   * make
- 
- create derived ingredients and include them in the ingredient list 
- 
namespace Kata.CustomTypes.RecipeDemoDone
{
    public interface IDraftRecipe
    {
    }
}
*/