using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Kata.CustomTypes.Extensions;

using Newtonsoft.Json.Linq;

namespace Kata.CustomTypes.Demo.LyricAnalyser
{
    public class LyricSheet
    {
        private string title;
        Dictionary<string, List<string>> song = new Dictionary<string, List<string>>();
        public LyricSheet(string path)
        {
            var jsonObject = JObject.Parse(File.ReadAllText(path));
            foreach (var jprop in jsonObject.Properties())
            {
                switch (jprop.Value.Type)
                {
                    case JTokenType.String:
                        title = jsonObject[jprop.Name].ToString();
                        break;
                    case JTokenType.Array:
                        song.Add(jprop.Name, jsonObject[jprop.Name].Select(x => x.ToString()).ToList());
                        break;
                }
            }
        }

        public LyricQueryReport this[string word, params string[] sections]
        {
            get => GetLyricQueryReport(word, sections);
        }

        private LyricQueryReport GetLyricQueryReport(string word, string[] sections)
        {
            var allSections = sections.Length == 0;
            if (allSections)
                sections = song.Keys.ToArray();

            Func<char, bool> splitter = (c) =>
            {
                return !(char.IsLetter(c) || char.IsNumber(c));
            };
            var lqr = new LyricQueryReport();
            lqr.Word = word;

            song.ToList().ForEach(
                kvp =>
                {
                    var lineNum = 0;
                    kvp.Value.ToList().ForEach(line =>
                    {
                        lineNum++;
                        var wordNum = 0;
                        line.SplitByAny(splitter).ToList().ForEach(w =>
                        {
                            // splitting by punctuation will often lead to blank tokens
                            if (w.Length == 0)
                                return;

                            wordNum++;
                            var qflags = MatchQualityFlags.None;
                            if (w == word)
                                qflags |= MatchQualityFlags.Exact;
                            else if (w.ToLower() == word.ToLower())
                                qflags |= MatchQualityFlags.CaseBlind | MatchQualityFlags.Exact;
                            else if (w.ToLower().StartsWith(word.ToLower()))
                                qflags |= MatchQualityFlags.Partial | MatchQualityFlags.CaseBlind;

                            if (qflags == MatchQualityFlags.None)
                                return;

                            // we got a match - save the detail 
                            var wo = new WordOccurrence();
                            wo.MatchQuality = qflags;
                            wo.Word = w;
                            wo.Section = kvp.Key;
                            wo.Line = lineNum;
                            wo.Position = wordNum;
                            lqr.OccurrenceDetail.Add(wo);
                        });
                    });
                });

            lqr.TotalExactOccurrences = lqr.OccurrenceDetail.Sum(od => od.MatchQuality.HasFlag(MatchQualityFlags.Exact) ? 1 : 0);
            lqr.TotalCaseBlindOccurrences = lqr.OccurrenceDetail.Sum(od => od.MatchQuality.HasFlag(MatchQualityFlags.CaseBlind) ? 1 : 0);
            lqr.TotalPartialOccurrences = lqr.OccurrenceDetail.Sum(od => od.MatchQuality.HasFlag(MatchQualityFlags.Partial) ? 1 : 0);

            lqr.OccurrenceDetail.GroupBy(od => od.Section,
                od => od,
                (sec, occs) => new { Section = sec, Occurrences = occs.Count() }).ToList()
                .ForEach(stats => lqr.OccurrencesBySection.TryAdd(stats.Section, stats.Occurrences));

            return lqr;
        }
    }
}
