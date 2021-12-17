using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public class GenericTypeConstraintsDemo : DemoBase
    {

        public virtual void Run()
        {
            AddPart(Part1, "Class with generic type");
        }
        public void Part1()
        {
            var g1 = new MyGen<MyThing>();
        }
    }

    public class ThingBase
    {
        public string Name;

        public ThingBase(string name)
        {
            Name = name;
        }
    }

    public class MyThing : ThingBase
    {
        public MyThing() : base("thing")
        {
        }
    }

    public class MyGen<T>
        where T: new()
    {
        public MyGen()
        {
            var p = new T();
        }
    }
}
