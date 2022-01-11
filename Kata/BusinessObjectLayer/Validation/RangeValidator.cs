using BusinessObjectLayer.Validation;

namespace BusinessObjectLayer
{
    public class RangeValidator : NumberValidator
    {
        private int Min;
        private int Max;

        public RangeValidator(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public override bool IsValid(int num)
        {
            return num >= Min && num <= Max;
        }
    }
}