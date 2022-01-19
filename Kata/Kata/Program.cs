using System;
using System.Linq;
using System.Reflection;
using BusinessObjectLayer.Progressive.OnlineShop.V2.Part5;
using Helpers;
using PresentationLayer;

namespace Kata
{
    public class Program
    {

        static void Main(string[] args)
        {
            var idemoImplementers = typeof(IDemo).Assembly.GetTypes()
                .Where(t => typeof(IDemo).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructors().Any(ci => ci.GetParameters().Length == 0))
                .Select(t => t)
                .OrderBy(t => t.Name)
                .ToDictionary(t => t.FullName);

            var keyFuncMap = MenuHelper.DefaultKeyFunctionMap;

            var typeName = string.Empty;
            while (true)
            {
                typeName = MenuHelper.FilterMenu(idemoImplementers.Keys.ToList(), null, keyFuncMap, "Select by index or start typing to filter: ");
                if (string.IsNullOrEmpty(typeName)) break;
                Run(idemoImplementers[typeName]);
                Console.Write("---- Any key to return to menu ----");
                Console.ReadKey();
            }
        }
        static void Run(Type t)
        {
            var ass = Assembly.GetAssembly(t);
            var inst = ass.CreateInstance(t.FullName);
            t.GetMethod("Run").Invoke(inst, null);
            return;
        }
    }
}