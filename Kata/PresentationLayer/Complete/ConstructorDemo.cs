using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ConstructorDemo : DemoBase
    {
        public override void Run()
        {
            AddPart(Part2, "Moving animals");
            base.Run();
        }

        public void Part1()
        {
            var ff = new FlyingFish("Flying fish");
            ff.MakeNoise("splash");
            var d = new Dog("Dog");
            d.MakeNoise("Woof!");
        }

        public void Part2()
        {
            var dog = new Dog();
            var whale = new Whale("willy");
            dog.Move();
            whale.Move();
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

        public abstract void Move();

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
        public Mammal() : this("Unknown")
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{this.GetType().FullName} Moves by using legs");
        }
    }

    public class Dog : Mammal
    {
        public Dog() : base("Dog")
        {
        }
        public Dog(string name) : this()
        {
            Name = name;
        }

        public override void Move()
        {
            base.Move();

            Console.WriteLine($"{this.GetType().FullName} can also swim");
        }
    }

    public class Fish : Animal
    {
        protected Fish(string name) : base(name)
        {
        }

        public override void Move()
        {
            Console.WriteLine("Swims");
        }
    }
    public class FlyingFish : Fish
    {
        public FlyingFish(string name) : base(name)
        {
        }
    }
    public class Whale : Mammal
    {
        public Whale(string name) : base(name)
        {
        }

        public override void Move()
        {
            Console.WriteLine("Whales move by swimming");
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
