using System;
using System.Collections.Generic;
using System.Text;

/*
 * part 1

define an interface IMenu accepting a generic type 
define a method Build()
-- accepting 1 or more instances of the generic type as arguments 
-- returning a list of string to contain the menu options "<menu-index>  <option-text>"

part 2 

define a class Menu that implements IMenu for string 
write a program to instantiate the Menu class, call its Build method and display the options returned.

part 3 

modify the Menu class to accept a generic type and pass it to the interface 

test the build method with int, string and decimal types 

update the build method to format decimals as a price.

part 4

define classes Book, CD and DVD implementing IMedia
add a private field Author to Book,  Artist to CD and Director to DVD 
add a private string Title to all 3.

define an interface IFormatProvider 
IFormatProvider defines a method FormatDetails:
-- accepting  no arguments
-- returning a string with the author/artist/director of the book/cd/dvd and its title

implement FormatDetails in your classes 

test your menu with each of the 3 classes

notice that the name of the type is output cuz Console.WriteLine doesn't know how to format it.

part 5 

update your Build method to use the FormatDetail method in the book, cd and dvd classes to format the option text

part 6

merge the menu options, adjusting the index accordingly 

define an abstract class Media that accepts a generic type and implements IFormatProvider 
have Book, CD and DVD inherit from that class and specify their own type as the generic type specifier for Media

update the program to instantiate a single menu of Media 

update the IMenu interface to include an overload for the build method that accept a list of existing options as a parameter

copy the exsisting build method signature and add an empty method body

add the new parameter to the existing build method signature

in the empty method add a line to return the result of calling the overload, passing in an empty list of string

update the build method to use the incoming list as the option text list and initialise the counter to its length

you can now use the existing calls to the build to extend the menu options instead of having get them all in the same call.


part 7 

but what if the menu needs to establish its options on the fly 
and the objects *don't* conform to some common abstract idea?
i.e. what if they're not media items?

define classes for Hammer, Shoes and FishingTackle all implementing IFormatProvider

change the Menu instance to be of type IFormatProvider

run the menu.build again passing in a random selection of books, hammers etc.

part 8

what if the menu needs to display items that cannot be modified to implement IFormatProvider?

change the menu instance to be of type object and test again.

now remove the implementation of IFormatProvider from the FishingTackle and Shoes definitions.

update the Build method to output a default option text if the incoming object does not implement IFormatProvider

part 9

add an overload for the build method in IMenu that accepts 1 or more "objects"
and also add a parameter to allow a default formatting method to be passed as well.

the syntax you need is:

void Build(Func<object, string> formatDetails, List<string> menuText, params object[] options);

Implement the interface in the Menu class and move the body of the existing Build()
implementation to the new version.  

Reinstate the creation of the list<string> as the return value.  The setting of the option index 
should automagically work cuz you're simulating what you did in part 6.

Modify the Build(List<string> menuText, params object[] options) overload to call the new overload

return Build(null, menuText, options);

test the program - notice that nothing has changed in the results.

part 10 

modify the program to add an implementation for your new anonymous method

menu.Build(option => option.GetType().Name, (continue with the rest of the build parameters as before));

update the build overload with the anonymous parameter to execute the formatDetails anonymous method if it is present.

optionText = formatDetails?(option[i]) ?? $"no default formatter for non-IFormatProvider {option}";

part 11:

make your method provide data that's actually needed.

this is the syntax you'll need:

menu.Build(option => {
if (option is Shoes) return ((Shoes) option).FormatDetails();
if (option is FishingTackle) ((FishingTackle)option).FormatDetails();
return option.GetType().Name;
}, ...(as before));


part 12:

move your anonymous method into a variable for neatness

Func<object, string> formatProvider = option => {
if (option is Shoes) return ((Shoes) option).FormatDetails();
if (option is FishingTackle) ((FishingTackle)option).FormatDetails();
return option.GetType().Name;
}

*/

namespace Kata.Demos.E10Done
{
    public class Exercise10DemoDone : IDemo
    {
        public string Anon(object option)
        {
            // same as: option => option.GetType().Name
            return option.GetType().Name;
        }

        public void Run()
        {
            Func<object, string> formatProvider = (option) => { 
                if (option is Shoes) return ((Shoes)option).FormatDetails();
                if (option is FishingTackle) return ((FishingTackle)option).FormatDetails();
                return option.ToString();
            };

            var menu = new Menu<IFormatProvider>();
            var menuText = menu.Build(new Book("Kipper's Birthday", "Mick Inkpen"),
                new Book("The Dark Side Of The Sun", "Terry Pratchett"));
            menu.Build(menuText,
                new CD("Queen", "Greatest Hits"),
                new CD("Mike Oldfield", "Tubular Bells"));
            menu.Build(formatProvider, menuText,
                new Shoes("Brogues", 12),
                new FishingTackle("Hooks"),
                new Hammer("Claw"),
                new Dog("fido"),
                new PressFactoryDemo(),
                new Exception("Something's gone horribly right!"),
                new string('-', 25)
                );

            Console.WriteLine(string.Join("\n", menuText));
        }
        public void OldRun()
        {

            var intMenu = new Menu<int>();
            var strMenu = new Menu<string>();
            var decMenu = new Menu<decimal>();
            var menuText = strMenu.Build("Cakes", "Buns", "Biscuits");
            Console.WriteLine(string.Join("\n", menuText));
            menuText = intMenu.Build(101, 202, 303, 404, 505);
            Console.WriteLine(string.Join("\n", menuText));
            menuText = decMenu.Build(1.2M, 2.3M, 3.4M, 4.5M, 5.6M);
            Console.WriteLine(string.Join("\n", menuText));

            var bookMenu = new Menu<Book>();
            menuText = bookMenu.Build(new Book("The Stand", "Stephen King"), new Book("Only Forward", "Michael Marshall Smith"));
            Console.WriteLine(string.Join("\n", menuText));
            var cdMenu = new Menu<CD>();
            menuText = cdMenu.Build(
                new CD("Blaze Of Glory", "Joe Jackson"),
                new CD("The Bends", "Radiohead"),
                new CD("Best of (lewis's guilty pleasure)", "Steps"));
            Console.WriteLine(string.Join("\n", menuText));
            var dvdMenu = new Menu<DVD>();
            menuText = dvdMenu.Build(new DVD("Total Recall", "Paul Verhoeven"),
                new DVD("Dead Poet's Society", "Peter Weir"),
                new DVD("Jaws", "Steven Spielberg"));
            Console.WriteLine(string.Join("\n", menuText));

        }

        public interface IMenu<T>
        {
            List<string> Build(params T[] options);
            List<string> Build(List<string> menuText, params object[] options);
            List<string> Build(Func<object, string> formatDetails, List<string> menuText, params object[] options);
        }

        public class Menu<T> : IMenu<T>
        {
            public List<string> Build(Func<object, string> formatDetails, List<string> menuText, params object[] options)
            {
                for (var i = 0; i < options.Length; i++)
                {
                    var menuIndex = menuText.Count + i + 1;
                    var opt = options[i];
                    if (opt is IFormatProvider)
                    {
                        var fp = opt as IFormatProvider;
                        menuText.Add($"{menuIndex,3} {fp.FormatDetails()}");

                        continue;
                    }
                    
                    var optText = formatDetails == null ? $"No default formatter found for non-IFormatProvider {opt}" : formatDetails(opt); 
                    menuText.Add($"{menuIndex,3} {optText}");
                }
                return menuText;
            }

            public List<string> Build(params T[] options)
            {
                return Build(new List<string>(), options);
            }

            public List<string> Build(List<string> menuText, params object[] options)
            {
                return Build(null, menuText, options);
            }
        }

        public interface IFormatProvider
        {
            string FormatDetails();
        }
        public abstract class Media<T> : IFormatProvider
        {
            public abstract string FormatDetails();
        }
        public class Book : Media<Book>
        {
            private string Author;
            private string Title;

            public Book(string title, string author)
            {
                Author = author;
                Title = title;
            }
            public override string FormatDetails()
            {
                return $"{Title} by {Author}";
            }
        }
        public class CD : Media<CD>
        {
            private string Artist;
            private string Title;

            public CD(string title, string artist)
            {
                Artist = artist;
                Title = title;
            }
            public override string FormatDetails()
            {
                return $"{Artist} - {Title}";
            }
        }
        public class DVD : Media<DVD>
        {
            private string Director;
            private string Title;
            public DVD(string title, string director)
            {
                Director = director;
                Title = title;
            }

            public override string FormatDetails()
            {
                return $"{Title} - A {Director} Film";
            }
        }

        public class Hammer
        {
            private string Style;
            public Hammer(string style)
            {
                Style = style;
            }
            public override string ToString()
            {
                return $"{Style} hammer";
            }
        }
        public class Shoes 
        {
            private string style;
            private int size;
            public Shoes(string style, int size)
            {
                this.style = style;
                this.size = size;
            }
            public string FormatDetails()
            {
                return $"{style} shoes - size {size}";
            }
        }
        public class FishingTackle 
        {
            private string tackle;
            public FishingTackle(string tackle)
            {
                this.tackle = tackle;
            }
            public string FormatDetails()
            {
                return $"Fishing tackle - {tackle}";
            }
        }
    }
}
