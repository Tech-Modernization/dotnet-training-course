using System;
using System.Reflection;

namespace Helpers
{
    internal static class SolidDefaultChecks
    {
        public static int MethodLimit = 5;
        public static Func<Type, SolidSeverity> SrpTooManyMethods = SRP.TooManyMethods;
        public static Func<Type, SolidSeverity> SrpLongMethods = SRP.LongMethods;
        public static Func<Type, SolidSeverity> SrpUnrelatedParamTypes = SRP.UnrelatedParamTypes;
        public static Func<Type, SolidSeverity> SrpTooManyInterfaces = SRP.TooManyInterfaces;
        public static Func<Type, SolidSeverity> SrpUnrelatedInterfaces = SRP.UnrelatedInterfaces;
        public static Func<Type, SolidSeverity> SrpTooManyBools = SRP.TooManyBools;
        public static Func<Type, SolidSeverity> SrpTooManyGenerics = SRP.TooManyGenerics;
        public static Func<Type, SolidSeverity> SrpInstantiatesExternalConcretions = SRP.InstantiatesExternalConcretions;
        public static Func<Type, SolidSeverity> IspTooManyMethods = ISP.TooManyMethods;
        public static Func<Type, SolidSeverity> IspUnrelatedParamTypes = ISP.UnrelatedParamTypes;
        public static Func<Type, SolidSeverity> IspInterfaceInheritance = ISP.InterfaceInheritance;
        public static Func<Type, SolidSeverity> IspMethodOrientedConcreteParams = DIP.MethodOrientedConcreteParams;
        public static Func<Type, SolidSeverity> DipInstantiatesExternalConcretions = DIP.InstantiatesExternalConcretions;
        public static Func<Type, SolidSeverity> DipConcreteConstructorParams = DIP.ConcreteConstructorParams;
        public static Func<Type, SolidSeverity> DipConcreteContainerMethodParams = DIP.ConcreteContainerMethodParams;
        public static Func<Type, SolidSeverity> OcpExtraParamNoDefault = OCP.ExtraParamNoDefault;
        public static Func<Type, SolidSeverity> OcpInterfaceSigChange = OCP.InterfaceSigChange;
        public static Func<Type, SolidSeverity> OcpDeadCode = OCP.DeadCode;
        public static Func<Type, SolidSeverity> LspExceptionInInheritanceChain = LSP.ExceptionInInheritanceChain;
        public static Func<Type, SolidSeverity> LspEmptyOverrideOrVirtual = LSP.EmptyOverrideOrVirtual;
        public static Func<Type, SolidSeverity> LspDummyImplementation = LSP.DummyImplementation;
        public static Func<Type, SolidSeverity> LspConcretionTypeChecking = LSP.ConcretionTypeChecking;
        public static Func<Type, SolidSeverity> LspMaskedConcretionTypeChecking = LSP.MaskedConcretionTypeChecking;

        public struct SRP
        {
            public static SolidSeverity TooManyMethods(Type t)
            {
               return t.GetMethods(BindingFlags.Public).Length > MethodLimit ? SolidSeverity.Indicator : SolidSeverity.Pass;
            }
            public static SolidSeverity LongMethods(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity UnrelatedParamTypes(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity TooManyInterfaces(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity UnrelatedInterfaces(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity TooManyBools(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity TooManyGenerics(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity InstantiatesExternalConcretions(Type t) { return SolidSeverity.Pass; }
        }
        public struct ISP
        {
            public static SolidSeverity TooManyMethods(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity UnrelatedParamTypes(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity InterfaceInheritance(Type t) { return SolidSeverity.Pass; }

        }
        public struct DIP
        {
            public static SolidSeverity MethodOrientedConcreteParams(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity InstantiatesExternalConcretions(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity ConcreteConstructorParams(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity ConcreteContainerMethodParams(Type t) { return SolidSeverity.Pass; }

        }
        public struct OCP
        {
            public static SolidSeverity ExtraParamNoDefault(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity InterfaceSigChange(Type t) { return SolidSeverity.Pass; }

            public static SolidSeverity DeadCode(Type t) { return SolidSeverity.Pass; }
        }
        public struct LSP
        {
            public static SolidSeverity ExceptionInInheritanceChain(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity EmptyOverrideOrVirtual(Type t) { return SolidSeverity.Pass; }

            public static SolidSeverity DummyImplementation(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity ConcretionTypeChecking(Type t) { return SolidSeverity.Pass; }
            public static SolidSeverity MaskedConcretionTypeChecking(Type t) { return SolidSeverity.Pass; }
        }
    }
}