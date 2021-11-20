using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Helpers
{
    public class TypeHelper
    {
        public static T New<T>(Type t)
        {
            return (T) New(t, typeof(T));
        }
        public static object New(Type concreteType, Type abstractType)
        {
            return abstractType.IsAssignableFrom(concreteType) ? concreteType.Assembly.CreateInstance(concreteType.FullName) : default;
        }
        public static List<Type> ImplementersOf<T>()
        {
            return ImplementersOf(typeof(T));
        }
        public static List<Type> ImplementersOf(Type t)
        {
            if (!t.IsInterface)
                return null;

            return t.Assembly.DefinedTypes
                .Where(c => c.ImplementedInterfaces.Contains(t) && !c.IsAbstract)
                .Select(dt => dt.AsType())
                .OrderBy(c => c.Name)
                .ToList();
        }
        public static List<Type> ChildrenOf<T>()
        {
            return ChildrenOf(typeof(T));
        }
        public static List<Type> ChildrenOf(Type t)
        {
            if (!t.IsClass)
                return null;

            return t.Assembly.DefinedTypes.Where(dt => dt.IsSubclassOf(t) && !dt.IsAbstract).Select(dt => dt.AsType()).ToList();
        }
    }
}