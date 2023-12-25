// namespace SimpleATM_App.Model;

// public class Card
// {
//     public string CardNumber { get; set; } = null!;
//     public string Pin { get; set; } = null!;
//     public decimal Balance { get; set; }

//     public List<Transaction> Transactions { get; set; } = [];
// }
namespace SimpleATM_App.Model;

public class Card
{
    public string CardNumber { get; set; } = null!;
    public string Pin { get; set; } = null!;
    public decimal Balance { get; set; }

    public List<Transaction> Transactions { get; set; } = [];
}

public class Transaction
{
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
}