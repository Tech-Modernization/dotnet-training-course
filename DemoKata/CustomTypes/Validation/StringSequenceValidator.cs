using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.CustomTypes
{
    public class StringSequenceValidator : ValidatorBase<string>
    {
        private List<string> Sequence;
        public StringSequenceValidator(params string[] sequence)
        {
            Sequence = new List<string>(sequence);
        }
        public override bool IsValid(string arg)
        {
            return Sequence.Contains(arg);
        }
    }
}
