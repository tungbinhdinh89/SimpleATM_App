// namespace SimpleATM_App.Model;

// public class ATM
// {
//     private List<Card> Cards { get; set; } = [];
//     private Card? CurrentCard;

//     public ATM(List<Card> Cards)
//     {
//         this.Cards.AddRange(Cards);
//     }


//     public bool IsValidCardNumber(string cardNumber)
//     {
//         var matchingCard = Cards.SingleOrDefault(c => c.CardNumber == cardNumber);
//         if (matchingCard is null)
//         {
//             return false;
//         }

//         CurrentCard = matchingCard;
//         return true;
//     }

//     public bool IsValidPinNumber(string pinNumber)
//     {
//         var matchPin = Cards.SingleOrDefault(x => x.Pin == pinNumber);
//         if (matchPin is null)
//         {
//             return false;
//         }

//         CurrentCard = matchPin;
//         return true;
//     }
// }

namespace SimpleATM_App.Model;

public class Atm
{
    public Atm(List<Card> cards)
    {
        this.cards.AddRange(cards);
    }

    private List<Card> cards { get; set; } = [];
    private Card? currentCard;

    public bool IsValidCardNumber(string cardNumber)
    {
        var matchingCard = cards.SingleOrDefault(c => c.CardNumber == cardNumber);
        if (matchingCard is null)
        {
            return false;
        }

        currentCard = matchingCard;
        return true;
    }

    public bool IsValidPin(string pin)
    {
        if (currentCard is null)
        {
            throw new Exception("Card does not exist");
        }

        return currentCard.Pin == pin;
    }

    public decimal GetBalance()
    {
        if (currentCard is null)
        {
            throw new Exception("Card does not exist");
        }

        return currentCard.Balance;
    }

    public decimal Widthraw(decimal amount)
    {
        if (currentCard is null)
        {
            throw new Exception("Card does not exist");
        }

        if (amount <= 0)
        {
            return 0;
        }

        if (currentCard.Balance < amount)
        {
            return 0;
        }

        currentCard.Balance -= amount;
        currentCard.Transactions.Add(new Transaction
        {
            TransactionDate = DateTime.Now,
            Amount = amount,
        });

        return currentCard.Balance;
    }
}