using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.MediaFactory
{
    // Concrete Creator role
    public class VideoCollection : MediaCollectionBase
    {
        protected override void CreateItems()
        {
            Items.Add(new VideoItem());
            Items.Add(new VideoItem());
            Items.Add(new VideoItem());
        }
    }
}
