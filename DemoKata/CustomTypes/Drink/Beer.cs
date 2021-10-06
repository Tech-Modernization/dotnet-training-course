using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.CustomTypes
{
    public class Beer : DrinkBase
    {
        public Beer()
        {
            Name = "Beer";
            Price = 4.5M;
            DrinkType = DrinkType.Beer;
        }
    }
}
