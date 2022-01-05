using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactory
{
    public delegate bool DrinkVariantSizeComboValidator<T>(T variant1, SizeVariant sv);
    public delegate decimal? BasePriceProvider<T>(T variant1);
    public delegate decimal? SizePriceOffsetProvider(SizeVariant sizeVariant);
    public class DrinkVariantBuilder<T>
    {
        public DrinkVariantSizeComboValidator<T> OnIsValidCombo;
        public BasePriceProvider<T> OnGetBasePrice;
        public SizePriceOffsetProvider OnGetSizePriceOffset;

        public DrinkVariantBuilder(BasePriceProvider<T> basePriceProvider, 
            SizePriceOffsetProvider sizePriceOffsetProvider,
            DrinkVariantSizeComboValidator<T> comboValidator)
        {
            OnGetBasePrice = basePriceProvider;
            OnGetSizePriceOffset = sizePriceOffsetProvider;
            OnIsValidCombo = comboValidator;
        }

        public void CreateVariants(TariffVariantDictionary<T> tariff)
        {
            foreach (var variant in (T[])Enum.GetValues(typeof(T)))
            {
                if (!OnIsValidCombo?.Invoke(variant, 0) ?? false 
                    && isValidCombo(variant, 0)) continue;

                var basePrice = OnGetBasePrice(variant) ?? getBasePrice(variant);

                foreach (var sizeVariant in (SizeVariant[])Enum.GetValues(typeof(SizeVariant)))
                {
                    if (!OnIsValidCombo?.Invoke(variant, sizeVariant) ?? false
                        && isValidCombo(variant, sizeVariant)) continue;

                    var sizeOffset = OnGetSizePriceOffset(sizeVariant) ?? getSizePriceOffset(sizeVariant);
                    if (sizeOffset.HasValue)
                    {
                        var price = basePrice.Value + sizeOffset.Value;
                        var drinkVariant = new DrinkTariffVariant<T>()
                        {
                            DrinkVariant = variant,
                            Size = sizeVariant
                        };

                        tariff.Add(drinkVariant, price);
                    }
                }
            }
        }

        private decimal? getBasePrice(T variant1)
        {
            return null;
        }

        private decimal? getSizePriceOffset(SizeVariant variant2)
        {
            return null;
        }

        private bool isValidCombo(T variant1, SizeVariant variant2)
        {
            return true;
        }
    }
}
