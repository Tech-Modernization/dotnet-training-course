using System;
using System.Collections.Generic;
using System.Text;
using CustomTypes.MediaFactory;

namespace Kata.Demos
{
    public class MediaFactoryDemo
    {
        public static void Run()
        {
            var creators = new MediaCollectionBase[2];
            creators[0] = new AudioCollection();
            creators[1] = new VideoCollection();
            foreach (var creator in creators)
            {
                Console.WriteLine(creator);
                foreach (var product in creator.Items)
                {
                    Console.WriteLine($"   {product}");
                }
            }
        }
    }
}
