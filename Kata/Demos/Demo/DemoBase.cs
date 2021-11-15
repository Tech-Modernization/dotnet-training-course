using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Demos
{
    public abstract class DemoBase : IDemo
    {
        protected Action<object> dbg = Console.WriteLine;
        protected Dictionary<string, Action> Parts { get; }
        public DemoBase()
        {
            Parts = new Dictionary<string, Action>();
        }

        public virtual void Run()
        {
            foreach(var kvp in Parts)
            {
                dbg($"{GetType().Name}: running Part {Parts.ToList().IndexOf(kvp)+1} - {kvp.Key}");
                kvp.Value();
            }
        }

        public void AddPart(Action part, string objective)
        {
            Parts.TryAdd(objective, part);
        }
    }
}
