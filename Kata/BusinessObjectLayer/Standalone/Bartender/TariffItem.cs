namespace BusinessObjectLayer.Bartender
{
    // Responsibility: encapsulate the text reprensentation of a product and its price
    public class TariffItem
    {
        public int DisplayWidth { get; }
        public string Text { get; }
        public decimal Price { get; }
        public TariffItem(string text, decimal price, int displayWidth)
        {
            Text = text;
            Price = price;
            DisplayWidth = displayWidth;
        }

        public override string ToString()
        {
            var leftSide = $"{Text}";
            var rightSide = $"{Price:C}";
            var numDots = DisplayWidth - (leftSide.Length + rightSide.Length);
            var dots = new string('.', numDots);
            return $"{leftSide}{dots}{rightSide}";
        }
    }
}
