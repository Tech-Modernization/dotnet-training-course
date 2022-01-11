using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface IValidator
    {
        bool IsValid(string input);
        bool IsValid(int input);
    }
}
