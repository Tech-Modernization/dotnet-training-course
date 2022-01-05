using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Charades
{
    public class Clue
    {
        public string Title { get; }
        public Category Category { get; }
        public Clue(string title, Category category)
        {
            Title = title;
            Category = category;
        }
    }
}
