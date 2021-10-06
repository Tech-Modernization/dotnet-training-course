using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.CustomTypes
{
    public class Tea : DrinkBase
    {
        public Tea()
        {
            Name = "Tea";
            Price = 2.5M;
            DrinkType = DrinkType.Tea;
        }
    }
}
