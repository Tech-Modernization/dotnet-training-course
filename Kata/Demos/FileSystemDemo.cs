using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kata.Helpers;

using Newtonsoft.Json;

/*
            Action<object> CW = Console.WriteLine;

            // create a text file and write to it
            var outFile = File.CreateText("e14p11.txt");
            outFile.WriteLine("blah blah blah");
            outFile.Close();

            // read the text file back
            var inFile = File.OpenText("e14p11.txt");
            var buf = inFile.ReadToEnd();
            inFile.Close();

            // create a file that happens to be a text file
            var newfile = File.Create("e14p11.txt");
            // create a stream to write to it
            var newStream = new StreamWriter(newfile);
            // write somethign to the stream
            newStream.WriteLine("bish bash bosh");
            // flush it to disk
            newStream.Flush();
            // close the stream
            newStream.Close();
            // close the file
            newfile.Close();

            // allow .net to manage flushing and closing of files and streams
            using (var newfile2 = File.Create("e14p11.txt"))
            {
                using (var newStream2 = new StreamWriter(newfile2))
                {
                    for (var i = 32; i < 91; i++)
                        newStream2.WriteLine((char) i);
                }
            }
            
            // deal with files that may or may not already exist
            using (var oldFile = File.Open("e14p11.txt", FileMode.OpenOrCreate))
            {
                using (var oldStream = new StreamReader(oldFile))
                {
                    var i = 1;
                    while (!oldStream.EndOfStream)
                    {
                        buf = oldStream.ReadLine();
                        CW($"line {i++}: {buf}");
                    }
                }
            }

            // append to an existing file
            using (var oldFile = File.Open("e14p11.txt", FileMode.Append))
            {
                using (var oldStream = new StreamWriter(oldFile))
                {
                    for(var i = 91; i < 127; i++)
                    {
                        oldStream.WriteLine((char) i);
                    }
                }
            }

Part 12

conceptual objective:
- directories

            Action<object> CW = Console.WriteLine;

            // get a list of files from a given directory
            var files = Directory.GetFiles(".");
            var filesInRoot = Directory.GetFiles("/");

            foreach (var f in files)
                CW(f);
            foreach (var f in filesInRoot)
                CW(f);

            // get a list of files from directories stored in an environment  variable
            var env = Environment.GetEnvironmentVariable("PATH");
            var dirList = env.Split(";");
            foreach (var dir in dirList)
            {
                if (string.IsNullOrEmpty(dir))
                    continue;
                try
                {
                    var filesInMyRoot = Directory.GetFiles(dir);

                    foreach (var f in filesInMyRoot)
                        CW(f);
                }
                catch
                {
                    CW($"problem with {dir}");
                    continue;
                }
            }

            // get directories in current directory
            Directory.GetDirectories(".");

            // set default place to look for files to the parent directory of the current default
            Directory.SetCurrentDirectory("..");

            // work with the elements of a file name and its directory path
            var fullPath = Path.GetFullPath("e14p11.txt");
            var ext = Path.GetFileExtension(fullPath);

            // get a list of files to select from  - i've written this to work on your VDI 
            // but that means I can't test it properly.  so modify "/h/" as need be to get it to work...
            var files = Directory.GetFiles("/h/");

            var i = 0;
            foreach(var f in files)
            {
                Console.WriteLine($"{i++} {f}");
            }
            Console.Write($"Pick a file between 0 and {files.Length}:  ");
            var fileSelected = files[int.Parse(Console.ReadLine())];

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


*/
namespace Kata.Demos
{
    public class FileSystemDemo : DemoBase
    {
        public override void Run()
        {
            // get a list of files to select from 
            var files = Directory.GetFiles("/h/");

            var i = 0;
            foreach(var f in files)
            {
                Console.WriteLine($"{i++} {f}");
            }
            Console.Write($"Pick a file between 0 and {files.Length}:  ");
            var fileSelected = files[int.Parse(Console.ReadLine())];

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

        public void FileBasics()
        {
            // create a text file and write to it
            var outFile = File.CreateText("e14p11.txt");
            outFile.WriteLine("blah blah blah");
            outFile.Close();

            // read the text file back
            var inFile = File.OpenText("e14p11.txt");
            var buf = inFile.ReadToEnd();
            inFile.Close();

            // create a file that happens to be a text file
            var newfile = File.Create("e14p11.txt");
            // create a stream to write to it
            var newStream = new StreamWriter(newfile);
            // write somethign to the stream
            newStream.WriteLine("bish bash bosh");
            // flush it to disk
            newStream.Flush();
            // close the stream
            newStream.Close();
            // close the file
            newfile.Close();

            // allow .net to manage flushing and closing of files and streams
            using (var newfile2 = File.Create("e14p11.txt"))
            {
                using (var newStream2 = new StreamWriter(newfile2))
                {
                    for (var i = 32; i < 91; i++)
                        newStream2.WriteLine((char) i);
                }
            }

            // deal with files that may or may not already exist
            using (var oldFile = File.Open("e14p11.txt", FileMode.OpenOrCreate))
            {
                using (var oldStream = new StreamReader(oldFile))
                {
                    var i = 1;
                    while (!oldStream.EndOfStream)
                    {
                        buf = oldStream.ReadLine();
                        cw($"line {i++}: {buf}");
                    }
                }
            }

            // append to an existing file
            using (var oldFile = File.Open("e14p11.txt", FileMode.Append))
            {
                using (var oldStream = new StreamWriter(oldFile))
                {
                    for (var i = 91; i < 127; i++)
                    {
                        oldStream.WriteLine((char) i);
                    }
                }
            }

            // get a list of files from a given directory
            var files = Directory.GetFiles(".");
            var filesInRoot = Directory.GetFiles("/");

            foreach (var f in files)
                cw(f);
            foreach (var f in filesInRoot)
                cw(f);

            // get a list of files from directories stored in an environment  variable
            var env = Environment.GetEnvironmentVariable("PATH");
            var dirList = env.Split(";");
            foreach (var dir in dirList)
            {
                if (string.IsNullOrEmpty(dir))
                    continue;
                try
                {
                    var filesInMyRoot = Directory.GetFiles(dir);

                    foreach (var f in filesInMyRoot)
                        cw(f);
                }
                catch
                {
                    cw($"problem with {dir}");
                    continue;
                }
            }

            // get directories in current directory
            Directory.GetDirectories(".");

            // set default place to look for files to the parent directory of the current default
            Directory.SetCurrentDirectory("..");

            // work with the elements of a file name and its directory path
            var fullPath = Path.GetFullPath("e14p11.txt");
            var ext = Path.GetExtension(fullPath);
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
