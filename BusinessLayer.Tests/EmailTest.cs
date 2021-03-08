using System;
using Xunit;

namespace BusinessLayer.Tests
{
    public class EmailTest
    {
        [Fact]
        public void TestMailName()
        {
            //Arrange
            var expected1 = "boublik";
            var expected2 = "a";
            var expected3 = "n4gib4t0r";

            //Act
            var actual1 = new Email("boublik", "ukma.edu.ua").MailName;
            var actual2 = new Email("a", "ukma.edu.ua").MailName;
            var actual3 = new Email("n4gib4t0r", "ukma.edu.ua").MailName;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        [Fact]
        public void TestMailNameExceptions()
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => new Email("", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email(" ", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email(",", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("+bl", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("%$", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("0", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("1", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("6", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("1245", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("1boublik", "ukma.edu.ua").MailName);
            Assert.Throws<ArgumentException>(() => new Email("bo ublik", "ukma.edu.ua").MailName);
        }

        [Fact]
        public void TestDomain()
        {
            //Arrange
            var expected1 = "ukma.edu.ua";
            var expected2 = "gmail.com";
            var expected3 = "m.net";
            var expected4 = "m.c";

            //Act
            var actual1 = new Email("boublik", "ukma.edu.ua").Domain;
            var actual2 = new Email("a", "gmail.com").Domain;
            var actual3 = new Email("a", "m.net").Domain;
            var actual4 = new Email("a", "m.c").Domain;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }

        [Fact]
        public void TestDomainExceptions()
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => new Email("boublik", "").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", " ").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", ",").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "+bl").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "%$").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "0").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "1").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "6").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "1245").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "1mail").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma il").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma il. com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma. il. com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma..il. com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma .il .com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma. .il. com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma..il.com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "ma. .il.com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", ".mail.com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "..mail.com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "mail.com.").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "@mail.com").Domain);
            Assert.Throws<ArgumentException>(() => new Email("boublik", "24mail.com").Domain);
        }

        [Fact]
        public void TestToString()
        {
            //Arrange
            var expected1 = "boublik@ukma.edu.ua";
            var expected2 = "boublik@gmail.com";
            var expected3 = "a@m.net";
            var expected4 = "a@m.c";

            //Act
            var actual1 = new Email("boublik", "ukma.edu.ua").ToString();
            var actual2 = new Email("boublik", "gmail.com").ToString();
            var actual3 = new Email("a", "m.net").ToString();
            var actual4 = new Email("a", "m.c").ToString();

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }
    }
}
