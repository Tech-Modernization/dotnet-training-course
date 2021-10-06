namespace DemoKata.CustomTypes
{
    public abstract class DrinkBase
    {
        protected DrinkType drinkType;
        protected VolumeTariff tariff;

        public DrinkBase()
        {
            this.CreateTariff();
        }

        protected void CreateTariff()
        {
            tariff = new VolumeTariffDictionary();
        }
    }
}