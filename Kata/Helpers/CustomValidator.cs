using System;

namespace Helpers
{
    public class CustomValidator<T> : IValidator<T>
    {
        private Func<object, bool> p;

        public CustomValidator(Func<object, bool> p)
        {
            this.p = p;
        }

        public bool IsValid(T arg)
        {
            return p(arg);
        }
    }
}