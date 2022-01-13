namespace Helpers
{
    public class MenuSelectionItem
    {
        public int Index { get; }
        public string Text { get; }
        public int Quantity { get; }
        public MenuSelectionItem(int index, string text, int quantity)
        {
            Index = index;
            Text = text;
            Quantity = quantity;
        }
    }
}