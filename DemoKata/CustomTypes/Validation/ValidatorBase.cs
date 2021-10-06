using System.Collections.Generic;

namespace DemoKata.CustomTypes
{
    public abstract class ValidatorBase<T> 
    {


        public abstract bool IsValid(T arg);
    }
}