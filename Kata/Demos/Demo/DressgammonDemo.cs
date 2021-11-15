using System;
using System.Collections.Generic;
using System.Text;

using Kata.CustomTypes.DressgammonFactory;
using Kata.Helpers;

namespace Kata.Demos
{
    public class DressgammonDemo : DemoBase
    {
        public override void Run()
        {
            var menu = new MenuHelper();
            menu.Init(() => TypeHelper.ChildrenOf<GameBase>());

            var sel = menu.SelectFromMenu("Choose your game: ");
            var game = default(GameBase);

            switch (sel)
            {
                case 1:
                    game = new BackgammonGame();
                    break;
                case 2:
                    game = new ChessGame();
                    break;
                case 3:
                    game = new DraughtsGame();
                    break;
                default:
                    return;
            }
            game.Display();
        }
    }
}
