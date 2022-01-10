using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Charades
{
    public class Player
    {
        public string Name { get; }
        public CharadePlayerRole Role { get; }
        public Player(string name)
        {
            Name = name;
        }
    }
}
