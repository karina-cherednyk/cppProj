using System.Collections.Generic;
using System;
namespace BusinessLayer
{
    public class TransactionChain
    {

        // Heap of binary search tree would be a better choice
        // Since it'd provide us with transactions sorted by date
        private List<Transaction> transactions;
        public List<Transaction> Transactions
        {
            get { return transactions; }
        }

        private Money.Currencies currency;
        public Money.Currencies Currency
        {
            get { return currency; }
        }

        private Money currentAmount;
        public Money CurrentAmount
        {
            get { return currentAmount; }
        }

        public Money MonthIncome
        {
            get {
                DateTime PreviousMonth = DateTime.Now.AddMonths(-1);
                Money amount = new Money(0, Currency);
                foreach (Transaction transaction in Transactions)
                {
                    if (transaction.Date > PreviousMonth && transaction.Amount.Amount > 0)
                    {
                        amount += transaction.Amount;
                    }
                }
                return amount; 
            }
        }

        public Money MonthExpences
        {
            get
            {
                DateTime PreviousMonth = DateTime.Now.AddMonths(-1);
                Money amount = new Money(0, Currency);
                foreach (Transaction transaction in Transactions)
                {
                    if (transaction.Date > PreviousMonth && transaction.Amount.Amount < 0)
                    {
                        amount -= transaction.Amount; // Since we're considering only negative amounts
                    }
                }
                return amount;
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction.Currency != Currency)
            {
                throw new System.InvalidOperationException("Can't add transaction with different currency");
            }
            currentAmount += transaction.Amount;
            Transactions.Add(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            currentAmount -= transaction.Amount;
            Transactions.Remove(transaction);
        }

        public TransactionChain(Money.Currencies currency)
        {
            this.currency = currency;
            currentAmount = new Money(0, currency);
        }
    }
}