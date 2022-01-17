using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;
using Helpers.Extensions;

namespace Helpers
{
    public class SolidProfile : IEnumerable
    {
        public Assembly Assembly { get; internal set; }
        public List<SolidProfileItem> Items { get; }
        public SolidProfile(Assembly assembly)
        {
            Assembly = assembly;
            Items = assembly.GetTypes().Select(t =>
            {
                var entityType = getGeneralType(t);
                if (entityType == null) return null;
                var spi = new SolidProfileItem(t, entityType, "");
                File.AppendAllLines("../../../solid.log", new[] { $"Created {spi.EntityType} profile for {spi.DefinedType.FullName}" });
                return spi;
            }).Where(spi => spi != null).ToList();
        }

        private string getGeneralType(Type t)
        {
            var n = t.Name;
            return n.ContainsAny("AnonType","AnonymousType") || n.StartsWith("<")
                ? null : t.IsInterface
                    ? "Interface"
                    : t.IsClass
                        ? t.IsAbstract
                            ? "Abstract Class"
                            : "Class"
                        : t.IsEnum
                            ? "Enum"
                            : null;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Items).GetEnumerator();
        }
    }
}