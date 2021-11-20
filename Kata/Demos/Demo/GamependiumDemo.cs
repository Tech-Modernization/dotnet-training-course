using System;

using Kata.CustomTypes.Demo.Gamependium;
using Kata.Helpers;

namespace Kata.Demos
{
    public class GamependiumDemo : DemoBase
    {
        public override void Run()
        {
            var menu = new MenuHelper();
            menu.Build(
                () => MenuHelper.GetTypedMenuItems(TypeHelper.ChildrenOf<GameBase>()), 
                t => GameLobby(t));

            var sel = menu.SelectFromMenu("Choose your game: ");
        }

        public void GameLobby(Type t)
        {
            var game = new DraughtsGame();
            game.Display();
        }
    }
}
