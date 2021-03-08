using System;
using Xunit;

namespace BusinessLayer.Tests
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

            var category = new Category("���", "icon24.png", Category.Colors.MAGENTA);
            var date = DateTime.Now;
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));
            //Act
            var actual1 = new Transaction(user, expected1, "", category, date).Amount;
            var actual2 = new Transaction(user, expected2, "", category, date).Amount;
            var actual3 = new Transaction(user, expected3, "", category, date).Amount;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void TestDescription()
        {
            //Arrange
            var expected1 = "";
            var expected2 = "asdbasdvasdvas";
            var expected3 = "����� �����";

            var amount = new Money(255555m, Money.Currencies.EUR);
            var category = new Category("���", "icon24.png", Category.Colors.MAGENTA);
            var date = DateTime.Now;
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            var actual1 = new Transaction(user, amount, expected1, category, date).Description;
            var actual2 = new Transaction(user, amount, expected2, category, date).Description;
            var actual3 = new Transaction(user, amount, expected3, category, date).Description;

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
            var description = "some description..";
            var date = DateTime.Now;
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            var actual1 = new Transaction(user, amount, description, expected1, date).TransactionCategory;
            var actual2 = new Transaction(user, amount, description, expected2, date).TransactionCategory;
            var actual3 = new Transaction(user, amount, description, expected3, date).TransactionCategory;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void TestDate()
        {
            //Arrange
            var expected1 = DateTime.Now;
            var expected2 = DateTime.Today;
            var expected3 = new DateTime(2007, 7, 24);

            var amount = new Money(255555m, Money.Currencies.EUR);
            var description = "some description..";
            var category = new Category("Socks", "icon24.png", Category.Colors.MAGENTA);
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            var actual1 = new Transaction(user, amount, description, category, expected1).Date;
            var actual2 = new Transaction(user, amount, description, category, expected2).Date;
            var actual3 = new Transaction(user, amount, description, category, expected3).Date;

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

            var description = "";
            var category = new Category("���", "icon24.png", Category.Colors.MAGENTA);
            var date = DateTime.Now;
            var user = new User(new PersonName("a", "b"), new Email("mail", "mail.com"));

            //Act
            var amount = new Money(0, Money.Currencies.EUR);
            var transaction = new Transaction(user, amount, description, category, date);
            amount.Amount = 250250250205025025m;

            //Assert
            Assert.NotEqual(amount.Amount, transaction.Amount.Amount);
        }
    }
}
