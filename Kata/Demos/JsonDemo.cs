using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kata.Demos
{
    public class JsonDemo : DemoBase
    {
        public class Age
        {
            public int currentAge;
        }
        public class Person
        {
            public string firstname;
            public string surname;
            public List<string> address;
            public Age age;
           // public Level1 level1;
        }
        public override void Run()
        {
            var textArray = File.ReadAllText("sampleArray.json");
            var textObject = File.ReadAllText("sampleObject.json");

            var jsonArray = JsonConvert.DeserializeObject<List<Person>>(textArray);

            var jsonObject = JObject.Parse(textObject);

            var ingList = new List<Ingredient>();
            var ingredDb = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("ingredients.json"));

            foreach(var kvp in ingredDb)
            {
                ingList.Add(new Ingredient(kvp.Key, kvp.Value));
            }

            foreach (var i in ingList)
                cw(i);
        }
    }
}
