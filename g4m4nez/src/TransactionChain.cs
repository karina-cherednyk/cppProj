using g4m4nez.Models;
using System;
using System.Collections.Generic;

namespace g4m4nez.BusinessLayer
{
    public class TransactionChain
    {
        // Heap of binary search tree would be a better choice
        // Since it'd provide us with transactions sorted by date
        private readonly List<Transaction> transactions;
        public List<Transaction> Transactions => transactions;

        private readonly Money.Currencies currency;
        public Money.Currencies Currency => currency;

        private Money currentAmount;
        public Money CurrentAmount => currentAmount;

        public Money MonthlyChange(bool positive, int months)
        {
            DateTime PreviousDate = DateTime.Now.AddMonths(-months);
            Money amount = new Money(0, Currency);
            foreach (Transaction transaction in Transactions)
            {
                if (transaction.Date > PreviousDate && 
                    ((transaction.Amount.Amount > 0 && positive) 
                    || (transaction.Amount.Amount < 0 && !positive)))
                {
                    // Math.Abs would make sense if Amount wasn't a Money object
                    if (positive)
                    {
                        amount += transaction.Amount;
                    }
                    else
                    {
                        amount -= transaction.Amount;
                    }
                }
            }
            return amount;
        }
        public Money MonthIncome
        {
            get
            {
                return MonthlyChange(true, 1);
            }
        }
        public Money MonthExpences
        {
            get
            {
                return MonthlyChange(false, 1);
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction.Currency != Currency)
            {
                throw new System.ArgumentException("Can't add transaction with different currency");
            }
            currentAmount += transaction.Amount;
            Transactions.Add(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            currentAmount -= transaction.Amount;
            if (!Transactions.Remove(transaction))
            {
                throw new System.MissingMemberException("Transaction was not found");
            }
        }

        public TransactionChain(Money.Currencies currency)
        {
            this.currency = currency;
            currentAmount = new(0, currency);
            transactions = new();
        }

        public List<Transaction> GetLastNTransactions(int n)
        {
            int num = Transactions.Count - 1;
            List<Transaction> result = new();
            for (int i = num; i >= 0 && i >= num - n; --i)
            {
                result.Add(Transactions[i]);
            }
            return result;
        }

        public List<Transaction> GetFromIndex(int index)
        {
            int num = Transactions.Count - 1;
            if (index > num)
            {
                throw new System.IndexOutOfRangeException("There are not enough elements");
            }
            return Transactions.GetRange(index, num);
        }
    }
}