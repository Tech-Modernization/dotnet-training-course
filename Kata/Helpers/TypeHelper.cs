using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Helpers
{
    public class TypeHelper
    {
        public static List<string> ImplementersOf<T>()
        {
            var t = typeof(T);
            if (!t.IsInterface)
                return null;

            return t.Assembly.DefinedTypes
                .Where(c => c.ImplementedInterfaces.Contains(t) && !c.IsAbstract)
                .Select(c => c.FullName)
                .OrderBy(c => c)
                .ToList();
        }
        public static List<string> ChildrenOf<T>()
        {
            var t = typeof(T);
            if (!t.IsClass)
                return null;

            return t.Assembly.DefinedTypes.Where(t => t.IsSubclassOf(t) && !t.IsAbstract).Select(t => t.FullName).ToList();
        }
    }
}
