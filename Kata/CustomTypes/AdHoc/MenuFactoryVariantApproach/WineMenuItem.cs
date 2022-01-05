using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryVariant
{
    public class WineMenuItem : DrinkMenuItem
    {
        public TariffVariantDictionary<WineVariant> Tariff = new TariffVariantDictionary<WineVariant>();
        public WineMenuItem()
        {
            variantHeading = "Wine list";
            var vb = new DrinkVariantBuilder<WineVariant>(getBasePrice, getSizePriceOffset, isValidCombo);
            vb.CreateVariants(Tariff);
        }

        public override bool HasVariants => Tariff.Count > 0;


        public bool isValidCombo(WineVariant wv, SizeVariant sv)
        {
            var valWines = new List<WineVariant>()
            {
                WineVariant.Grenache, WineVariant.Zinfandel, WineVariant.CheninBlanc, 
                WineVariant.Rioja, WineVariant.PinotGrigio
            };
            return valWines.Contains(wv);
        }

        public decimal? getBasePrice(WineVariant cv)
        {
            switch (cv)
            {
                case WineVariant.Grenache:
                    return 4.50M;
                case WineVariant.PinotGrigio:
                    return 4.85M;
                case WineVariant.Zinfandel:
                    return 5.25M;
                case WineVariant.CheninBlanc:
                    return 5.60M;
                case WineVariant.Rioja:
                    return 7.00M;
                default:
                    throw new NotImplementedException($"{cv} not priced yet");
            }
        }

        public decimal? getSizePriceOffset(SizeVariant sv)
        {
            switch (sv)
            {
                case SizeVariant.SmallGlass:
                    return 0M;
                case SizeVariant.LargeGlass:
                    return 4.85M;
                case SizeVariant.Bottle:
                    return 9.90M;
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(variantHeading);
            foreach (var variant in Tariff)
            {
                sb.AppendLine($"{variant.Key,-25}{variant.Value:C}");
            }
            return sb.ToString();
        }
    }
}
