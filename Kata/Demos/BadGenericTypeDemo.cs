using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public class BadGenericTypeDemo : IDemo
    {
        public void Run()
        {
            
        }
    }

    public class BadKarmaCreator<T>
    {
        public T DoubleCastCreate()
        {
            // 1. notice the typeof comparison - Reflection knows how to compare these two Type objects.
            // 2. notice the double cast creation in the middle - (T)(object) is an abuse of generics.  
            // 3. the factory pattern is the real solution to instantiation problems.
            return typeof(T) == typeof(KeyValuePair) ? (T)(object)new KeyValuePair<int, int>() : default;
        }

        public T AssemblyCreate()
        {
            var t = typeof(T);
            // 1. notice the implicit double cast as CreateInstance only returns a System.Object (C# keyword: object)
            // 2. think about what happens if the type T has had its default constructor overwritten by one with parameters?
            ///   2a. the CreateInstance method would throw an exception cuz those parameters had not been supplied.
            ///   2b. how would you establish the type of those parameters and provide values?  even tho it *can* be done, it
            ///       leads to a whole world of painful mess.
            
            // Moral of the story?   Don't abuse Generics and use the Factory Pattern instead :-)
            return (T) t.Assembly.CreateInstance(t.FullName);
        }
    }
}
