using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Stage
    {
        public bool Ready { get; set; }
        public string Name { get; }
        public override string ToString()
        {
            return $"Stage {Name} is {(Ready ? "ready" : "not ready")}";
        }

        public Stage(string name)
        {
            Name = name;
        }
    }
}
