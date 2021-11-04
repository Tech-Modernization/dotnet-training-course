using System.Collections.Generic;

namespace Kata.CustomTypes.PublicationFactory
{
    public abstract class PressBase
    {
        private List<PublicationBase> publications = new List<PublicationBase>();
        public List<PublicationBase> Publications { get => publications; }
        public PressBase()
        {
            this.CreatePublications();
        }
        protected abstract void CreatePublications();
    }
}
