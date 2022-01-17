using Helpers.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class SolidResult : IEnumerable
    {
        public SolidProfileItem TypeProfile { get; internal set; }
        public List<SolidCheck> Checks { get; internal set; }
        public SolidResult(SolidProfileItem profile)
        {
            TypeProfile = profile;
            Checks = new List<SolidCheck>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"SOLID Checklist Result for: {TypeProfile.DefinedType.FullName} {TypeProfile.EntityType}\n{"--------".Repeat(10)}");
            foreach(var check in Checks)
            {
                sb.AppendLine($"{check}");
            }
            return sb.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Checks).GetEnumerator();
        }
    }
}