using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.EntUnitDemo
{
    public class EntUnitDemo
    {
        public void Run()
        {

        }
    }
    public abstract class EntUnit
    {
        protected string Name { get; }

        protected EntUnit(string name)
        {
            Name = name;
        }

        public virtual void Play(string instr)
        {
            Console.WriteLine($"How to use the {Name} (type={this}):\n-- {instr}");
        }
    }

    public class AudioEntUnit : EntUnit
    {

        public AudioEntUnit(string name = default) : base(name)
        {
        }
    }

    public class VisualEntUnit : EntUnit
    {
        private bool hasRemote;

        public VisualEntUnit(string name, bool hasRemote) : base(name)
        {
            this.hasRemote = hasRemote;
        }

        protected bool FoundRemote => new Random().Next(1, 10) % 2 == 0;

        public override void Play(string instr)
        {
            Console.WriteLine($"{Name} {(hasRemote ? "has" : "does not have")} a remote control");
            if (hasRemote)
            {
                Console.WriteLine("Looking for remote...");
                var foundRemote = FoundRemote;
                Console.WriteLine($"...{(foundRemote ? "found" : "couldn't find")} remote!");

                if (foundRemote)
                {
                    base.Play(instr);
                    return;
                }
            }
            Console.WriteLine($"... so, you'll have to get off the sofa!");
        }
    }
}
