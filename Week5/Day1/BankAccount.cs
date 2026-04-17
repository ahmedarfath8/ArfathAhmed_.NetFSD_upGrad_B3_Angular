namespace Practice
{
    internal class Program
    {
        class BankAccount
        {

            private String _acctNumber;
            private decimal _acctBalance;

            public BankAccount(String acctNumber, decimal acctBalance = 0)
            {
                AcctNumber = acctNumber;
                AcctBalance = acctBalance;  
            }
            public String AcctNumber
            {
                get { return _acctNumber; }
                set {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentNullException("Account Number cannot be empty");
                    }
                    _acctNumber = value; 
                }
            }
            public decimal AcctBalance
            {
                get { return _acctBalance; }
                set {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Balance cannot be nagative");
                    }
                    _acctBalance = value;
                }
            }

            public void Deposite(decimal amount) { 
                if(amount <= 0)
                {
                    throw new ArgumentOutOfRangeException("Amount Cant Be Deposited");
                }
                String accDeatailHidden = "XXXX" + AcctNumber.Substring(4);
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                Console.WriteLine($"Acct {accDeatailHidden} Credited for Rs {amount} on {today}; Avl Balance Rs {AcctBalance.ToString("F2")} Not you? Call 18001800 ");
                AcctBalance += amount;
            }
            public void Withdraw(decimal amount) {
                if(AcctBalance <= amount || AcctBalance==0)
                {
                    throw new ArgumentOutOfRangeException("Insufficient Fund");
                }
                String accDeatailHidden = "XXXX" + AcctNumber.Substring(4);
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                Console.WriteLine($"Acct {accDeatailHidden} Debited for Rs {amount} on {today}; Avl Balance Rs {AcctBalance.ToString("F2")} Not you? Call 18001800 ");
                AcctBalance -= amount;

            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome ....");
            Console.WriteLine();
            BankAccount Acc1 = new BankAccount("001001001", 4000m);
            Acc1.Deposite(30000);
            Acc1.Withdraw(2000);
            Console.ReadLine();
        }
    }
}
