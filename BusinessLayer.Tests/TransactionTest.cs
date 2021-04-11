using System;
using Xunit;

namespace g4m4nez.BusinessLayer.Tests
{
    public class TransactionTest
    {
        [Fact]
        public void TestAmount()
        {
            //Arrange
            var expected1 = new Money(250.14m, Money.Currencies.UAH);
            var expected2 = new Money(0, Money.Currencies.USD);
            var expected3 = new Money(-2000.17m, Money.Currencies.EUR);

            var category = new Category("Їжа", "icon24.png", Category.Colors.MAGENTA);
            DateTime date = DateTime.Now;
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));
            //Act
            Models.Money actual1 = new Transaction(user, expected1, "", category, date).Amount;
            Models.Money actual2 = new Transaction(user, expected2, "", category, date).Amount;
            Models.Money actual3 = new Transaction(user, expected3, "", category, date).Amount;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void TestDescription()
        {
            //Arrange
            string expected1 = "";
            string expected2 = "asdbasdvasdvas";
            string expected3 = "трохи цукру";

            var amount = new Money(255555m, Money.Currencies.EUR);
            var category = new Category("Їжа", "icon24.png", Category.Colors.MAGENTA);
            DateTime date = DateTime.Now;
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            string actual1 = new Transaction(user, amount, expected1, category, date).Description;
            string actual2 = new Transaction(user, amount, expected2, category, date).Description;
            string actual3 = new Transaction(user, amount, expected3, category, date).Description;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void TestCategory()
        {
            //Arrange
            var expected1 = new Category("Socks", "icon24.png", Category.Colors.MAGENTA);
            var expected2 = new Category("Clothes", "icadsadn24.png", Category.Colors.ORANGE);
            var expected3 = new Category("Games", "pstrn.jpg", Category.Colors.BLUE);

            var amount = new Money(255555m, Money.Currencies.EUR);
            string description = "some description..";
            DateTime date = DateTime.Now;
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            Models.Category actual1 = new Transaction(user, amount, description, expected1, date).TransactionCategory;
            Models.Category actual2 = new Transaction(user, amount, description, expected2, date).TransactionCategory;
            Models.Category actual3 = new Transaction(user, amount, description, expected3, date).TransactionCategory;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void TestDate()
        {
            //Arrange
            DateTime expected1 = DateTime.Now;
            DateTime expected2 = DateTime.Today;
            DateTime expected3 = new DateTime(2007, 7, 24);

            var amount = new Money(255555m, Money.Currencies.EUR);
            string description = "some description..";
            var category = new Category("Socks", "icon24.png", Category.Colors.MAGENTA);
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            DateTime actual1 = new Transaction(user, amount, description, category, expected1).Date;
            DateTime actual2 = new Transaction(user, amount, description, category, expected2).Date;
            DateTime actual3 = new Transaction(user, amount, description, category, expected3).Date;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void testWhetherArgumentsArePassedByValue()
        {
            //Arrange
            var expected1 = new Money(0, Money.Currencies.EUR);

            string description = "";
            var category = new Category("Їжа", "icon24.png", Category.Colors.MAGENTA);
            DateTime date = DateTime.Now;
            User user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            var amount = new Money(0, Money.Currencies.EUR);
            Transaction transaction = new Transaction(user, amount, description, category, date);
            amount.Amount = 250250250205025025m;

            //Assert
            Assert.NotEqual(amount.Amount, transaction.Amount.Amount);
        }
    }
}
