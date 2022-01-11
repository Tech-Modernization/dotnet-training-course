using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Gamependium
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
