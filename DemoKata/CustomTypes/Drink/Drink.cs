namespace DemoKata.CustomTypes
{
    /*
     * display a menu
     * - we need the items in it
     * -- drinks - check
     * ---type of drinks - check
     * 
     * this task is all about defining the drinks
     * 
     * select from it
     * - we need a list of the items
     * this one is about the menu
     * 
     * - we need to link the choice to an item in the list
     * this is where need the concept of an order
     * 
     * summarise selection
     * - we need to calculate the total of all the prices 
     * - we need to output it.
     */
    public class Drink : IDrink
    {
        public string Name;
        public decimal Price;
        public DrinkType DrinkType;

        public string GetMenuText(ref int menuIndex)
        {
            return $"{menuIndex++,3} {Name,-10} {Price:C} {getSuffix()}";
        }

        private string getSuffix()
        {
            if (this is Coffee)
            {
                var coffeeAs = this as Coffee;
                return $"({coffeeAs.Bean})";
            }

            return string.Empty;
        }
    }
}