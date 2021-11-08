using System;
using System.Collections.Generic;
using System.Text;
namespace Kata.CustomTypes.DressgammonFactory
{
    public abstract class GameBase
    {
        protected List<PieceSetBase> Sets { get; }

        protected IGameBoard Board { get; set; }
        public GameBase()
        {
            Sets = new List<PieceSetBase>();
            CreatePieceSets();
            CreateBoard();
        }
        protected abstract void CreatePieceSets();
        protected abstract void CreateBoard();

        public virtual void Display(bool reset = false)
        {
            if (reset)
            {
                Board.Reset();
            }

            Console.WriteLine(Board);
        }
    }
}
