using System.IO.Compression;

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
        var matchingCard = Cards.SingleOrDefault(c => c.CardNumber == cardNumber);
        if (matchingCard is null)
        {
            return false;
        }

        CurrentCard = matchingCard;
        return true;
    }

    public bool IsValidPinNumber(string pinNumber)
    {
        var matchPin = Cards.SingleOrDefault(x => x.Pin == pinNumber);
        if (matchPin is null)
        {
            return false;
        }

        CurrentCard = matchPin;
        return true;
    }

    public decimal GetBalance()
    {
        if (CurrentCard is null)
        {
            throw new Exception("Card does not exist");
        }
        return CurrentCard.Balance;
    }

    public decimal Withdraw(int amount)
    {
        if (CurrentCard is null)
        {
            throw new Exception("Card does not exist");
        }

        if (CurrentCard.Balance <= 0)
        {
            return 0;
        }

        if (CurrentCard.Balance < amount)
        {
            return 0;

        }
        CurrentCard.Balance -= amount;
        CurrentCard.Transactions.Add(
            new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                Type = "Withdraw"
            }
        );

        return CurrentCard.Balance;
    }

    public decimal Deposit(int amount)
    {
        if (CurrentCard is null)
        {
            throw new Exception("Card does not exist");
        }

        CurrentCard.Balance += amount;
        CurrentCard.Transactions.Add(
            new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                Type = "Deposit"
            }
        );

        return CurrentCard.Balance;
    }

    public List<Transaction> LastFiveTransaction()
    {
        if (CurrentCard is null)
        {
            throw new Exception("Card does not exist");
        }
        return CurrentCard.Transactions.Take(5).ToList();
    }

    public bool ChangePinNumber(string newPin)
    {
        if (CurrentCard is null)
        {
            throw new Exception("Card does not exist");
        }
        if (CurrentCard.Pin == newPin)
        {
            return false;
        }
        else
        {
            CurrentCard.Pin = newPin;
            return true;
        }
    }
}
