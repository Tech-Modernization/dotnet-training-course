using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Charades
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
