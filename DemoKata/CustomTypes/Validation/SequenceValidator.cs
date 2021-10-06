using System;
using System.Collections.Generic;

namespace DemoKata.CustomTypes
{
    public class SequenceValidator : NumberValidator
    {
        private List<int> sequence;
        public SequenceValidator(params int[] seq)
        {
            sequence = new List<int>(seq);
        }
        public SequenceValidator(List<int> seq)
        {
            sequence = seq;
        }

        public override bool IsValid(int arg)
        {
            return sequence.Contains(arg);
        }
    }
}