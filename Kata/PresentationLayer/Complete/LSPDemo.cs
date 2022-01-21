using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Complete
{
    public class NumberGrouper
    {
        public List<int> numbers;
        public NumberGrouper(int low, int high)
        {
            numbers = new List<int>();
            for (var i = low; i <= high; i++)
                numbers.Add(i);
        }
        public virtual List<int> MultiplesOf(int baseNum)
        {
            return numbers.Where(n => n % baseNum == 0).ToList();
        }
    }


    public class EveryOtherMultipleGrouper : NumberGrouper
    {
        public EveryOtherMultipleGrouper(int low, int high) : base(low, high)
        {
        }

        public List<int> EveryOtherMultipleOf(int baseNum)
        {
            var multi = base.MultiplesOf(baseNum);
            var oddMultiples = new List<int>();
            for(var i = 0; i < multi.Count; i+= 2)
            {
                oddMultiples.Add(multi[i]);
            }
            return oddMultiples;
        }
    }

    public class GrouperService
    {
        public List<EveryOtherMultipleGrouper> Groupers;

        public GrouperService()
        {
            Groupers = new List<EveryOtherMultipleGrouper>();
            Groupers.Add(new EveryOtherMultipleGrouper(-50, 200));
            Groupers.Add(new EveryOtherMultipleGrouper(1, 100));

        }
    }
    public class LSPDemo : DemoBase
    {
        public override void Run()
        {
            AddPart(Part1, "part 1");

            base.Run();
        }

        public void Part1()
        {
            var service = new GrouperService();
            var baseNumber = int.Parse(Console.ReadLine());
            foreach (var ng in service.Groupers)
            {
                var numList = string.Join(",", baseNumber >= 10 ? ng.MultiplesOf(baseNumber) : ng.EveryOtherMultipleOf(baseNumber));
                Console.WriteLine($"{ng.GetType().FullName}: {numList}");
            }
        }

        public void EveryOther(EveryOtherMultipleGrouper ng)
        {
            Console.WriteLine($"{ng.GetType().FullName}: {string.Join(",", ng.EveryOtherMultipleOf(13))}");
        }
    }
}
