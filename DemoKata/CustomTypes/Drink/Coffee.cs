using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.CustomTypes
{
    public enum CoffeeBean {  Java, Mocha, Dubree, Wotsit };
    public class Coffee : DrinkBase
    {
        public CoffeeBean Bean;
        public Coffee()
        {
            Name = "Coffee";
            Price = 4.0M;
            Bean = CoffeeBean.Mocha;
            DrinkType = DrinkType.Coffee;
        }
    }
}
