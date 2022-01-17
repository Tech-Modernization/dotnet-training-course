using Helpers.Extensions;
using System.Linq;
using System.Reflection;
using System;

namespace Helpers
{
    public class SolidCheck : ISolidCheck
    {
        public virtual SolidPrinciple Principle { get; internal set; }
        public virtual string GuideText { get; internal set; }
        public virtual SolidCheckItem Item { get; internal set; }
        public virtual SolidSeverity Status { get; internal set; }
        protected virtual Func<Type, SolidSeverity> Checker { get; set; }
        public SolidCheck(SolidPrinciple principle, string text, SolidCheckItem item, Func<Type, SolidSeverity> checker=null)
        {
            Principle = principle;
            GuideText = text;
            Item = item;
            Checker = checker;
            Status = checker == null ? SolidSeverity.CheckUndefined : SolidSeverity.CheckNotRun;
        }
        public override string ToString()
        {
            return $"Status: {Status}, Principle: {Principle}, Check: {Item}";
        }
        public SolidSeverity Run(Func<Type, SolidSeverity> checker, Type t)
        {
            Checker = checker;
            return Run(t);
        }
        public SolidSeverity Run(Type t)
        {
            Status = Checker(t);
            return Status;
        }
    }
}