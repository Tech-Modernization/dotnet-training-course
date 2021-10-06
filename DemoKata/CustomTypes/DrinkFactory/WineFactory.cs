namespace DemoKata.CustomTypes
{
    public class WineFactory : DrinkFactory
    {
        protected override void CreateVariants()
        {
            Variants.Add(new Wine("Shiraz", 2002, 9.20M));
            Variants.Add(new Wine("Merlot"));
            Variants.Add(new WineVariant("Grenache"));
            Variants.Add(new WineVariant("Zinfandel"));
            Variants.Add(new WineVariant("Sauvignon Blanc"));
            Variants.Add(new WineVariant("Pino Grigio"));
        }
    }
}
