using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTypes.MenuFactory
{
    public abstract class MenuItemBase
    {
        public string Name { get; set; }
        public VolumeTariffDictionary Tariff { get; set; }

        public MenuItemBase()
        {
            this.CreateTariff();
        }
    }
}
