using System;

namespace BankAccountNS
{
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        // Конструктор по умолчанию (закрытый)
        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName => m_customerName;
        public double Balance => m_balance;

        // Константы для сообщений исключений
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        // Метод списания средств
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            m_balance -= amount; // Исправлено: вычитание вместо сложения
        }

        // Метод пополнения счета
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, "Credit amount is less than zero");
            m_balance += amount;
        }

        // Main для тестирования (оставлен из исходного кода)
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine($"Current balance is ${ba.Balance:F2}");
            Console.ReadLine();
        }
    }
}