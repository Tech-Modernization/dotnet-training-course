using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe
{
    public abstract class DemoBase
    {
        protected Action<object> dbg = Console.WriteLine;
        protected Dictionary<string, Action> Parts = new Dictionary<string, Action>();
        public virtual void Run()
        {
            var p = 1;
            foreach(var kvp in Parts)
            {
                dbg($"--\nRunning Part {p++}: {kvp.Key}\n--");
                kvp.Value();
            }
        }

        protected void AddPart(Action partMethod, string title)
        {
            Parts.TryAdd(title, partMethod);
        }
    }
}
