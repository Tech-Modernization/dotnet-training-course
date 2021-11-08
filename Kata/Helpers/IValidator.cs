using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Helpers
{
    public interface IValidator
    {
        bool IsValid(string input);
        bool IsValid(int input);
    }
}
