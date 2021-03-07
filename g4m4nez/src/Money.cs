using System.Collections.Generic;
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

    private Currencies currency;
    public Currencies Currency
    {
        get { return currency; }
        set { currency = value; }
    }

}
