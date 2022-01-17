using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Composition;
using Helpers.Extensions;
using System.Reflection;

namespace Helpers
{
    public static class SolidChecklistHelper
    {
        static SolidCheckProvider checkProvider = new SolidCheckProvider("../../../solid-checklist.json");
        public static string SolidProfilePath = "../../solid-profile.json";

        static Dictionary<SolidCheckItem, Func<Type, SolidSeverity>> defaultCheckList = new Dictionary<SolidCheckItem, Func<Type, SolidSeverity>>()
        {
            { SolidCheckItem.SrpTooManyMethods, SolidDefaultChecks.SrpTooManyMethods },
            { SolidCheckItem.SrpLongMethods , SolidDefaultChecks.SrpLongMethods },
            { SolidCheckItem.SrpUnrelatedParamTypes , SolidDefaultChecks.SrpUnrelatedParamTypes },
            { SolidCheckItem.SrpTooManyInterfaces , SolidDefaultChecks.SrpTooManyInterfaces },
            { SolidCheckItem.SrpUnrelatedInterfaces , SolidDefaultChecks.SrpUnrelatedInterfaces },
            { SolidCheckItem.SrpTooManyBools , SolidDefaultChecks.SrpTooManyBools },
            { SolidCheckItem.SrpTooManyGenerics , SolidDefaultChecks.SrpTooManyGenerics },
            { SolidCheckItem.SrpInstantiatesExternalConcretions , SolidDefaultChecks.SrpInstantiatesExternalConcretions },
            { SolidCheckItem.IspTooManyMethods , SolidDefaultChecks.IspTooManyMethods },
            { SolidCheckItem.IspUnrelatedParamTypes , SolidDefaultChecks.IspUnrelatedParamTypes },
            { SolidCheckItem.IspInterfaceInheritance , SolidDefaultChecks.IspInterfaceInheritance },
            { SolidCheckItem.IspMethodOrientedConcreteParams , SolidDefaultChecks.IspMethodOrientedConcreteParams },
            { SolidCheckItem.DipInstantiatesExternalConcretions , SolidDefaultChecks.DipInstantiatesExternalConcretions },
            { SolidCheckItem.DipConcreteConstructorParams , SolidDefaultChecks.DipConcreteConstructorParams },
            { SolidCheckItem.DipConcreteContainerMethodParams , SolidDefaultChecks.DipConcreteContainerMethodParams },
            { SolidCheckItem.OcpExtraParamNoDefault , SolidDefaultChecks.OcpExtraParamNoDefault },
            { SolidCheckItem.OcpInterfaceSigChange , SolidDefaultChecks.OcpInterfaceSigChange },
            { SolidCheckItem.OcpDeadCode , SolidDefaultChecks.OcpDeadCode },
            { SolidCheckItem.LspExceptionInInheritanceChain , SolidDefaultChecks.LspExceptionInInheritanceChain },
            { SolidCheckItem.LspEmptyOverrideOrVirtual , SolidDefaultChecks.LspEmptyOverrideOrVirtual },
            { SolidCheckItem.LspDummyImplementation , SolidDefaultChecks.LspDummyImplementation },
            { SolidCheckItem.LspConcretionTypeChecking , SolidDefaultChecks.LspConcretionTypeChecking },
            { SolidCheckItem.LspMaskedConcretionTypeChecking , SolidDefaultChecks.LspMaskedConcretionTypeChecking }
        };

        static List<SolidProfile> profiles;

        public static void EditSolidProfile(string path = null)
        {
            var profile = JsonHelper.LoadAs<SolidProfile>(path ?? SolidProfilePath);
        }

        public static SolidReport CheckAssemblies(string filter="")
        {
            var report = new SolidReport(checkProvider);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            profiles = assemblies.Where(ass =>
            {
                var assPath = ass.GetName().CodeBase.SplitByAny("/", "\\").Last();
                var realPath = $"./{assPath}";
                return File.Exists(realPath) && ConsoleHelper.GetKey($"{assPath} [Y]es/[N]o: ", ConsoleKey.Y, ConsoleKey.N) == ConsoleKey.Y;
            }).Select(ass => new SolidProfile(ass)).ToList();

            JsonHelper.SaveAs(profiles, "../../../../kata-solid.json");
            foreach (var p in profiles)
            {
                File.AppendAllLines("../../../solid.log", new[] { $"{DateTime.Now:G} - Creating checks for assembly: {p.Assembly.GetName().Name}" });
                Console.WriteLine($"{DateTime.Now:G} - Creating checks for assembly: {p.Assembly.GetName().Name}");
                var profileItems = p.Items.Where(spi => spi.DefinedType.FullName.Contains(filter)).ToList();
                foreach(var spi in profileItems)
                {
                    var result = CheckType(spi);
                    report.AddItem(result);
                }
            }

            if (ConsoleHelper.GetKey("Run checks now? [Y]es/[N]o? ", ConsoleKey.Y, ConsoleKey.N) == ConsoleKey.Y)
            {
                foreach(SolidResult item in report)
                {
                    foreach(SolidCheck check in item.Checks)
                    {
                        check.Run(item.TypeProfile.DefinedType);
                    }
                }
            }
        
            return report;
        }

        public static SolidReport CheckFolder(string path = "../../../..", bool recursive = true, SolidReport activeReport = null)
        {
            var report = activeReport ?? new SolidReport(checkProvider);
            var folders = new List<string>(Directory.GetDirectories(path));
            var files = new List<string>(Directory.GetFiles(path, "*.cs"));
            foreach (var srcFile in files)
            {
                report.AddItem(CheckFile(new SolidProfileItem(srcFile)));
            }
            foreach (var folder in folders)
            {
                CheckFolder(folder, recursive, report);
            }
            return report;
        }

        private static SolidResult CheckType(SolidProfileItem profile)
        {
            var result = new SolidResult(profile);
            // the checks go SIDOL, not SOLID
            File.AppendAllLines("../../../solid.log", new[] { $"{DateTime.Now:G} - Creatings checks for {profile.DefinedType.Name}" });
            Console.WriteLine($"{DateTime.Now:G} - Creating checks for {profile.DefinedType.Name}");
            foreach (SolidPrinciple p in Enum.GetValues(typeof(SolidPrinciple)))
            {
                var checkItems = EnumHelper.GetValuesWithFlag<SolidCheckItem, SolidPrinciple>(p);
                foreach(var i in checkItems)
                {
                    var check = new SolidCheck(p, string.Empty, i, defaultCheckList[i]);
                    result.Checks.Add(check);
                }
            }
            return result;
        }

        private static SolidResult CheckFile(SolidProfileItem profile)
        {
            var csText = File.ReadAllText(profile.FilePath);
            var braceBodies = csText.SplitByAny("{","}",";", "(",")","<",">");
            foreach(var bb in braceBodies)
                Console.WriteLine(bb);
            return new SolidResult(profile);
        }
    }
}
