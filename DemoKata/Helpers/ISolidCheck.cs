using System;

namespace Helpers
{
    public interface ISolidCheck
    {
        SolidCheckItem Item { get; }
        SolidPrinciple Principle { get; }
        SolidSeverity Status { get; }
        string GuideText { get; }
        SolidSeverity Run(Type t);
        SolidSeverity Run(Func<Type, SolidSeverity> checker, Type t);
    }
}