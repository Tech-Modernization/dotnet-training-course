using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.Gamependium
{
    public class GamePlayService : IGamePlayService
    {
        private ITurnTaker turnTaker;
        private IResetter gameBoard;

        public GamePlayService(ITurnTaker turnTaker, IResetter gameReset, IViewer board)
        {
            this.turnTaker = turnTaker;
            this.gameBoard = gameBoard;
        }

        public GameResultBase Play(Player playerOne = null, Player playerTwo = null)
        {
            throw new NotImplementedException();
        }
    }
}
