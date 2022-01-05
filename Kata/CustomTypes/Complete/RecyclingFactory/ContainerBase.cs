using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.RecyclingFactoryDone
{
    public abstract class ContainerBase
    {
        private List<MaterialBase> materials = new List<MaterialBase>();
        public List<MaterialBase> Materials => materials;
        public ContainerBase()
        {
            CreateMaterials();
        }
        protected abstract void CreateMaterials();
    }
}
