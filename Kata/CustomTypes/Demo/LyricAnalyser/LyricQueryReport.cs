using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kata.CustomTypes.Extensions;

namespace Kata.CustomTypes.Demo.LyricAnalyser
{
    public class LyricQueryReport
    {
        public string Word;
        public int TotalCaseBlindOccurrences;
        public int TotalExactOccurrences;
        public int TotalPartialOccurrences;
        public Dictionary<string, int> OccurrencesBySection = new Dictionary<string, int>();
        public List<WordOccurrence> OccurrenceDetail = new List<WordOccurrence>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Lyric report for '{Word}'");
            sb.AppendLine($"\nTotal occurrences:\n");
            sb.AppendLine($"Exact: {TotalExactOccurrences,4}, CaseBlind: {TotalCaseBlindOccurrences,4}, Partial(CaseBlind): {TotalPartialOccurrences}");
            sb.AppendLine("- ".Repeat(30));
            sb.AppendLine("Occurences by section:");
            sb.AppendJoin("\n", OccurrencesBySection.Select(kvp => $"    {kvp.Key,-15}:{kvp.Value,6}\n"));
            sb.AppendLine("- ".Repeat(30));
            sb.AppendLine($"Occurence detail for {Word}:\n");
            sb.AppendLine($"{"Match",-15}{"Quality",-20}{"Section",-10}{"Line",-6}{"Position",-8}");
            sb.AppendLine("- ".Repeat(30));
            sb.AppendJoin("\n", OccurrenceDetail);
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
