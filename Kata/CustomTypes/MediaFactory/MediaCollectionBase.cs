
using System.Collections.Generic;

namespace CustomTypes.MediaFactory
{
    // Playing the Creator in the Factory Pattern...
    public abstract class MediaCollectionBase
    {
        private List<MediaItemBase> items = new List<MediaItemBase>();
        public List<MediaItemBase> Items { get { return items; } }

        public MediaCollectionBase()
        {
            CreateItems();
        }

        protected abstract void CreateItems();
    }
}
