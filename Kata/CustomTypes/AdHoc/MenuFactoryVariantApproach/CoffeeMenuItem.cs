using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryVariant
{
    public class CoffeeMenuItem : DrinkMenuItem
    {
        public TariffVariantDictionary<CoffeeVariant> Tariff = new TariffVariantDictionary<CoffeeVariant>();
        public CoffeeMenuItem()
        {
            variantHeading = "Our coffees:";
            var vb = new DrinkVariantBuilder<CoffeeVariant>(getBasePrice, getSizePriceOffset, isValidCombo);
            vb.CreateVariants(Tariff);
        }

        public override bool HasVariants => Tariff.Count > 0;

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

        public bool isValidCombo(CoffeeVariant cv, SizeVariant sv)
        {
            if (sv == 0) return true;

            var valEspresso = new List<SizeVariant> { SizeVariant.Single, SizeVariant.Double };
            var valRest = new List<SizeVariant> { SizeVariant.Tall, SizeVariant.Grande, SizeVariant.Vente };
            return cv == CoffeeVariant.Espresso ? valEspresso.Contains(sv) : valRest.Contains(sv);
        }

        public decimal? getBasePrice(CoffeeVariant cv)
        {
            switch (cv)
            {
                case CoffeeVariant.Mocha:
                    return 3.20M;
                case CoffeeVariant.Americano:
                    return 2.20M;
                case CoffeeVariant.Latte:
                    return 2.80M;
                case CoffeeVariant.Cappuccino:
                    return 2.60M;
                case CoffeeVariant.Espresso:
                    return 2.00M;
                default:
                    throw new NotImplementedException($"{cv} not priced yet");
            }
        }

        public decimal? getSizePriceOffset(SizeVariant sv)
        {
            switch (sv)
            {
                case SizeVariant.Tall:
                    return 0M;
                case SizeVariant.Grande:
                    return 0.85M;
                case SizeVariant.Vente:
                    return 1.70M;
                case SizeVariant.Single:
                    return 0M;
                case SizeVariant.Double:
                    return 1M;
                default:
                    return null;
            }
        }
    }
}