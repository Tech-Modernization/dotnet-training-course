using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKata.CustomTypes
{
    public enum VolumeTariff { GlassSmall, GlassLarge, Bottle, Pint, Half, Shot, Single, Double, Standard };
    public class VolumeTariffDictionary : Dictionary<VolumeTariff, decimal>
    {
        public VolumeTariffDictionary(params VolumeTariff[] tariff)
        {
            foreach(var t in tariff)
            {
                this.Add(t, 0.0M);
            }
        }

        public bool SetTariff(VolumeTariff tariff, decimal price, bool addIfMissing = false)
        {
            if (this.ContainsKey(tariff))
            {
                if (addIfMissing)
                {
                    this.Add(tariff, price);
                    return true;
                }

            }

            this[tariff] = price;
            return false;
        }
    }
}
