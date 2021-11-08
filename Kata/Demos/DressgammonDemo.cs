using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.DressgammonFactory;
using Kata.Demos;

namespace Kata.Demos
{
    public class DressgammonDemo : DemoBase
    {
        public override void Run()
        {
            var game = new DraughtsGame();
            game.Display();

            var bgame = new BackgammonGame();
            bgame.Display();
        }
    }
}
