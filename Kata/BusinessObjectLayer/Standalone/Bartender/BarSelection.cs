using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace BusinessObjectLayer.Bartender
{
    public class BarSelection : MenuSelectionBase
    {
        public override void Add(MenuSelectionItemBase item)
        {
            Items.Add(item);
        }
    }
}
