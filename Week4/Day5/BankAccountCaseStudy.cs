using System.Diagnostics;

namespace Practice
{
    internal class Program
    {
        internal class BankAccount
        {
            private decimal _balance;
            private string _accountNumber;
            private string _accountHolder;

            public decimal Balance
            {
                get
                {
                    return _balance;
                }
            }

            public string AccountNumber
            {
                get
                {
                    return _accountNumber;
                }
            }

            public string AccountHolder
            {
                get { return _accountHolder; }
                set
                {

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Account Holder Name cannot be empty");
                    }

                    _accountHolder = value;
                }
            }


            public BankAccount(string accountNumber, string accountHolder, decimal balance = 0)
            {

                if (string.IsNullOrEmpty(accountNumber))
                {
                    throw new ArgumentNullException("Account Number cannot be empty");
                }

                if (string.IsNullOrEmpty(accountHolder))
                {
                    throw new ArgumentNullException("Account Holder Name cannot be empty");
                }

                if (balance < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance cannot be nagative");
                }


                _accountNumber = accountNumber;
                _accountHolder = accountHolder;
                _balance = balance;
            }



            public void Deposit(decimal amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("Amount cannot be nagative");
                }

                _balance += amount;

                String accDeatailHidden = "XXXX" + _accountNumber.Substring(4);
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                Console.WriteLine($"Acct {accDeatailHidden} Credited for Rs {amount} on {today}; Avl Balance Rs {_balance.ToString("F2")} Not you? Call 18001800 ");

            }


            public bool Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Amount cannot be zero or lessthan zero");
                    return false;
                }

                if (amount > _balance)
                {
                    Console.WriteLine("Unabel to Withdraw Due To Insufficient Balance");
                    return false;
                }

                _balance -= amount;

                String accDeatailHidden = "XXXX"+_accountNumber.Substring(4);
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                Console.WriteLine($"Acct {accDeatailHidden} Debited for Rs {amount} on {today}; Avl Balance Rs {_balance.ToString("F2")} Not you? Call 18001800 ");

                return true;

            }
            static void Main(string[] args)
            {
                var acc = new BankAccount("LT987654", "Jonas", 1200m);
                acc.Deposit(30000);
                acc.Withdraw(2000);
                Console.ReadLine();
            }

        }
    }
}