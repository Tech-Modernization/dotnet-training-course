using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Kata.CustomTypes.MenuFactory;

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

define classes Book, CD and DVD
add a private field Author to Book,  Artist to CD and Director to DVD 
add a private string Title to all 3.

test your menu with each of the 3 classes

notice that the name of the type is output cuz Console.WriteLine doesn't know how to format it.

part 5 

define an interface IFormatProvider 
IFormatProvider defines a method FormatDetails:
-- accepting  no arguments
-- returning a string with the author/artist/director of the book/cd/dvd and its title

implement FormatDetails in your classes 

update your Build method to use the FormatDetail method in the book, cd and dvd classes to format the option text

part 6

merge the menu options, adjusting the index accordingly 

define an abstract class Media and implements IFormatProvider 
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

define classes Hammer and Shoes both implementing IFormatProvider

change the Menu instance to be of type IFormatProvider

run the menu.build again passing in a random selection of books, hammers etc.

part 8

what if the menu needs to display items that cannot be modified to implement IFormatProvider?

define classes Bicycle and Detergent with public string properties Model and Brand

add another overload for the build method but make this accept a different generic type 
from the interface and specify its params of that type


implement this method in the menu class and add a couple of bikes and brands of detergent.
*/
/*
part 9

so how do we get at the Model and Brand properties to format our menu options without
the unscalable solution of specific type checking?

anonymous methods.  (for now - there's a design pattern that's even better for this, but one
thing at a time) 

add a parameter to the new overload that IS an anonymous method that accepts an object and returns a string.

update the implementation in the menu class

test the program - notice that nothing has changed in the results.

part 10 

now make the anonymous method accept the generic type so you can provide individual solutions for each class.

modify the program to add an implementation for your new anonymous method

part 11:

you realise as the list of things grows that this menu is going to be hard to read, 
so the items need to be sorted in alphabetical order.  

given how the option numbers are generated progressively as you add more items, it'll 
be a fiddly and inefficient job to sort the items based on the generated text.

so you decide to store the objects that are passed into the build method, sort them
and regenerate the whole menu on each build.

add a private list of IFormatProvider to your menu and add your incoming objects to it.

part 12:

but what about the custom formatting?

create a new class MenuOption<T> and let it contain a public property of the type T and an anonymous method definition.
let it implement formatprovider and have FormatDetails call FormatDetails on the Item if it has it or else the custom formatter.

part 13: 

sort the menu before returning - it's getting messy.

part 14: (this one's for you guys...)

group like objects in your sort 
name the groups after their type 
output the group names and indent the items


*/

namespace Kata.Demos
{
    public class Exercise10Demo : DemoBase
    {
        private List<object> objetsDuh = new List<object>()
        {
            new DVD("Kevin Costner", "Dances With Wolves"),
            new DVD("Luc Besson", "Leon"),
            new CD("Prince", "Purple Rain"),
            new CD("Led zeppelin", "IV"),
            new Hammer("Claw"),
            new Shoes("Brogues", 12),
            new Hammer("Sledge"),
            new Shoes("Pumps", 7),
            new Bicycle("Mountain"),
            new Detergent("Daz"),
            new Detergent("Ariel"),
            new ThermalTrousers("Red", "Large"),
            new ThermalTrousers("Yellow", "Small"),
            new Knife("Hunting", "12\""),
            new Knife("Butter", "4 inches")
        };

        public void RunE12to13()
        {
            var multiplier = new Multiplier();
            multiplier.Multiply(22, 4);
            multiplier.Multiply(2.2M, 5);
            multiplier.Multiply("22", 7);
            multiplier.Multiply(new Hammer("Claw"), 5);
            multiplier.Multiply(new Shoes("Docs", 10), 8);


            var intRef = new CrossRef<int>(1, 2, 3, 6, 77, 54, 56, 567, 4, 64);
            Console.WriteLine($"intRef {(intRef.Find(66) ? "contains" : "does not contain")} 66");
            Console.WriteLine($"intRef {(intRef.Find(77) ? "contains" : "does not contain")} 77");

            var decRef = new CrossRef<decimal>(1.1M, 2.2M, 3.3M, 4.4M);
            Console.WriteLine($"decRef {(decRef.Find(2.2M) ? "contains" : "does not contain")} 2.2");
            Console.WriteLine($"decRef {(decRef.Find(22.22M) ? "contains" : "does not contain")} 22.22");

            var invited = new CrossRef<string>("alan", "dave", "steve", "petunia", "sally", "jenny", "milos", "sheherezade");
            var replied = new CrossRef<string>("alan", "dave", "sally", "milos", "sheherezade");

            do
            {
                Console.Write("Who's coming? : ");
                var who = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(who)) break;

                var wasInvited = invited.Find(who);
                var hasReplied = replied.Find(who);
                var message = $"{who} was {(wasInvited ? "" : "not ")}invited";
                var rsvpMessage = wasInvited ? $" {(hasReplied ? "and has RSVP'd" : "but has not yet RSVP'd")}" : "";
                Console.WriteLine($"{message}{rsvpMessage}");
            }
            while (true);

            var rsvp = new RSVP("alan", "dave", "steve", "petunia", "sally", "jenny", "milos", "sheherezade");
            do
            {
                Console.Write("Who's coming? : ");
                var who = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(who)) break;

                var inviteState = rsvp.WillBeAttending(who);
                var invitedMessage = $"{who} was {(inviteState.HasValue ? "not " : "")}invited";
                var rsvpMessage = inviteState.HasValue
                    ? $"{(inviteState.Value ? $"YAY!  {who}'s coming to your party!" : $"{who} sends their apologies")}"
                    : invitedMessage;

                Console.WriteLine(inviteState.HasValue ? rsvpMessage : invitedMessage);

                bool wasInvited;
                inviteState = rsvp.WillBeAttending(who, out wasInvited);
                invitedMessage = $"{who} was {(wasInvited ? "" : "not ")}invited";
                rsvpMessage = inviteState.HasValue
                    ? $"{(inviteState.Value ? $"YAY!  {who}'s coming to your party!" : $"{who} sends their apologies")}"
                    : $"{who} has not sent an RSVP";

                Console.WriteLine(wasInvited ? rsvpMessage : invitedMessage);
            }
            while (true);

            var brandx = new CrossRef<string>("phil collins", "bill bruford");
            brandx.Band = "Brand X";
            var yes = new CrossRef<string>("bill bruford", "alan white");
            yes.Band = "Yes";
            var genesis = new CrossRef<string>("phil collins", "chester thompson");
            genesis.Band = "Genesis";
            var drummers = new List<string>() { "phil collins", "chester thompson", "alan white", "bill bruford" };
            var bands = new List<CrossRef<string>>() { brandx, yes, genesis };
            foreach (var d in drummers)
            {
                foreach (var b in bands)
                {
                    Console.WriteLine($"{d} did {(b.Find(d) ? "" : "not")} play drums in {b.Band}");
                }
            }
        }
        int addNamed(int n1, int n2)
        {
            return n1 + n2;
        }

        string nameNamed()
        {
            return "paul";
        }

        void wossTheTimeNamed()
        {
            Console.WriteLine("Date: {0}", DateTime.Now.ToLongDateString());
            Console.WriteLine("Time: {0}", DateTime.Now.ToLongTimeString());
        }

        public void AnonPart1()
        {
            Func<int, int, int> addAnon = (n1, n2) => n1 + n2;

            var namedResult = addNamed(3, 4);
            var anonResult = addAnon(3, 4);

            Func<string> nameAnon = () => "paul";
            var namedName = nameNamed();
            var anonName = nameAnon();

            Action wossTheTimeAnon = () =>
            {
                Console.WriteLine("Date: {0}", DateTime.Now.ToLongDateString());
                Console.WriteLine("Time: {0}", DateTime.Now.ToLongTimeString());
            };

            wossTheTimeNamed();
            wossTheTimeAnon();

            Console.WriteLine(Call(new Bicycle("Mountain bike")));

            var bike = new Bicycle("mountain bike");

            var formatResult = CallFormatter(o => $"Hip hooray, I've got a new {((Bicycle) o).Model}", bike);
            formatResult = CallFormatter(o => $"How dull.  Just been to Tesco's and got  {((Detergent) o).Brand}", new Detergent("Ariel"));

            Console.WriteLine(formatResult);

        }

        public void Run()
        {
            
            Action<int, string> myMethod = (arg, anotherArg) => Console.WriteLine($"the answer to {anotherArg} is {arg}");
            myMethod(42, "life the universe and everything");

            Func<DateTime, int> howOld = (birthday) => (int) DateTime.Now.Subtract(birthday).TotalDays / 365;
            Console.WriteLine($"Dave was born on 9 April 1968 so he is {HowOld(DateTime.Parse("9/4/1968"))} years old");
            Console.WriteLine($"James Dean was born on 8th February 1922 so he would be {howOld(DateTime.Parse("8/2/1922"))} years old");


            var egg = new Egg();
            egg.Prepare();
            egg.Prepare(() => Console.WriteLine("Beating the egg"));

        }

        public interface IPrepare
        {
            void Prepare(Action altPrep = null);
        }
        public class Egg : IPrepare
        {
            public void Prepare(Action altPrep = null)
            {
                if (altPrep == null)
                    Console.WriteLine("Frying the egg");
                else
                    altPrep();
            }
        }

        int HowOld(DateTime birthday) 
        { 
            return (int) DateTime.Now.Subtract(birthday).TotalDays / 365; 
        }

        public string CallFormatter<T>(Func<object, string> methodParam, T arg)
        {
            return methodParam(arg);
        }

        public string Call<T>(T arg)
        {
            var bike = arg as Bicycle;
            return (bike == null) ? $"not supporting {typeof(T).Name}" : $"called with a {bike.Model}";
        }

        public void RunBuild()
        {
            var menu = new Menu<IFormatProvider>();
            var menuText = menu.Build(
                new Book("Emily Bronte", "Wuthering Heights"),
                new Book("Charles Dickens", "Hard Times"));

            menuText = menu.Build(menuText,
                new CD("Prince", "Purple Rain"),
                new CD("Led zeppelin", "IV"));

            menuText = menu.Build(menuText,
                new Book("William Burroughs", "Naked Lunch"));

            menuText = menu.Build(menuText,
                new DVD("Kevin Costner", "Dances With Wolves"),
                new DVD("Luc Besson", "Leon"));

            menuText = menu.Build(menuText,
                new Hammer("Claw"), new Shoes("Brogues", 12), new Hammer("Sledge"), new Shoes("Pumps", 7));


            menuText = menu.Build(option => $"second hand bike: {((Bicycle) option).Model}",
                menuText, 
                new Bicycle("Mountain"), new Bicycle("Hybrid"));

              menuText = menu.Build(option => $"laundry powdeR: {((Detergent) option).Brand}",
                  menuText, new Detergent("Ariel"), new Detergent("Uberweiss"));

              menuText = menu.Build(null, menuText, new FlyingFish("percy"));

            Console.WriteLine(string.Join("\n", menuText));
        }

        static string anonFormatter(object o)
        {
            var bike = o as Bicycle;
            var deterg = o as Detergent;
            return bike?.Model ?? deterg?.Brand ?? "type not supported";
        }

        public void RunParts4To5()
        {
            var bookMenu = new Menu<Book>();
            var menuText = bookMenu.Build(
                new Book("Emily Bronte", "Wuthering Heights"),
                new Book("Charles Dickens", "Hard Times"));
            Console.WriteLine(string.Join("\n", menuText));

            var decMenu = new Menu<decimal>();
            menuText = decMenu.Build(1.5M, 2.6M, 3.7M);
            Console.WriteLine(string.Join("\n", menuText));

            var cdMenu = new Menu<CD>();
            menuText = cdMenu.Build(
                new CD("Prince", "Purple Rain"),
                new CD("Led zeppelin", "IV"));
            Console.WriteLine(string.Join("\n", menuText));
            var dvdMenu = new Menu<DVD>();
            menuText = dvdMenu.Build(
                new DVD("Kevin Costner", "Dances With Wolves"),
                new DVD("Luc Besson", "Leon"));
            Console.WriteLine(string.Join("\n", menuText));
        }

        public void RunPart1To3()
        {
            var intMenu = new Menu<int>();
            var strMenu = new Menu<string>();
            var decMenu = new Menu<decimal>();

            var menuText = intMenu.Build(22, 33, 44);
            Console.WriteLine(string.Join("\n", menuText));
            menuText = strMenu.Build("tom", "dick", "harry");
            Console.WriteLine(string.Join("\n", menuText));
            menuText = decMenu.Build(1.5M, 2.6M, 3.7M);
            Console.WriteLine(string.Join("\n", menuText));
        }

        public void RunTypeFormatter()
        {
            var menuTypeFormatter = new TypeNameFormatter<MenuBase>();
            var factoryTypeFormatter = new TypeNameFormatter<MenuItemBase>();

            var upperMenuBase = menuTypeFormatter.UpperCaseTypeName();
            var pathMenuBase = menuTypeFormatter.MakePathFromTypeName();
            var upperFactoryDemoBase = factoryTypeFormatter.UpperCaseTypeName();
            var pathFactoryDemoBase = factoryTypeFormatter.MakePathFromTypeName();

            var drinksUpper = menuTypeFormatter.UpperCaseTypeName<DrinksMenu>();
            var drinksPath = menuTypeFormatter.MakePathFromTypeName<DrinksMenu>();



        }

        public object GetRandomObject()
        {
            var randIdx = new Random().Next(0, objetsDuh.Count - 1);
            return objetsDuh[randIdx];
        }
    }

    public interface IMenu<TMainMenuType>
    {
        List<string> Build(params TMainMenuType[] options);
        List<string> Build(List<string> existingOptions, params TMainMenuType[] options);
    }

    public interface IFlexibleMenu
    {
        List<string> Build<TAnyType>(Func<object, string> formatter, List<string> existingOptions, params TAnyType[] options);
    }

    public interface IFormatProvider
    {
        string FormatDetails();
    }

    public class TypeNameFormatter<T>
    {
        public string UpperCaseTypeName()
        {
            return typeof(T).FullName.ToUpper();
        }

        public string MakePathFromTypeName()
        {
            return typeof(T).FullName.Replace(".", "/");
        }

        public string UpperCaseTypeName<T2>()
        {
            return typeof(T2).FullName.ToUpper();
        }

        public string MakePathFromTypeName<T2>()
        {
            return typeof(T2).FullName.Replace(".", "/");
        }
    }



    public class Menu<T> : IMenu<T>, IFlexibleMenu
    {
        public List<string> Build(params T[] options)
        {
            return Build(new List<string>(), options);
        }
        public List<string> Build(List<string> existingOptions, params T[] options)
        {
            return Build<T>(null, existingOptions, options);
        }

        public List<string> Build<TAnyType>(Func<object, string> formatter, List<string> existingOptions, params TAnyType[] options)
        {
            var menuText = existingOptions;
            var savedLength = existingOptions.Count;
            for (var i = 0; i < options.Length; i++)
            {
                var optionText = $"The menu does not support the {options[i].GetType().Name} type";
                var option = options[i] as IFormatProvider;
                if (option != null)
                {
                    optionText = option.FormatDetails();
                }
                else if (formatter != null)
                {
                    optionText = formatter(options[i]);
                }

                var optionIndex = i + savedLength + 1;
                menuText.Add($"{optionIndex,3} {optionText}");
            }

            return menuText;
        }
    }

    public abstract class Media : IFormatProvider
    {
        protected string Title;
        protected Media(string title)
        {
            Title = title;
        }
        public abstract string FormatDetails();
    }
    public class Book : Media
    {
        protected string Author;
        public Book(string author, string title) : base(title)
        {
            Author = author;
        }
        public override string FormatDetails()
        {
            return $"{Title} by {Author}";
        }
    }

    public class CD : Media
    {
        protected string Artist;
        public CD(string artist, string title) : base(title)
        {
            Artist = artist;
        }
        public override string FormatDetails()
        {
            return $"{Artist} - {Title}";
        }
    }

    public class DVD : Media
    {
        protected string Director;
        public DVD(string title, string director) : base(title)
        {
            Director = director;
        }
        public override string FormatDetails()
        {
            return $"{Title} - A {Director} film";
        }
    }

    public class Hammer : IFormatProvider
    {
        protected string HammerType;

        public Hammer(string hammerType)
        {
            HammerType = hammerType;
        }

        public string FormatDetails()
        {
            return $"{HammerType} hammer";
        }
    }

    public class Shoes : IFormatProvider
    {
        protected string Style;
        protected int Size;

        public Shoes(string style, int size)
        {
            Style = style;
            Size = size;
        }

        public string FormatDetails()
        {
            return $"{Style} shoes - size {Size}";
        }
    }

    public class Bicycle
    {
        public Bicycle(string model)
        {
            Model = model;
        }

        public string Model { get; }
    }

    public class Detergent
    {
        public Detergent(string brand)
        {
            Brand = brand;
        }

        public string Brand { get; }
    }

    public class ThermalTrousers
    {
        public string Colour;
        public string Size;

        public ThermalTrousers(string colour, string size)
        {
            Colour = colour;
            Size = size;
        }
    }

    public class Knife
    {
        public string Use;
        public string Length;

        public Knife(string use, string length)
        {
            Use = use;
            Length = length;
        }
    }

    public class Multiplier
    {
        public void Multiply<T>(T arg, int multiplier)
        {
            if (arg is int)
            {
                multiplyNumber(Convert.ToInt32(arg), multiplier);
                return;
            }
            if (arg is decimal)
            {
                multiplyNumber(Convert.ToDecimal(arg), multiplier);
                return;
            }

            var str = arg as string;
            if (!string.IsNullOrEmpty(str))
            {
                multiplyString(str, multiplier);
                return;
            }
            var hammer = arg as Hammer;
            if (hammer != null)
            {
                multiplyHammer(hammer, multiplier);
                return;
            }

            Console.WriteLine($"Sorry.  Multiplier does not support the {typeof(T).FullName} type");
        }


        private void multiplyHammer(Hammer hammer, int multiplier)
        {
            var list = new List<Hammer>();
            var hammerStr = hammer.FormatDetails();
            for(var i = 0; i < multiplier; i++)
            {
                list.Add(new Hammer($"{hammerStr} #{i + 1} of {multiplier}"));
            }

            foreach(var h in list)
            Console.WriteLine(h.FormatDetails());
        }

        private void multiplyString(string str, int multiplier)
        {
            for (var i = 1; i < multiplier; i++)
            {
                Console.WriteLine($"{i}: {str}");
            }
        }

        private void multiplyNumber(int arg, int multiplier)
        {
            Console.WriteLine($"{multiplier} x {arg} = {multiplier * arg}");
        }
        private void multiplyNumber(decimal arg, int multiplier)
        {
            Console.WriteLine($"{multiplier} x {arg} = {multiplier * arg}");
        }
    }

    public class CrossRef<T>
    {
        private List<T> items;
        public string Band;
        public CrossRef(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool Find(T item)
        {
            return items.Contains(item);
        }
    }

    public class RSVP : CrossRef<string>
    {
        private Dictionary<string, bool> responses = new Dictionary<string, bool>();

        public RSVP(params string[] names) : base(names)
        {
            foreach(var n in names)
            {
                if (n[0] % 2 == 1)
                {
                    Console.WriteLine($"Adding response from {n}");
                    responses.TryAdd(n, n.ToCharArray().Sum(c => c) % 2 == 0);
                    Console.WriteLine($"{n}'s {(responses[n] ? "" : "not ")} coming");
                }
            }
        }

        public bool? WillBeAttending(string name)
        {
            return responses.ContainsKey(name) ? responses[name] : false;
        }
        public bool? WillBeAttending(string name, out bool invited)
        {
            invited = Find(name);
            bool? retval = null;
            return invited ? responses.ContainsKey(name) ? responses[name] : retval : false;
        }
    }
}
