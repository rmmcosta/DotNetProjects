using NUnit.Framework;
using Bank;
using System;

namespace BankTest
{
    public class Tests
    {

        private BankAccount bankAccount;
        private const string BANK_ACCOUNT_NAME = "Rmmcosta Bank Account 1";
        private const double INITIAL_BALANCE = 100.0;

        [SetUp]
        public void Setup()
        {
            bankAccount = new BankAccount(BANK_ACCOUNT_NAME, INITIAL_BALANCE);
        }

        [Test]
        public void CeckName()
        {
            Assert.AreEqual(BANK_ACCOUNT_NAME, bankAccount.Name);
        }

        [Test]
        public void CheckInitialBalance()
        {
            Assert.AreEqual(INITIAL_BALANCE, bankAccount.Balance);
        }

        [Test]
        public void DebitEverything()
        {
            bankAccount.Debit(INITIAL_BALANCE);
            Assert.AreEqual(0, bankAccount.Balance);
        }

        [Test]
        public void CreditEverything()
        {
            double balance = bankAccount.Balance;
            bankAccount.Credit(INITIAL_BALANCE);
            Assert.AreEqual(balance + INITIAL_BALANCE, bankAccount.Balance);
        }

        [Test]
        public void DebitMoreThanBalance()
        {
            Assert.Throws<ArgumentException>(() => bankAccount.Debit(bankAccount.Balance + 1));
        }

        [Test]
        public void CreditNegativeThrowsException()
        {
            Assert.Throws<ArgumentException>(() => bankAccount.Credit(-10));
        }

        [Test]
        public void DebitNegativeThrowsException()
        {
            Assert.Throws<ArgumentException>(() => bankAccount.Debit(-10));
        }
    }
}