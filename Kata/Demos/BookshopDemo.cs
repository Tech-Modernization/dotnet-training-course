using Kata.CustomTypes.BookshopFactory;
using System;

namespace Kata.Demos
{
    public class BookshopDemo : IDemo
    {
        public void Run()
        {
            var creators = new SectionBase[2];
            creators[0] = new FictionSection();
            creators[1] = new NonFictionSection();
            foreach (var creator in creators)
            {
                Console.WriteLine(creator);
                foreach (var product in creator.Genres)
                {
                    Console.WriteLine($"   {product}");
                }
            }
        }
    }
}
