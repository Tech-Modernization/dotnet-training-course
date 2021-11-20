using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Demo.Recipe.Part10
{
    public class Stage
    {
        public string Name { get; }
        public bool Ready { get; }
        public Stage(string name, bool ready)
        {
            Name = name;
            Ready = ready;
        }

        public override string ToString()
        {
            return $"The {Name} is {(Ready ? "" : "not")}ready";
        }
    }
}
