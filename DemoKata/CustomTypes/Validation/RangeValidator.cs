namespace DemoKata.CustomTypes
{
    public struct RangeValidator
    {
        private int Min;
        private int Max;

        public RangeValidator(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public bool IsValid(int num)
        {
            return num >= Min && num <= Max;
        }
    }
}