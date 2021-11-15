using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos.EntUnitDemo
{
    public class EntUnitDemo : DemoBase
    {
        public override void Run()
        {
            var aud = new AudioEntUnit("turntable");
            dbg(aud.Name);
            var i = aud as IEntUnit;
            i.Play("meh");
            var ent = i as EntUnit;
            dbg(ent.Name);
        }

        public void RunPart01()
        {
            throw new NotImplementedException();
        }

        public void RunPart02()
        {
            throw new NotImplementedException();
        }

        public void RunPart03()
        {
            throw new NotImplementedException();
        }

        public void RunPart04()
        {
            throw new NotImplementedException();
        }

        public void RunPart05()
        {
            throw new NotImplementedException();
        }

        public void RunPart06()
        {
            throw new NotImplementedException();
        }

        public void RunPart07()
        {
            throw new NotImplementedException();
        }

        public void RunPart08()
        {
            throw new NotImplementedException();
        }

        public void RunPart09()
        {
            throw new NotImplementedException();
        }
    }

    public interface IEntUnit
    {
        void Play(string instr);
    }
    public abstract class EntUnit : IEntUnit
    {
        public string Name { get; }

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
