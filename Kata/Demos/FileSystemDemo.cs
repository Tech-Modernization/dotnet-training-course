using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kata.Helpers;

using Newtonsoft.Json;

namespace Kata.Demos
{
    public class FileSystemDemo : IDemo
    {
        public void Run()
        {
            // get a list of files to select from 
            var files = Directory.GetFiles("../../../");

            var fileSelected = SelectFromMenu(files);

            Console.WriteLine(fileSelected);
            // read the contents of selected file
            var textInOneGo = File.ReadAllText(fileSelected);

            var lineByLine = File.ReadAllLines(fileSelected);

            // display contents
            Console.WriteLine($"Preview of {fileSelected}:");
            for(var i = 0; i < (10 > lineByLine.Length ? lineByLine.Length : 10); i++)
            {
                Console.WriteLine(lineByLine[i]);
            }

            // parse contents to use in calculations
            var ext = Path.GetExtension(fileSelected);
            switch(ext)
            {
                case ".csv":
                foreach (var line in lineByLine)
                    Console.WriteLine(ParseCSV(line));
                    break;
                case ".json":
                    var ingreds = JsonConvert.DeserializeObject<Dictionary<string, string>>(textInOneGo);
                    break;
            }

            // take some input of different types and write to a file 
            // use one of the factory setups to get an object hierarchy
            // deserialise to json and write to file
            // select another json file and serialise it to a factory

            
        }

        public enum GameConsole { PlayStation4, PS4, XBOX };
        public struct GameInfo
        {
            public int Age; 
            public string Name; 
            public GameConsole Hardware; 
            public bool InGamePurchases;

            public override string ToString()
            {
                return $"Title {Name} is certificate {Age} and in game purchases are {(InGamePurchases ? "enabled" : "disabled")}\nAvailable on {Hardware}";
            }
        }
        public GameInfo ParseCSV(string line)
        {
            var info = new GameInfo();
            var tokens = line.Split(",");

            ParseCSV("abv");
            var parsed = int.TryParse(tokens[0], out info.Age);
            parsed = Enum.TryParse<GameConsole>(tokens[2], out info.Hardware);
            parsed = bool.TryParse(tokens[3], out info.InGamePurchases);

            info.Name = tokens[1];
            return info;
        }

        public string SelectFromMenu(string[] options)
        {
            var selectedFile = string.Empty;
            do
            {
                for (var opt = 0; opt < options.Length; opt++)
                {
                    var option = options[opt];
                    Console.WriteLine($"-{opt + 1:D2} - {option}");
                }

                int selection;
                var gotSelection = ConsoleHelperDone.GetInteger("> ", out selection, new RangeValidatorDone(1, options.Length));
                if (gotSelection)
                {
                    return options[selection - 1];
                }
            }
            while (true);
        }
    }
}
