using g4m4nez.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace g4m4nez.BusinessLayer
{
    public struct Transaction
    {
        private Money _amount;
        public Guid User { get; }
        public Money Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public Money.Currencies Currency
        {
            get => _amount.Currency;
            set => _amount.Currency = value;
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        private List<string> _attachments;
        public List<string> Attachments
        {
            get => _attachments;
            set => _attachments = value;
        }

        private Category _category;
        public Category TransactionCategory
        {
            get => _category;
            set => _category = value;
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public Transaction(Guid user, Money amount, string description, Category category, DateTime date)
        {
            User = user;
            _amount = amount;
            _description = description;
            _category = category;
            _date = date;
            _attachments = new List<string>();
        }

        [JsonConstructor]
        public Transaction(Guid user, Money amount, string description, Category transactionCategory, DateTime date, List<string> attachments)
        {
            User = user;
            _amount = amount;
            _description = description;
            _category = transactionCategory;
            _date = date;
            _attachments = attachments;
        }
    }
}