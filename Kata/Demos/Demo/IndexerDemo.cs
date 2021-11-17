using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;

using Newtonsoft.Json.Linq;

namespace Kata.Demos
{
    public class IndexerDemo : DemoBase
    {
        public override void Run()
        {
            AddPart(Part1, "Simple indexer to 'normalise' array references");
            AddPart(Part2, "Simple indexer to receive and return different types");
            AddPart(Part3, "Indexer with multiple parameters");
            base.Run();
        }

        public void Part1()
        {
            // 1. an indexer another "special method" you can set up in a class
            // 2. the purpose of an indexer is to enable the use of array reference
            //    syntax (i.e. using square brackets to directly access a particular
            //    element - []) and define how that reference is interpretted.

            var charArray = new char[] { 'a', 'b', 'c', 'd', 'e' };

            // array references start from 0 so to get the 3rd element, we have to subtract 1 from 
            // the index
            var thirdLetter = charArray[2];

            // 3. an indexer could be used to provide a "normalised" way to reference array elements
            var normCharArray = new NormalisedCharArray(5) { contents = new char[] { 'a', 'b', 'c', 'd', 'e' } };
            thirdLetter = normCharArray[3];

        }

        public void Part2()
        {
            // 4. you can use an indexer to return an element based on a different type
            var stringExt = new Stringable("the quick brown fox jumps over the lazy dog");
            var indexesOfO = stringExt['o'];
            dbg($"The letter O appears {indexesOfO.Count} times, at positions: {string.Join(",", indexesOfO)}");
}


        public void Part3()
        {
            // 5. you can pass more than one argument to an indexer
            // 
            // e.g. in this example i'm simulating what, as a database query would look 
            // like this (denormalised) sql
            //
            //    select lyric from songs where title = "she loves you"
            //                              and section = "verse"
            //                              and lyric like "%love%"
            //
            var lyrics = new LyricSheet();
            // 
         //   var loveRefsInVerses = lyrics["love", "verse"];

        }

        public class LyricSheet
        {
            Dictionary<string, List<string>> song = new Dictionary<string, List<string>>();
            public LyricSheet()
            {
                var jsonObject = JObject.Parse(File.ReadAllText("she-loves-you.json"));
                foreach(var jprop in jsonObject.Properties())
                {
                    song.Add(jprop.Name, jprop.Type == JTokenType.Property 
                        ? new List<string>() { jprop.Value<string>() } 
                        : jprop.Value<List<string>>());
                }
            }

        }

        public class Stringable
        {
            private string str;
            public Stringable(string val)
            {
                str = val;
            }

            public List<int> this[char tgt]
            {
                get => str.Where(c => c == tgt).Select(c => str.IndexOf(c)).ToList();
            }
        }

        public class NormalisedCharArray : NormalisedCharArray<char>
        { 
            public NormalisedCharArray(int cap) : base(cap)
            { }
        }
        public class NormalisedCharArray<T> where T: new()
        {
            public char[] contents;
            public NormalisedCharArray(int capacity)
            {
                if (typeof(T) != typeof(char))
                    throw new TypeLoadException();

                if (capacity > 0)
                    contents = new char[capacity];
            }

            public char this[int index]
            {
                get => index > 0 ? contents[index - 1] : default;
            }
        }
    }
}