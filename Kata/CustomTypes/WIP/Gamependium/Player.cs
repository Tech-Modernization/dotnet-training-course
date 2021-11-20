using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class Player
    {
        protected string Name { get; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
