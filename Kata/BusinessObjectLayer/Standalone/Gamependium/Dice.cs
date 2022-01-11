using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Gamependium
{
    public class Dice
    {
        private Random shaker;
        private int numDice;
        public Dice(int numDice)
        {
            shaker = new Random();
            this.numDice = numDice;
        }
        public int Throw()
        {
            return Throw(numDice);
        }
        public int Throw(int throwCubes)
        {
            var throwValue = 0;
            for(var i = throwCubes; i > 0; i++)
            {
                throwValue += shaker.Next(1, 6);
            }
            return throwValue;
        }
    }
}
