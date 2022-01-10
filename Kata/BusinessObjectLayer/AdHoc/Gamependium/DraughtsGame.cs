namespace Kata.CustomTypes.Gamependium
{
    public class DraughtsGame : GameBase
    {
        public DraughtsGame(IPlayerService playerService) : base(playerService)
        {
        }

        protected override void CreatePieceSets()
        {
            Sets.Add(new DraughtsPieceSet(PieceColour.White));
            Sets.Add(new DraughtsPieceSet(PieceColour.Black));
        }

        protected override void CreateBoard()
        {
            Board = new DraughtsBoard();
            Board.Initialise(Sets);
            Board.Reset();
        }
    }
}
