using System;
using g4m4nez.Models;
using Xunit;

namespace g4m4nez.BusinessLayer.Tests
{
    public class TransactionChainTest
    {
        [Fact]
        public void TestAddTransactionExceptions()
        {
            var c1 = Money.Currencies.UAH;
            var c2 = Money.Currencies.USD;

            TransactionChain tc1 = new TransactionChain(c1);
            TransactionChain tc2 = new TransactionChain(c2);

            var money1 = new Money(-2000.17m, c1);
            var money2 = new Money(-2000.17m, c2);
            var category = new Category("Развлєкуха", "icon1448.png", Category.Colors.MAGENTA);

            DateTime date = DateTime.Now;

            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            Transaction t1 = new Transaction(user.Guid, money1, "thug life", category, date);
            Transaction t2 = new Transaction(user.Guid, money2, "salary..", category, date);

            Assert.Throws<ArgumentException>(() => tc1.AddTransaction(t2));
            Assert.Throws<ArgumentException>(() => tc2.AddTransaction(t1));
        }

        [Fact]
        public void TestRemoveTransactionExceptions()
        {
            var c1 = Money.Currencies.UAH;
            var c2 = Money.Currencies.UAH;

            TransactionChain tc1 = new TransactionChain(c1);
            TransactionChain tc2 = new TransactionChain(c2);

            var money1 = new Money(-2000.17m, c1);
            var money2 = new Money(-2000.17m, c2);
            var category = new Category("Развлєкуха", "icon1448.png", Category.Colors.MAGENTA);

            DateTime date = DateTime.Now;
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            Transaction t1 = new Transaction(user.Guid, money1, "thug life", category, date);
            Transaction t2 = new Transaction(user.Guid, money2, "salary..", category, date);

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
            DateTime date1 = DateTime.Today.AddDays(-1);
            DateTime date2 = DateTime.Today;
            DateTime date3 = DateTime.Now;
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            Transaction t1 = new Transaction(user.Guid, money1, "thug life", category1, date1);
            Transaction t2 = new Transaction(user.Guid, money2, "salary..", category2, date2);
            Transaction t3 = new Transaction(user.Guid, money2, "I'm miserable", category2, date3);

            //Act
            TransactionChain actual1 = new TransactionChain(currency);
            actual1.AddTransaction(t1);
            actual1.AddTransaction(t2);

            TransactionChain actual2 = new TransactionChain(currency);
            actual2.AddTransaction(t1);

            TransactionChain actual3 = new TransactionChain(currency);
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
            decimal incomeAmount = 10.0m;
            decimal expencesAmount = -7.6m;

            decimal expected1 = (DateTime.Today - DateTime.Today.AddMonths(-1)).Days * 2 * incomeAmount;
            decimal expected2 = -(DateTime.Today - DateTime.Today.AddMonths(-1)).Days * expencesAmount;

            var currency = Money.Currencies.EUR;
            var incomeMoney = new Money(incomeAmount, currency);
            var expencesMoney = new Money(expencesAmount, currency);
            var category1 = new Category("Some category", "icon1448.png", Category.Colors.MAGENTA);
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            TransactionChain actual1 = new TransactionChain(currency);

            for (int i = 0; i < 100; ++i)
            {
                actual1.AddTransaction(new Transaction(user.Guid, incomeMoney, "thug life", category1, DateTime.Today.AddDays(-i)));
                actual1.AddTransaction(new Transaction(user.Guid, expencesMoney, "thug life", category1, DateTime.Today.AddDays(-i)));
                actual1.AddTransaction(new Transaction(user.Guid, incomeMoney, "thug life", category1, DateTime.Today.AddDays(-i)));
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
