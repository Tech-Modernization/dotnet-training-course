using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PresentationLayer
{
    public class SomeClass { }
    public class IndexerDemo : DemoBase
    {
        public override void Run()
        {
            AddPart(Part2, "Work thru a basic indexer");
            base.Run();
        }

        public void Part1()
        {
            // 1. an indexer is another "special method" you can set up in a class
            // 2. the purpose of an indexer is to enable the use of array reference
            //    syntax (i.e. using square brackets to directly access a particular
            //    element - []) and define how that reference is interpreted.
            var charArray = new char[] { 'a', 'b', 'c', 'd', 'e' };

            // array references start from 0 so to get the 3rd element, we have to subtract 1 from 
            // the index
            var thirdLetter = charArray[2];

            // 3. an indexer could be used to provide a "normalised" way to reference array elements
            //    e.g. we want to be able to say var thirdLetter = charArray[3] and it return 'c' not 'd'.

            // 4. so we create a class that can receive a list of chars to be put in an array
            var normCharArr = new NormalisedCharArray('a', 'b', 'c', 'd', 'e');

            // before you knew about indexers you'd have done it this way.
            var charAtNormalPos2 = normCharArr.GetAndSetChars(2);
            // returns 'b'

            var changeDtoZ = normCharArr.GetAndSetChars(4, 'Z');
            // return 'Z'

            // with an indexer, we don't need as many arguments to the method, cuz an indexer
            // works more like a property in that it has a getter and setter.

            var charAtNormal4 = normCharArr[4];
            normCharArr[4] = 'Q';

        }
        public void Part2()
        {

        }
        public void Part2a()
        {
            // 5. indexers don't have to use the same data types as are associated with the
            //    collections of data they provide access to.
            //
            // let's say we want to find all the occurrences of a given character in a string
            // we could create a class that has a string in it and then write a method to 
            // return a list of the indexes where a given character appears.
            //
            // public class Stringable 
            // {
            //     private string sentence;
            //     public Stringable(string _sentence)
            //     {
            //         sentence = _sentence;
            //     }
            //     public List<int> GetIndexesOf(char letter) 
            //     {
            //         ...
            //     }
            // }

            var stran = new StringAnalyser("the quick brown fox jumps over the lazy dog");
            var indexesOfEByMethod = stran.GetIndexesOf('e');

            // but you could do this more succinctly with an indexer
            //var indexesOfE = stran['e'];

            // but this approach would need to be consistent with the class's responsibility
            // if this was the only purpose of the method, it would probably be better *not* to use
            // an indexer.   but, let's say we want to replace the characters at certain positions 
            // with another character.
            //
            // if a 

            // but what if we wanted to replace that char with another char?  we could add more parameters
            // to the method of course.
            //
            //     public List<int> GetIndexesOf(char letter, char? replacementLetter) 
            //     {
            //             find letter...
            //             if (replacementLetter.HasValue) ...do replacement
            //     }
            //
            // it's a bit fiddly and cumbersome when there is a more elegant way of achieving the same thing.
            // 
            // below, the setter of the indexer finds each occurrence of 'o' and replaces it with '0' with
            // this simple assignment syntax.

//            stran['o'] = '0';
        }

        public void Part3()
        {
            // 6.  indexers can have more than one parameter
            //
            // after doing the assignment above, we might still want to know where the indexes were
            // below, all occurrences of 'e' are replaced with '3' *and* the indexes of E are return in the argument list.
            //
            // NOTE: you can't use ref or out with indexer parameters.
            //
            var indexesOfE = new List<int>();
            var stringExt = new StringAnalyser("the quick brown fox jumps over the lazy dog");
            stringExt['e', indexesOfE] = '3';

            // 7. let's say
        }


        public void Part12()
        {
            // 4. the class you put an indexer on doesn't need to have an array or any other kind of collection.
            var contactPage = new ContactPage();
            var nameAndAddress = contactPage["NameAndAddress"];
            var phoneNumbers = contactPage["PhoneNumbers"];
            var error = contactPage["Measurements"];
        }

        public void Part13()
        {
            // 5. you can use an indexer to return an element based on a different type
            var stringExt = new StringAnalyser("the quick brown fox jumps over the lazy dog");
          //  var indexesOfO = stringExt['o'];
           // dbg($"The letter O appears {indexesOfO.Count} times, at positions: {string.Join(",", indexesOfO)}");
        }


        public void Part4()
        {
            // 5. you can pass more than one argument to an indexer
            // 
            var lyrics = new LyricSheet("she-loves-you.json");
            var occsOfYeah = lyrics["yeah", "chorus*", true];
            var occsOfLove = 0;
        }

        public void Part5()
        {
            // 6. you can put indexers in interfaces

        }

    }

    public class LyricSheet
    {
        private Dictionary<string, List<string>> song;
        public LyricSheet(string path)
        {
            song = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(path));
        }

        public int this[string word, string section, bool showLog = false]
        {
            get => getTotalOccurrencesOf(word, section, showLog);
        }

        private int getTotalOccurrencesOf(string wordSearch, string sectionSearch, bool showLog)
        {
            var matchPartialSec = sectionSearch.EndsWith("*");
            var matchPartialWord = wordSearch.EndsWith("*");
            var word = wordSearch.Split("*").First().ToLower();
            var section = sectionSearch.Split("*").First().ToLower();
            var occs = song.Keys.Where(sec =>
                {
                    var isMatch = matchPartialSec ? sec.ToLower().StartsWith(section) : sec.ToLower() == section;
                    if (showLog)
                    {
                        Console.WriteLine($"Section: {sec}, Match for {sectionSearch}: {(isMatch ? "Yes" : "No")} Partial matches: {(matchPartialSec ? "On" : "Off")}");
                    }
                    return isMatch;
                }).Sum(key =>
                {
                    var secOccs = song[key].Sum(line =>
                         {
                             if (showLog)
                             {
                                 Console.WriteLine($"    Line: {line}");
                             }

                             return line.Replace(",", "").ToLower().Split(" ").Count(w =>
                             {
                                 var isWordMatch = matchPartialWord ? w.StartsWith(word) : w == word;
                                 if (showLog)
                                 {
                                     Console.WriteLine($"        Word: '{w}', " +
                                         $"Match for {wordSearch}: {(isWordMatch ? "Yes" : "No")}, Partial matches: {(matchPartialWord ? "On" : "Off")}");
                                 }
                                 return isWordMatch;
                             });
                         });
                    return secOccs;
                });
            return occs;
        }
    }

    public class StringAnalyser
    {
        private string sentence;

        public StringAnalyser(string sentence)
        {
            this.sentence = sentence;
        }

        public Dictionary<string, int> Analyse()
        {
            var detail = new Dictionary<string, int>();
            detail.Add("length", sentence.Length);
            detail.Add("letters", sentence.Count(c => char.IsLetter(c)));
            detail.Add("numbers", sentence.Count(c => char.IsDigit(c)));
            detail.Add("punc", sentence.Count(c => char.IsPunctuation(c)));
            sentence.ToList().ForEach(c => detail.Add("${c}", sentence.Count(next => next == c)));
            return detail;
        }
        public JObject AnalyseToJson()
        {
            return new JObject(Analyse());
        }
        public List<int> GetIndexesOf(char letter)
        {
            var indexes = new List<int>();
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                if (c == letter)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }

        public List<int> ReplaceChar(char original, char replacement)
        {
            var indexes = new List<int>();
            var sentenceArray = sentence.ToArray();
            for (var i = 0; i < sentenceArray.Length; i++)
            {
                var c = sentenceArray[i];
                if (c == original)
                {
                    indexes.Add(i);
                    sentenceArray[i] = replacement;
                }
            }
            sentence = string.Join("", sentenceArray);
            return indexes;
        }

        public char this[char letter, List<int> indexes]
        {
            get
            {
                indexes.Clear();
                for(var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    if (c == letter)
                    {
                        indexes.Add(i);
                    }
                }
                return letter;
            }
            set
            {
                indexes.Clear();
                var charList = new List<char>();
                for (var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    charList.Add(c == letter ? value : c);
                    if (c == letter)
                    {
                        indexes.Add(i);
                    }
                }
                sentence = string.Join("", charList);
            }
        }

        public string ToString(char c)
        {
            var sb = new StringBuilder();
            foreach(var kvp in Analyse())
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value}");
            }
            return sb.ToString();
        }
    }

    public class ContactPage
    {
        public string NameAndAddress;
        public string Name = "Sherlock Holmes";
        public int HouseNo = 221;
        public string Street = "Baker St";
        public string Town = "London";
        public string Postcode = "NW1";

        public string PhoneNumbers;
        public string Home = "01 811 8055";
        public string Mobile = "07896 478545";
        public string Work = "0800 321456";

        public List<string> this[string sectionName]
        {
            get
            {
                if (sectionName == "NameAndAddress")
                {
                    return new List<string> { Name, $"{HouseNo}, {Street}", Town, Postcode };
                }

                if (sectionName == "PhoneNumbers")
                {
                    return new List<string> { Home, Work, Mobile };
                }

                throw new Exception($"I don't have a {sectionName} section");
            }
        }
    }

    public class NormalisedCharArray
    {
        private char[] chars;

        public NormalisedCharArray(params char[] chars)
        {
            this.chars = chars;
        }

        // method signature components
        // 1. access level
        // 2. return type 
        // 3. name
        // 4. parameter list
        // 5. body

        //1.     2.     3.          4.
        public char GetAndSetChars(int element, char newChar = '?')
        // 5.
        {
            if (newChar != '?')
                chars[element - 1] = newChar;

            return chars[element - 1];
        }

        // declare the indexer like a method
        // the components of a method signature are:
        // 
        // 1. access level
        // 2. return type 
        // 3. name
        // 4. parameter list
        // 5. body
        // 
        // so the name of the indexer method is "this"
        // 
        // presumably for making the syntax relatable, the authors of the compiler
        // decided that rather than wrapping the method parameter declarations in 
        // parentheses, it would be better to use square bracker as an intuitive 
        // indication of the syntax it makes possible.

        // 1.   2.   3.   4.
        public char this[int element]
        // 5.
        {
            // getter method, just like a property, now
            get
            {
               return chars[element - 1];
            }
            // setter method, just like a property, now
            set
            {
                chars[element - 1] = value;
            }
        }
    }
        
}