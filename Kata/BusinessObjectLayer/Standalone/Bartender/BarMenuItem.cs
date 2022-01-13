namespace BusinessObjectLayer.Bartender
{
    public class BarMenuItem : MenuItem
    {
        public Drink Drink { get; }
        public BarMenuItem(string text, decimal price, Drink drink) : base(text, price)
        {
            Drink = drink;
        }

    }
}