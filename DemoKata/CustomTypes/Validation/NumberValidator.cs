using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.CustomTypes
{
    public class NumberValidator : ValidatorBase<int>
    {
        public override bool IsValid(int arg)
        {
            throw new NotImplementedException();
        }
    }
}
