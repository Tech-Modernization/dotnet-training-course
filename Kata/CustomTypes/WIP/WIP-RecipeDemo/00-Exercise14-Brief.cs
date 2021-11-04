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
- encapsulate the functionality ot prepare an ingredient
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

objectives:
- practice class-level generics 
- practive anonymous methods
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

objectives:
- introduce generic type constraints
- make of the design 
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

- create a class DishBase that inherits from List<Ingredient>
- create a class Recipe accepting a generic type 

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