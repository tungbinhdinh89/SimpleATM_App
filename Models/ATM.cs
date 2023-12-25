namespace SimpleATM_App.Model;

public class ATM
{
    private List<Card> Cards { get; set; } = [];
    private Card? CurrentCard;

    public ATM(List<Card> Cards)
    {
        this.Cards.AddRange(Cards);
    }

    public bool IsValidCardNumber(string cardNumber)
    {
        var matchingCard = Cards.SingleOrDefault(x => x.CardNumber == cardNumber);
        if (matchingCard is null)
        {
            return false;
        }

        CurrentCard = matchingCard;
        return true;
    }
}