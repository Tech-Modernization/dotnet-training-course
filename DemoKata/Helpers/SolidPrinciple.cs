using System;

namespace Helpers
{
    [Flags]
    public enum SolidPrinciple
    {
        SingleResponsibility = 1 << 26,
        InterfaceSegregation = 1 << 27,
        DependencyInversion = 1 << 28,
        OpenClosed = 1 << 29,
        LyskovSubstitution = 1 << 30
    }
}