using System.Collections.Generic;
namespace g4m4nez.Models
{
    public class Money
    {
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public enum Currencies
        {
            USD, UAH, EUR, RUB
        }

        private static readonly Dictionary<Currencies, string> CurrencyNames = new Dictionary<Currencies, string> {
            {Currencies.USD, "USD"},
            {Currencies.UAH, "UAH" },
            {Currencies.EUR, "EUR" }
        };
        public override int GetHashCode()
        {
            return Amount.GetHashCode() + Currency.GetHashCode();
        }

        private Currencies _currency;
        public Currencies Currency
        {
            get => _currency;
            set => _currency = value;
        }

        public Money(decimal amount, Currencies currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public static Money operator +(Money a, Money b)
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

        public static Money operator -(Money a, Money b)
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