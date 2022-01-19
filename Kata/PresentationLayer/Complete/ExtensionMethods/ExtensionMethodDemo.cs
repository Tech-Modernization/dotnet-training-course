using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static PresentationLayer.Complete.ExtensionMethods.ExtensionMethodDemo;
using static PresentationLayer.DictionaryDemo;

namespace PresentationLayer.Complete.ExtensionMethods
{
    public static class AnimalX
    {
        public static string ToLatin(this Animal source)
        {
            return $"{source.Name}icus ludicrus";
        }
    }
    public static class ParentExt
    {
        public static string ToInformal(this Parent source)
        {
            switch (source.ParentType)
            {
                case "Mother":
                    return "Mum";
                case "Father":
                    return "Dad";
            }
            return source.ParentType;
        }

        public static string JsonToMp3FileName(this string source)
        {
            var jobject = JObject.Parse(source);
            return $"{jobject["artist"]} - {jobject["title"]} - {jobject["album"]}.mp3";
        }

    }

    public static class StringHelpers
    {
        public static string JsonToMp3FileName(string source)
        {
            var jobject = JObject.Parse(source);
            return $"{jobject["artist"]} - {jobject["title"]} - {jobject["album"]}.mp3";
        }
    }

  /*  public class StringChild : string
        {
        }
  */
    public class ExtensionMethodDemo : DemoBase
    {
        public override void Run()
        {
            AddPart(Step1, "The sealed keyword");
            base.Run();
        }

        public class Parent
        {
            public virtual string ParentType { get; set; }
            public Parent(string parentType)
            {
                ParentType = parentType;
            }
        }
        public class FamiliarParent : Parent
        {
            private string Informal;
            public override string ParentType { get => Informal ; set => Informal = value; }
            public FamiliarParent(string formal, string informal) : base(formal)
            {
                Informal = informal;
            }
        }



        public class AnimalExtra  : Animal
        {
            public AnimalExtra(string name) : base(name)
            {
            }

            public override void Move()
            {
                throw new NotImplementedException();
            }

            public string ToLatin()
            {
                return $"{Name}icus ludicrus";
            }
        }



        public void Step1()
        {
            // an extension method is a means of extending a class's functionality without 
            // inheriting from it.  consider the parent class, above.

            var mother = new Parent("Mother");
            Console.WriteLine($"You should call your {mother.ParentType}");

            // suppose we want to substitute the formal term for something more familiar?
            // fortunately in this case we can override parentType so...we don't need to change 
            // the string format to get the informal term.
            var mum = new FamiliarParent("Mother", "Mum");
            Console.WriteLine($"You should call your {mum.ParentType}");

            // but even that's a bit of a slog just to replace one term with another.
            // look at ParentExt at the top of the file.
            Console.WriteLine($"You should call your {mother.ToInformal()}");

            // extension methods are static but they're not available on the type
            // like normal static methods.  uncomment the line the below and you'll
            // the compiler doesn't like it
            //
            // var informal = Parent.ToInformal();

            // the first parameter to the method is always "this <type> <param-name>"
            // "this" is specified because __every__ instance of that type will now 
            // have access to this method.  
            //
            // that's why it needs to be static.  but it isn't part of the type, it's
            // part of the type defined by the static class you define it in.
            Console.WriteLine($"You should call your {ParentExt.ToInformal(mother)}");

            // notice how the instance of the class was passed to the method, rather than
            // the method being called on the instance.

            // the most popular class to be extended is System.String - and understandably so
            // but you must be careful not to bloat the type with methods that won't be used 
            // in the majority of situations.  
            //
            // always consider whether the functionality you're adding is generic enough to
            // warrant an extension to the type itself.  if not, it's just as easy to add a
            // static method to a helper class that takes a string or whatever you were 
            // thinking of extending.
            var trackJson = "{ \"title\":\"nineteen forever\", \"artist\":\"joe jackson\", \"album\":\"blaze of glory\"}";
            var mp3FileName = trackJson.JsonToMp3FileName();
            Console.WriteLine(mp3FileName);

            // this is way to specific to be included as an extension method.  do this instead.
            mp3FileName = StringHelpers.JsonToMp3FileName(trackJson);
            Console.WriteLine(mp3FileName);

            // why can't we just inherit from string and put the methods there?
            //
            // 1. it's not possible - uncomment the StringChild class at the top and see what happens
            // 
            // "cannot inherit from the sealed type"
            //
            // the sealed keyword is what you use when you don't want anything to inherit from the class.
            //
            // look what happens to the FamiliarParent when you add "sealed" to Parent above.  same error.
            //
            // 2. everything you want to use those methods, you'd have to change the declaration and 
            //    if the method is generic enough to warrant an extension method then the refactor is gonna
            //    be **painful**.
            //
            // 3. you might want everything in a hierarchy to be affected.  how is your child gonna make that method
            //    available to the whole hierarchy?  consider the animal hierarchy in ConstructorDemo.cs.
            // 
            //    if you wanted to replace all the names with latin equivalents and name them with all the acedemic
            //    classifications, you couldn't just inherit from animal cuz it'd just be another group like Mammal or Fish.
            //
            

            var dog = new Mammal();
            var ext = new AnimalExtra("dog");
            //    uncomment this to see ToLatin is not available
            //Console.WriteLine(dog.ToLatin());
            Console.WriteLine(ext.ToLatin());

            //    uncomment this to see the cast won't work either - there's no polymorphism without a direct relationship.
            // Console.WriteLine(((AnimalExt)dog).ToLatin());

            // now go to the top of the file and look at AnimalX - notice the extension method class must be directly beneath
            // a namespace definition.  i.e  a "top-level" class, not "nested" as these others have been.
            //
            // the abstract class animal has been extended.  now watch what happens when you uncomment the call to ToLatin() 
            // on an instance of a grand-child of that abstract class...  :-) no errors.  the whole hierarchy inherits the 
            // new method.
            var ff = new FlyingFish("fish");
            // Console.WriteLine(ff.ToLatin());
        }
    }
}
