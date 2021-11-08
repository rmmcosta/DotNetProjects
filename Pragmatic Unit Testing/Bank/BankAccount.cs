using System;

namespace Bank
{
    public class BankAccount
    {
        private readonly string name;
        private double balance;
        private BankAccount() { }

        public BankAccount(string name, double balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public double Balance => balance;

        public string Name => name;

        public void Debit(double amount)
        {
            if (amount > this.balance || amount < 0)
                throw new ArgumentException();
            else
                this.balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException();
            else
                this.balance += amount;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BankAccount ba = new BankAccount();
        }
    }
}
