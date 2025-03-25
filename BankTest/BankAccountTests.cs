using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        #region Тесты для метода Debit

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44; 
            BankAccount account = new BankAccount("Test", beginningBalance);

            account.Debit(debitAmount);

            Assert.AreEqual(expected, account.Balance, 0.001);
        }

        [TestMethod]
        public void Debit_WhenAmountIsNegative_ShouldThrow()
        {
            double debitAmount = -100;
            BankAccount account = new BankAccount("Test", 100);

            try
            {
                account.Debit(debitAmount);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, BankAccount.DebitAmountLessThanZeroMessage);
            }
        }

        [TestMethod]
        public void Debit_WhenAmountExceedsBalance_ShouldThrow()
        {
            double debitAmount = 200;
            BankAccount account = new BankAccount("Test", 100);

            try
            {
                account.Debit(debitAmount);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        #endregion

        #region Тесты для метода Credit

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 100;
            double creditAmount = 50;
            double expected = 150;
            BankAccount account = new BankAccount("Test", beginningBalance);

            account.Credit(creditAmount);

            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void Credit_WhenAmountIsNegative_ShouldThrow()
        {
            double creditAmount = -50;
            BankAccount account = new BankAccount("Test", 100);

            try
            {
                account.Credit(creditAmount);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, "Credit amount is less than zero");
            }
        }

        #endregion
    }
}