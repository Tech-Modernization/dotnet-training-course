using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Demos
{
    public class ConstructorDemo : IDemo
    {
        public void Run()
        {
            var ff = new FlyingFish("Flying fish");
            ff.MakeNoise("splash");
            var d = new Dog("Dog");
            d.MakeNoise("Woof!");
        }
    }

    public abstract class Animal
    {
        protected virtual string Name { get; set; }
        protected Animal(string name)
        {
            Name = name;
        }

        public virtual void MakeNoise(string noise) 
        {
            Console.WriteLine($"{Name} goes {noise}");
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Mammal : Animal
    {
        protected Mammal(string name) : base(name)
        {
        }
    }

    public class Fish : Animal
    {
        protected Fish(string name) : base(name)
        {
        }
    }

    public class FlyingFish : Fish
    {
        public FlyingFish(string name) : base(name)
        {
        }
    }

    public class Dog : Mammal
    {
        public Dog(string name = null) : base("Dog")
        {
        }
    }




    public class AnimalPropertyDemo
    {
        private string name;
        // v1
        public string GetName() { return name; }
        public void SetName(string _value) { name = _value; }
        // v2
        public string Name
        {
            get 
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        // v3
        public string AnonName
        {
            get => name; 
            set => name = value;
        }
        // v4
        public string AutoName { get; set; }
    }
}
