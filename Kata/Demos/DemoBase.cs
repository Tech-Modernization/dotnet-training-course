using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public abstract class DemoBase : IDemo
    {
        protected Action<object> cw = Console.WriteLine;
        protected List<Action> Parts { get; }

        public virtual void Run()
        {
            RunPart01();
            RunPart02();
            RunPart03();
            RunPart04();
            RunPart05();
            RunPart06();
            RunPart07();
            RunPart08();
            RunPart09();
        }

        public virtual void RunPart01()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart02()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart03()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart04()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart05()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart06()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart07()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart08()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPart09()
        {
            throw new NotImplementedException();
        }
    }
}
