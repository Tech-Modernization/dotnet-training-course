using System;
using System.Collections.Generic;

namespace Helpers
{
    public class SolidProfileItem
    {
        public string FilePath { get; }
        public Type DefinedType { get; }
        public string EntityType { get; }
        public string Responsibility { get; internal set; }
        public List<SolidProfileItem> Dependencies { get; }
        public List<SolidProfileItem> Dependents { get; }
        public SolidProfileItem(string filePath)
        {
            FilePath = FilePath;
        }
        public SolidProfileItem(Type typeObject, string generalType, string responsibility)
        {
            DefinedType = typeObject;
            EntityType = generalType;
            Responsibility = responsibility;
            Dependencies = new List<SolidProfileItem>();
            Dependents = new List<SolidProfileItem>();
        }

        public void EditDependencies()
        {

        }
        public void EditDependents()
        {

        }
    }
}