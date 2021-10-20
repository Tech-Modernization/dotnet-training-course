using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    public interface IValidatorDone
    {
        bool IsValid(string input);
        bool IsValid(int input);
    }
}
