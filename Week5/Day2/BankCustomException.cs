using System;


namespace Practice
{
    // 3. Custom Exception Class
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // 1. BankAccount Class
    class BankAccount
    {
        private double balance;

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        // 2. Withdraw Method
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                // 4. Throw custom exception
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawal successful! Remaining balance: {balance}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double amount = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(balance);

            try
            {
                // 5. Call method (exception may occur here)
                account.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                // 6. Always executes
                Console.WriteLine("Transaction completed.");
            }
        }
    }
}