using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static Kata.Demos.E10Done.Exercise10DemoDone;

namespace Kata.Demos.E10Done
{
    public class Exercise10DemoDone : DemoBase
    {
        public override void Run()
        {
            AddPart(Part1, "Simple type generic menu");
            AddPart(Part2, "Book menu");
            AddPart(Part3, "Mixed media menu");
            AddPart(Part4, "IFormatProvider menu");
            AddPart(Part5, "IFormatProvider menu with custom provider");
            base.Run();
        }
        public void Part1()
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
              }
        public void Part2()
        {      var menu = new Menu<Book>();
            var menuText = menu.Build(new Book("Kipper's Birthday", "Mick Inkpen"),
                new Book("The Dark Side Of The Sun", "Terry Pratchett"));
            Console.WriteLine(string.Join("\n", menuText));

    
        }
        public void Part3()
        {
            var menu = new Menu<Media>();
            var menuText = menu.Build(
                new CD("Queen", "Greatest Hits"),
                new CD("Mike Oldfield", "Tubular Bells"));
            menuText = menu.Build(menuText, new DVD("Dances With Wolves", "Kevin Costner"), new DVD("Leon", "Luc Besson"));
            Console.WriteLine(string.Join("\n", menuText));
        }
        public void Part4()
        {
            var menu = new Menu<IFormatProvider>();
            var menuText = menu.Build(
                new CD("Queen", "Greatest Hits"),
                new CD("Mike Oldfield", "Tubular Bells"),
                new Hammer("Claw"), new Shoes("Brogues", 12),
                new DVD("Dances With Wolves", "Kevin Costner"), new DVD("Leon", "Luc Besson"));
     
            Console.WriteLine(string.Join("\n", menuText));

        }
        public void Part5()
        {

            var menu = new Menu<IFormatProvider>();
            var menuText = menu.Build<Exception>(e => e.Message,
                 new Exception("Something's gone horribly right!"));
            menuText = menu.Build<Bicycle>(b => $"{b.Model} bike", new Bicycle("Mountain"), new Bicycle("Hybrid"));
            menuText = menu.Build<Detergent>(d => $"Detergent {d.Brand}", new Detergent("Daz"), new Detergent("The Leading Brand"));
            menuText = menu.Build<decimal>(d => $"{d:C}", 123.45M);
            Console.WriteLine(string.Join("\n", menuText));


        }


        public interface IMenu<T>
        {
            List<string> Build(params T[] options);
            List<string> Build(List<string> menuText, params T[] options);
            List<string> Build<T2>(Func<T2, string> formatter, params T2[] options);
        }

        public class MenuOption<T> : IFormatProvider
        {
            public T Item;
            public Func<T, string> Format;

            public string FormatDetails()
            {
                var option = Item as IFormatProvider;
                return option?.FormatDetails() ?? Format(Item);
            }

            public override string ToString()
            {
                return Item.GetType().Name;
            }
        }

        public class Menu<T1> : IMenu<T1>
        {
            private List<IFormatProvider> items = new List<IFormatProvider>();
            public List<string> Build(params T1[] options)
            {
                return Build(new List<string>(), options);
            }
            public List<string> Build(List<string> existingOptionsText, params T1[] options)
            {
                return Build(n=> null, options);
            }
            public List<string> Build<T2>(Func<T2, string> formatter, params T2[] options)
            {
                for (var i = 0; i < options.Length; i++)
                {
                    var opt = options[i] as IFormatProvider;
                    if (formatter == null && opt == null)
                    {
                        items.Add(new MenuOption<object>()
                        {
                            Item = options[i],
                            Format = (o) => $"{o}"
                        });
                        continue;
                    }

                    items.Add(new MenuOption<T2>() { Item = options[i], Format = formatter });
                }
                items.Sort((x, y) =>
                {
                    var result = string.Compare(x.ToString(), y.ToString());
                    var typesEqual = result == 0;
                    return typesEqual ? string.Compare(x.FormatDetails(), y.FormatDetails()) : result;
                });

                var menuText = new List<string>();
                var curGroupName = string.Empty;
                for(var i = 0; i < items.Count; i++)
                {
                    var groupName = items[i].ToString();
                    var announceGroup = i == 0 || groupName != curGroupName;
                    menuText.Add($"{(announceGroup ? $"{groupName}\n" : "")}    {i + 1,3} {items[i].FormatDetails()}");
                    if (announceGroup) curGroupName = groupName;
                }
          /*
          items.GroupBy(item => item.ToString())
                    .ToList()
                    .ForEach(grouping => {
                        menuText.Add(grouping.Key);
                        grouping.ToList()
                        .ForEach(groupItem => menuText.Add($"    {items.IndexOf(groupItem) + 1,3} {groupItem.FormatDetails()}"));
                    });
                return menuText;
          */
                return items.Select(item => $"{items.IndexOf(item) + 1,3} {item} : {item.FormatDetails()}").ToList();
            }
        }

        public interface IFormatProvider
        {
            string FormatDetails();
        }
        public abstract class Media : IFormatProvider
        {
            protected Media(string title)
            {
                Title = title;
            }
            protected string Title { get; }
            public abstract string FormatDetails();
        }

        public class Book : Media
        {
            protected string Author;
            public Book( string title, string author) : base(title)
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
            protected string Style { get; }
            public Hammer(string style)
            {
                Style = style;
            }
            public string FormatDetails()
            {
                return $"{Style} hammer";
            }
        }
        public class Shoes : IFormatProvider
        {
            protected string Style { get; }
            public int Size { get; }
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
    }
}
