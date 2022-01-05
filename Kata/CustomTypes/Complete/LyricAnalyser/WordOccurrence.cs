namespace Kata.CustomTypes.Demo.LyricAnalyser
{
    public class WordOccurrence
    {
        public string Word;
        public MatchQualityFlags MatchQuality;
        public string Section;
        public int Line;
        public int Position;

        public override string ToString()
        {
            return $"{Word,-15}{MatchQuality,-20}{Section,-10}{Line,-6}{Position,-8}";
        }
    }
}
