using SimpleATM_App.Model;

// generate five transaction;
Random random = new Random();

var transactions = new List<Transaction>(); // Create a list to hold transactions for each card

for (int i = 0; i < 5; i++)
{
    DateTime startDate = DateTime.Now.AddYears(-1);
    int range = (DateTime.Today - startDate).Days;
    DateTime transactionDate = startDate.AddDays(random.Next(range));

    decimal amount = (decimal)(random.NextDouble() * 1000);

    string[] transactionTypes = { "Deposit", "Withdrawal" };
    string type = transactionTypes[random.Next(transactionTypes.Length)];

    transactions.Add(new Transaction
    {
        TransactionDate = transactionDate,
        Amount = amount,
        Type = type
    });
}

ATM atm = new([
new Card{CardNumber = "374245455400126", Pin = "1111", Balance = 500, Transactions = transactions},
new Card{CardNumber = "378282246310005", Pin = "2222", Balance = 500, Transactions = transactions},
new Card{CardNumber = "5011054488597827", Pin = "3333", Balance = 500, Transactions = transactions},
new Card{CardNumber = "6271701225979642", Pin = "4444", Balance = 500, Transactions = transactions},
new Card{CardNumber = "5425233430109903", Pin = "5555", Balance = 500,Transactions = transactions},
]);

Console.Write("Enter your card number: ");
var cardNumber = Console.ReadLine();

if (atm.IsValidCardNumber(cardNumber!) == false)
{
    Console.WriteLine("Card does not exist. Exit!");
    return;
}

Console.Write("Enter your pin number: ");
var pinNumber = Console.ReadLine();
if (atm.IsValidPinNumber(pinNumber!) == false)
{
    Console.WriteLine("Pin is not valid. Exit!");
    return;
}

DisplayOption();
var num = GetNumber("");

Action(num, atm);


static void DisplayOption()
{
    Console.WriteLine(@"
    Choose your option:
    1. Check balance.
    2. Withdraw.
    3. Deposit.
    4. Check last five transaction.
    5. Change Pin
    6. Exit.
    ");
}

static void Action(int num, ATM atm)
{
    switch (num)
    {
        case 1:
            {
                Console.WriteLine($"Card balance is: {atm.GetBalance()}");
                break;
            }
        case 2:
            {
                var amount = GetNumber("How much cash do you want to withdraw");
                Console.WriteLine($"You withdraw {amount}, Card balance is {atm.Withdraw(amount)} now");
                break;
            }
        case 3:
            {
                var amount = GetNumber("How much cash do you want to deposit");
                Console.WriteLine($"You deposit {amount}, Card balance is {atm.Deposit(amount)} now");
                break;
            }
        case 4:
            {
                Console.WriteLine($"Your last five transactions is: ");
                var transactions = atm.LastFiveTransaction();
                foreach (var t in transactions)
                {
                    Console.WriteLine($@"
                                        {t.TransactionDate}
                                        {t.Amount}
                                        {t.Type}
                                    ");

                }
                Console.WriteLine("tung");
                break;
            }
        case 5:
            {
                Console.Write("Enter your new Pin: ");
                var newPin = Console.ReadLine();
                if (!atm.ChangePinNumber(newPin!))
                {
                    Console.WriteLine("New Pin match with old pin. Exit!");
                }
                else
                {
                    Console.WriteLine($"Your Pin card have change.");
                }
                break;
            }
        case 6:
            {
                break;
            }
        default:
            {
                Console.WriteLine("Invalid Option");
                break;
            }
    }
}

static int GetNumber(string msg)
{
    Console.WriteLine(msg);
    bool isParse = int.TryParse(Console.ReadLine(), out int num);
    return num;
}

