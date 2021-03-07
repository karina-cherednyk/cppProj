using System;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class Money
    {
        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public enum Currencies
        {
            USD, UAH, EUR
        }

        private static Dictionary<Currencies, string> CurrencyNames = new Dictionary<Currencies, string> {
            {Currencies.USD, "USD"},
            {Currencies.UAH, "UAH" },
            {Currencies.EUR, "EUR" }
        };

        private Currencies currency;
        public Currencies Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public Money(decimal amount, Currencies currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator+(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new System.InvalidOperationException("Can't add different currencies");
            }
            else
            {
                return new Money(a.Amount + b.Amount, a.Currency);
            }
        }

        public static Money operator-(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new System.InvalidOperationException("Can't subtract different currencies");
            }
            else
            {
                return new Money(a.Amount - b.Amount, a.Currency);
            }
        }
        

        public static bool operator ==(Money a, Money b)
        {
            return a.Amount == b.Amount && a.Currency == b.Currency;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return Amount + " " + CurrencyNames[Currency];
        }

    }
}