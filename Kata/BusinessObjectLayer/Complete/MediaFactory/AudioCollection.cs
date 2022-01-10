﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MediaFactory
{
    // Concrete Creator role
    public class AudioCollection : MediaCollectionBase
    {
        protected override void CreateItems()
        {
            Items.Add(new AudioItem());
            Items.Add(new AudioItem());
            Items.Add(new AudioItem());
        }
    }
}
