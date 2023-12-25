using SimpleATM_App.Model;

ATM atm = new([
new Card{CardNumber = "	374245455400126", Pin = "1111", Balance = 500},
new Card{CardNumber = "	378282246310005", Pin = "2222", Balance = 500},
new Card{CardNumber = "	5011054488597827", Pin = "3333", Balance = 500},
new Card{CardNumber = "	6271701225979642", Pin = "4444", Balance = 500},
new Card{CardNumber = "	5425233430109903", Pin = "5555", Balance = 500},
]);

// Console.WriteLine("Enter your card number: ");
// var cardNumber = Console.ReadLine();
// if (atm.IsValidCardNumber(cardNumber!) == false)
// {
//     System.Console.WriteLine("Card does not exit");
//     return;
// }

System.Console.Write("Enter your card number: ");
var cardNumber = Console.ReadLine();

if (atm.IsValidCardNumber(cardNumber!) == false)
{
    System.Console.WriteLine("Card does not exist. Exit!");
    return;
}
