using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.HiFiFactory
{
    public abstract class HomeStereoBase
    {
        // 1. backing store
        private List<ComponentBase> components = new List<ComponentBase>();
        // 2. property
        public List<ComponentBase> Components { get { return components; } }
        // 3. constructor
        public HomeStereoBase()
        {
            CreateComponents();
        }
        // 4. factory method
        protected virtual void CreateComponents()
        {
            Components.Add(new Amplifier());
            Components.Add(new Speakers());
        }
    }
}
