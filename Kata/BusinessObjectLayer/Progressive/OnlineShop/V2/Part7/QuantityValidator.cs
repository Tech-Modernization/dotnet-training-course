using Helpers;

namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part7
{
    public class QuantityValidator : IValidator<int>
    {
        public bool IsValid(int arg)
        {
            return arg > 0;
        }
    }
}