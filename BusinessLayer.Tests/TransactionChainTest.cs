using System;
using Xunit;

namespace BusinessLayer.Tests
{
    public class TransactionChainTest
    {
        [Fact]
        public void TestAddTransactionExceptions()
        {
            var c1 = Money.Currencies.UAH;
            var c2 = Money.Currencies.USD;

            var tc1 = new TransactionChain(c1);
            var tc2 = new TransactionChain(c2);

            var money1 = new Money(-2000.17m, c1);
            var money2 = new Money(-2000.17m, c2);
            var category = new Category("Развлєкуха", "icon1448.png", Category.Colors.MAGENTA);

            var date = DateTime.Now;

            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            var t1 = new Transaction(user, money1, "thug life", category, date);
            var t2 = new Transaction(user, money2, "salary..", category, date);

            Assert.Throws<ArgumentException>(() => tc1.AddTransaction(t2));
            Assert.Throws<ArgumentException>(() => tc2.AddTransaction(t1));
        }

        [Fact]
        public void TestRemoveTransactionExceptions()
        {
            var c1 = Money.Currencies.UAH;
            var c2 = Money.Currencies.UAH;

            var tc1 = new TransactionChain(c1);
            var tc2 = new TransactionChain(c2);

            var money1 = new Money(-2000.17m, c1);
            var money2 = new Money(-2000.17m, c2);
            var category = new Category("Развлєкуха", "icon1448.png", Category.Colors.MAGENTA);

            var date = DateTime.Now;
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            var t1 = new Transaction(user, money1, "thug life", category, date);
            var t2 = new Transaction(user, money2, "salary..", category, date);

            tc1.AddTransaction(t1);

            tc2.AddTransaction(t2);

            Assert.Throws<MissingMemberException>(() => tc1.RemoveTransaction(t2));
            Assert.Throws<MissingMemberException>(() => tc2.RemoveTransaction(t1));
        }

        [Fact]
        public void TestCurrentAmount()
        {
            //Arrange
            var expected1 = new Money(-1856.4m, Money.Currencies.EUR);
            var expected2 = new Money(-2000.17m, Money.Currencies.EUR);
            var expected3 = new Money(287.54m, Money.Currencies.EUR);

            var currency = Money.Currencies.EUR;
            var money1 = new Money(-2000.17m, Money.Currencies.EUR);
            var money2 = new Money(143.77m, Money.Currencies.EUR);
            var category1 = new Category("Развлєкуха", "icon1448.png", Category.Colors.MAGENTA);
            var category2 = new Category("Зпшка", "icon0.png", Category.Colors.BLACK);
            var date1 = DateTime.Today.AddDays(-1);
            var date2 = DateTime.Today;
            var date3 = DateTime.Now;
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            var t1 = new Transaction(user, money1, "thug life", category1, date1);
            var t2 = new Transaction(user, money2, "salary..", category2, date2);
            var t3 = new Transaction(user, money2, "I'm miserable", category2, date3);

            //Act
            var actual1 = new TransactionChain(currency);
            actual1.AddTransaction(t1);
            actual1.AddTransaction(t2);

            var actual2 = new TransactionChain(currency);
            actual2.AddTransaction(t1);

            var actual3 = new TransactionChain(currency);
            actual3.AddTransaction(t2);
            actual3.AddTransaction(t3);

            //Assert
            Assert.Equal(expected1, actual1.CurrentAmount);
            Assert.Equal(expected2, actual2.CurrentAmount);
            Assert.Equal(expected3, actual3.CurrentAmount);
        }

        [Fact]
        public void TestMonthIncomeAndExpenses()
        {
            //Arrange
            int NDays = 100;
            decimal incomeAmount = 10.0m;
            decimal expencesAmount = -7.6m;

            var expected1 = (DateTime.Today - DateTime.Today.AddMonths(-1)).Days * 2 * incomeAmount;
            var expected2 = - (DateTime.Today - DateTime.Today.AddMonths(-1)).Days * expencesAmount;

            var currency = Money.Currencies.EUR;
            var incomeMoney = new Money(incomeAmount, currency);
            var expencesMoney = new Money(expencesAmount, currency);
            var category1 = new Category("Some category", "icon1448.png", Category.Colors.MAGENTA);
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            var actual1 = new TransactionChain(currency);

            for (int i = 0; i < 100; ++i)
            {
                actual1.AddTransaction(new Transaction(user, incomeMoney, "thug life", category1, DateTime.Today.AddDays(-i)));
                actual1.AddTransaction(new Transaction(user, expencesMoney, "thug life", category1, DateTime.Today.AddDays(-i)));
                actual1.AddTransaction(new Transaction(user, incomeMoney, "thug life", category1, DateTime.Today.AddDays(-i)));
            }

            //Assert
            Assert.Equal(expected1, actual1.MonthIncome.Amount);
            Assert.Equal(expected2, actual1.MonthExpences.Amount);
        }

        [Fact]
        public void TestGetLastNTransactions()
        {
            Assert.True(true);
        }

        [Fact]
        public void TestGetFromIndex()
        {
            Assert.True(true);
        }
    }
}
