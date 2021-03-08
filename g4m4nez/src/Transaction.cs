using System.Collections.Generic;
using System;
namespace BusinessLayer
{
    public struct Transaction
    {
        private Money _amount;
        public User User { get; }
        public Money Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public Money.Currencies Currency
        {
            get { return _amount.Currency; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private List<string> _attachments;
        public List<string> Attachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }

        private Category _category;
        public Category TransactionCategory
        {
            get { return _category; }
            set { _category = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Transaction(User user, Money amount, string description, Category category, DateTime date)
        {
            User = user;
            _amount = amount;
            _description = description;
            _category = category;
            _date = date;
            _attachments = new List<String>();
        }

        public Transaction(User user, Money amount, string description, Category category, DateTime date, List<string> attachments)
        {
            User = user;
            _amount = amount;
            _description = description;
            _category = category;
            _date = date;
            _attachments = attachments;
        }
    }
}