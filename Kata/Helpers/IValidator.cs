using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface IValidator<T>
    {
        bool IsValid(T arg);
    }
}
