using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata.Demos
{
    public class DictionaryDemo : DemoBase
    {
        public override void Run()
        {
            var d = new Dictionary<string, string>();
            d.Add("tomato", "1");
            d.Add("oil", "2");
            d.Add("bread", "3");
            d.Add("fish", "4");
            d.Add("bicycles", "4");

            var numberOfFish = d["fish"];
        }


        public class Name
        {
            public int Id;
            public string First;
            public string Last;
            public override string ToString()
            {
                return $"{Id}: {First} {Last}";
            }
        }
        public void Run1()
        {
            var dic = new Dictionary<int, string>();
            var rand = new Random();
            var dupDic = new Dictionary<int, int>();
            for (var i = 0; i < 50; i++)
            {
                var next = rand.Next(1, 20);
                var added = dic.TryAdd(next, $"iteration: {i}, adding key: {next}");
                if (added) continue;

                var dupAdded = dupDic.TryAdd(next, 1);
                if (!dupAdded) dupDic[next]++;

                Console.WriteLine($"duplicate key generated - {next} has been chosen {dupDic[next] + 1} times");
            }

            var nonUniqueLinq = dic.Count(kvp => dupDic.ContainsKey(kvp.Key));
            var uniqueLinq = dic.Count(kvp => !dupDic.ContainsKey(kvp.Key));


            var list = new List<Name>();
            var firsts = new string[] { "dave", "john", "steve", "alan", "tony" };
            var lasts = new string[] { "jones", "smith", "bennett", "davies", "cochrane" };
            for (var i = 0; i < 100; i++)
            {
                var next = rand.Next(1, 20);
                var firstIndex = next % 5 == 0 ? 0 : next % 5 - 1;
                next = rand.Next(1, 20); 
                var lastIndex = next % 5 == 0 ? 0 : next % 5 - 1;
                list.Add(new Name() { Id = next, First = firsts[firstIndex], Last = lasts[lastIndex] });
            }

            Console.Write("Pick a number: ");
            var num = int.Parse(Console.ReadLine());

            var numCount = list.Count(n => n.Id == num);
            Console.WriteLine($"{num} appears in the list {numCount} times");

            var numDistinct = list.Distinct();
            Console.WriteLine($"List contains {numDistinct} distinct numbers");

            var numUniq = list.Count(i => 
                                        list.Count(j => j.ToString() == i.ToString()) == 1
            );

            Console.WriteLine($"List contains {numUniq} unique numbers");

            var matches = list.Where(i => i.Id == num).ToList();
            matches.ForEach(match => Console.WriteLine($"{num} was assigned to {match} at index {matches.IndexOf(match)}"));

            var manUniq = 0;
            foreach(var i in list)
            {
                var countOfI = 0;
                foreach(var j in list)
                {
                    if (j == i) countOfI++;
                }

                if (countOfI == 1)
                {
                    manUniq++;
                }
            }

            list.ForEach(i =>
            {
                var countOfI = 0;
                list.ForEach(j =>
                {
                    if (j == i) countOfI++;
                });

                if (countOfI == 1)
                {
                    manUniq++;
                }
            });

        }
    }
}
