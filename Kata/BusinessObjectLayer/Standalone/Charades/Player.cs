namespace BusinessObjectLayer.Charades
{
    public class Player
    {
        public string Name { get; }
        private CharadePlayerRole role;
        public CharadePlayerRole Role => role;
        public Player(string name)
        {
            Name = name;
        }

        public void Toggle()
        {
            role = role == CharadePlayerRole.Guesser ? CharadePlayerRole.Mimer : CharadePlayerRole.Guesser;
        }
    }
}
