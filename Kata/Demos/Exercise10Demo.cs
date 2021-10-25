using System;
using System.Collections.Generic;
using System.Text;


namespace Kata.Demos
{
    public class Exercise10Demo : IDemo
    {
        public void Run()
        {
            var menu = new Menu<object>();

            var menuText = menu.Build(new Book("Michael Marshall smith", "Only Forward"), new CD("Joe Jackson", "Blaze of Glory"),
                new DVD("The Tudor Monastery Farm", "Ruth Goodman"),
                new Hammer("Claw"), new Shoes("Brogues", 11), new FishingTackle("Hooks"));
            Console.WriteLine(string.Join("\n", menuText));
        }
        public void RunParts1To3()
        {
            var intMenu = new Menu<int>();
            var menuText = intMenu.Build(1, 2, 3);
            Console.WriteLine(string.Join("\n", menuText));
            var strMenu = new Menu<string>();
            menuText = strMenu.Build("one", "two", "three");
            Console.WriteLine(string.Join("\n", menuText));
            var decMenu = new Menu<decimal>();
            menuText = decMenu.Build(1.1M, 2.2M, 3.3M);
            Console.WriteLine(string.Join("\n", menuText));

        }
    }

    public interface IMenu<T>
    {
        List<string> Build(params T[] options);
    }

    public interface IFormatProvider
    {
        string FormatDetails();
    }

    public class Menu<T> : IMenu<T>
    {
        public List<string> Build(params T[] options)
        {
            var optionText = new List<string>();
            for (var i = 0; i < options.Length; i++)
            {
                var opt = options[i] as IFormatProvider;
                var optionString = (opt is IFormatProvider) ? opt.FormatDetails() : options[i].ToString();
                optionText.Add($"{i + 1,3} {optionString}");
            }
            return optionText;
        }
    }

    public class Book : IFormatProvider
    {
        private string Author;
        private string Title;

        public Book(string author, string title)
        {
            Author = author;
            Title = title;
        }

        public string FormatDetails()
        {
            return $"{Title} by {Author}";
        }
    }

    public class CD : IFormatProvider
    {
        private string Artist;
        private string Title;

        public CD(string artist, string title)
        {
            Artist = artist;
            Title = title;
        }

        public string FormatDetails()
        {
            return $"{Artist} - {Title}";
        }
    }
    public class DVD : IFormatProvider
    {
        private string Director;
        private string Title;
        public DVD(string title, string director)
        {
            Director = director;
            Title = title;
        }
        public string FormatDetails()
        {
            return $"{Title} - A {Director} film";
        }
    }

    public class Hammer : IFormatProvider
    {
        private string Style;

        public Hammer(string style)
        {
            Style = style;
        }

        public string FormatDetails()
        {
            return $"{Style} hammer";
        }
    }
    public class Shoes 
    {
        private string Style;
        private int Size;

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
    public class FishingTackle
    {
        private string Style;

        public FishingTackle(string style)
        {
            Style = style;
        }

        public string FormatDetails()
        {
            return $"Fishing tackle : {Style}";
        }
    }
}