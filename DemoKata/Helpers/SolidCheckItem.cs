using System;

namespace Helpers
{
    [Flags]
    public enum SolidCheckItem
    {
        SrpTooManyMethods = 1|SolidPrinciple.SingleResponsibility,
        SrpLongMethods = 1 << 1 | SolidPrinciple.SingleResponsibility,
        SrpUnrelatedParamTypes = 1 << 2 | SolidPrinciple.SingleResponsibility,
        SrpTooManyInterfaces = 1 << 3 | SolidPrinciple.SingleResponsibility,
        SrpUnrelatedInterfaces = 1 << 4 | SolidPrinciple.SingleResponsibility,
        SrpTooManyBools = 1 << 5 | SolidPrinciple.SingleResponsibility,
        SrpTooManyGenerics = 1 << 6 | SolidPrinciple.SingleResponsibility,
        SrpInstantiatesExternalConcretions = 1 << 7 | SolidPrinciple.SingleResponsibility,
        IspTooManyMethods = 1 << 8 | SolidPrinciple.InterfaceSegregation,
        IspUnrelatedParamTypes = 1 << 9 | SolidPrinciple.InterfaceSegregation,
        IspInterfaceInheritance = 1 << 10 | SolidPrinciple.InterfaceSegregation,
        IspMethodOrientedConcreteParams = 1 << 11 | SolidPrinciple.InterfaceSegregation,
        DipInstantiatesExternalConcretions = 1 << 12 | SolidPrinciple.DependencyInversion,
        DipConcreteConstructorParams = 1 << 13 | SolidPrinciple.DependencyInversion,
        DipConcreteContainerMethodParams = 1 << 14 | SolidPrinciple.DependencyInversion,
        OcpExtraParamNoDefault = 1 << 15 | SolidPrinciple.OpenClosed,
        OcpInterfaceSigChange = 1 << 16 | SolidPrinciple.OpenClosed,
        OcpDeadCode = 1 << 17 | SolidPrinciple.OpenClosed,
        LspExceptionInInheritanceChain = 1 << 18 | SolidPrinciple.LyskovSubstitution,
        LspEmptyOverrideOrVirtual = 1 << 19 | SolidPrinciple.LyskovSubstitution,
        LspDummyImplementation = 1 << 20 | SolidPrinciple.LyskovSubstitution,
        LspConcretionTypeChecking = 1 << 21 | SolidPrinciple.LyskovSubstitution,
        LspMaskedConcretionTypeChecking = 1 << 22 | SolidPrinciple.LyskovSubstitution
    }
}