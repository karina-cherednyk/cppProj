using System.Collections.Generic;
using System;
namespace BusinessLayer
{
    public class Transaction
    {
        private Money amount;
        public Money Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Money.Currencies Currency
        {
            get { return amount.Currency; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private List<string> attachments;
        public List<string> Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }

        private Category category;
        public Category TransactionCategory
        {
            get { return category; }
            set { category = value; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Transaction(Money amount, string description, Category category, DateTime date)
        {
            Amount = amount;
            Description = description;
            TransactionCategory = category;
            Date = date;
        }

        public Transaction(Money amount, string description, Category category, DateTime date, List<string> attachments)
        {
            Amount = amount;
            Description = description;
            TransactionCategory = category;
            Date = date;
            Attachments = attachments;
        }
    }
}