namespace Kata.CustomTypes.OnlineShop.Part6
{
    public class Product
    {
        public string Name;
        public decimal Price;

        public override string ToString()
        {
            var price = $"{Price:C}";
            return $"{Name,-20}{price:10}";
        }
    }
}