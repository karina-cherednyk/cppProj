using g4m4nez.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace g4m4nez.BusinessLayer
{
    public class TransactionChain
    {
        // Heap of binary search tree would be a better choice
        // Since it'd provide us with _transactions sorted by date
        private readonly List<Transaction> _transactions;
        private readonly Money.Currencies _currency;
        private Money _currentAmount;

        public List<Transaction> Transactions => _transactions;
        public Money.Currencies Currency => _currency;

        public Money CurrentAmount => _currentAmount;

        public Money MonthlyChange(bool positive, int months)
        {
            DateTime PreviousDate = DateTime.Now.AddMonths(-months);
            Money amount = new(0, Currency);
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
        
        [JsonIgnore]
        public Money MonthIncome
        {
            get
            {
                return MonthlyChange(true, 1);
            }
        }
        [JsonIgnore]
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
                throw new System.ArgumentException("Can't add transaction with different _currency");
            }
            _currentAmount += transaction.Amount;
            Transactions.Add(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            _currentAmount -= transaction.Amount;
            if (!Transactions.Remove(transaction))
            {
                throw new System.MissingMemberException("Transaction was not found");
            }
        }

        [JsonConstructor]
        public TransactionChain(List<Transaction> transactions, Money.Currencies currency,
                                Money currentAmount)
        {
            _transactions = transactions;
            _currency = currency;
            _currentAmount = currentAmount;
        }


        public TransactionChain(Money.Currencies currency)
        {
            this._currency = currency;
            _currentAmount = new(0, currency);
            _transactions = new();
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

        public List<Transaction> GetFromIndex(int index, int n = 10)
        {
            int num = Transactions.Count - 1; // last index
            if (num < 0)
            {
                return new List<Transaction>();
            }
            if (index > num)
            {
                throw new System.IndexOutOfRangeException("There are not enough elements");
            }
            return Transactions.GetRange(index, Math.Min(index + n, num));
        }
    }
}