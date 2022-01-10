namespace Kata.CustomTypes.Bartender
{
    public enum PaymentResult
    {
        CardTransactionSuccessful = 1,
        ExactMoneyTendered,
        ChangeAccepted,
        CardDeclined,
        CardMachineFault,
        InsufficientCash,
        DrinkPrepaid,
        ChangeChallenged,
        CustomerComplaint,
        BartenderError,
        NotLegalTender
    }
}