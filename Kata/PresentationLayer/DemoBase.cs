using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Demos
{
    public abstract class DemoBase : IDemo
    {
        protected Action<object> dbg = Console.WriteLine;
        protected Dictionary<string, Action> Parts = new Dictionary<string, Action>();
        public virtual void Run()
        {
            var p = 1;
            foreach (var kvp in Parts)
            {
                dbg($"--\nRunning Part {p++}: {kvp.Key}\n--");
                kvp.Value();
            }
        }

        public virtual void AddPart(Action partMethod, string title)
        {
            Parts.TryAdd(title, partMethod);
        }
    }
}
