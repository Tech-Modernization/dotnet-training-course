using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kata.Demos
{
    public class IndexerDemo : DemoBase
    {
        public override void Run()
        {
            base.Run();
        }

        public void Part1()
        {
            // 1. an indexer another "special method" you can set up in a class
            // 2. the purpose of an indexer is to enable the use of array reference
            //    syntax (i.e. using square brackets to directly access a particular
            //    element - []) and define how that reference is interpretted.
            var charArray = new char[] { 'a', 'b', 'c', 'd', 'e' };

            // array references start from 0 so to get the 3rd element, we have to subtract 1 from 
            // the index
            var thirdLetter = charArray[2];

            // 3. an indexer could be used to provide a "normalised" way to reference array elements

            var normCharArr = new NormalisedCharArray('a', 'b', 'c', 'd', 'e');
            // before you knew about indexers you'd have done it this way.
            var charAtReal0 = normCharArr.GetAndSetChars(2);
            var changeDtoZ = normCharArr.GetAndSetChars(4, 'Z');

            var charAtReal3 = normCharArr[4];
            normCharArr[4] = 'Q';

        }

        public void Part2()
        {
            // 4. the class you put an indexer on doesn't need to have an array or any other kind of collection.
            var contactPage = new ContactPage();
            var nameAndAddress = contactPage["NameAndAddress"];
            var phoneNumbers = contactPage["PhoneNumbers"];
            var error = contactPage["Measurements"];
        }

        public void Part3()
        {
            // 5. you can use an indexer to return an element based on a different type
            var stringExt = new Stringable("the quick brown fox jumps over the lazy dog");
            var indexesOfO = stringExt['o'];
            dbg($"The letter O appears {indexesOfO.Count} times, at positions: {string.Join(",", indexesOfO)}");
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

    public class Stringable
    {
        private string sentence;

        public Stringable(string sentence)
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
        public List<int> this[char letter]
        {
            get
            {
                var indexes = new List<int>();
                for(var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    if (c == letter)
                    {
                        indexes.Add(i);
                    }
                }
                return indexes;
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

        public char GetAndSetChars(int element, char newChar = '?')
        {
            if (newChar != '?')
                chars[element - 1] = newChar;

            return chars[element - 1];
        }

        public char this[int element]
        {
            get
            {
               return chars[element - 1];
            }
            set
            {
                chars[element - 1] = value;
            }
        }
    }
        
}