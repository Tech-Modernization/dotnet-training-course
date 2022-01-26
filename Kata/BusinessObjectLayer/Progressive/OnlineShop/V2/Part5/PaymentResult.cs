namespace BusinessObjectLayer.Progressive.OnlineShop.V2.Part5
{
    // Resp: Encaps result of payment
    public enum PaymentResult
    {
        Success = 1,
        CreditLimitExceeded,
        AuthenticationFailed,
        CustomerCancelled
    }
}