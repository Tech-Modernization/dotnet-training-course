using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class RangeValidator : IValidator
    {
        private int lowerBound;
        private int upperBound;

        public RangeValidator(int lowerBound, int upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }

        public virtual bool IsValid(string input)
        {
            var outInt = 0;
            return int.TryParse(input, out outInt) && IsValid(outInt);
        }

        public virtual bool IsValid(int input)
        {
            return input >= lowerBound && input <= upperBound;
        }
    }
}
