using System;
using Xunit;

namespace BusinessLayer.Tests
{
    public class MoneyTest
    {
        [Fact]
        public void TestAmount()
        {
            //Arrange
            var expected1 = 200.0m;
            var expected2 = 17.85m;
            var expected3 = 10000000000.0m;
            var expected4 = -836.43m;
            var expected5 = 0m;

            //Act
            var actual1 = new Money(200.0m, Money.Currencies.UAH).Amount;
            var actual2 = new Money(17.85m, Money.Currencies.UAH).Amount;
            var actual3 = new Money(10000000000.0m, Money.Currencies.UAH).Amount;
            var actual4 = new Money(-836.43m, Money.Currencies.UAH).Amount;
            var actual5 = new Money(0, Money.Currencies.UAH).Amount;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }

        [Fact]
        public void TestCurrency()
        {
            //Arrange
            var expected1 = Money.Currencies.UAH;
            var expected2 = Money.Currencies.USD;
            var expected3 = Money.Currencies.EUR;
            var expected4 = Money.Currencies.EUR;

            //Act
            var actual1 = new Money(200.0m, Money.Currencies.UAH).Currency;
            var actual2 = new Money(200.0m, Money.Currencies.USD).Currency;
            var actual3 = new Money(200.0m, Money.Currencies.EUR).Currency;
            var actual4 = new Money(200.0m, Money.Currencies.UAH).Currency;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.NotEqual(expected4, actual4);
        }

        [Fact]
        public void TestOperatorPlus()
        {
            // Arrange, Act
            var m11 = new Money(200.0m, Money.Currencies.UAH);
            var m12 = new Money(-200.0m, Money.Currencies.UAH);
            var expected1 = new Money(0.0m, Money.Currencies.UAH);

            var m21 = new Money(0.0m, Money.Currencies.UAH);
            var m22 = new Money(1467.13m, Money.Currencies.UAH);
            var expected2 = new Money(1467.13m, Money.Currencies.UAH);

            var m31 = new Money(200.0m, Money.Currencies.EUR);
            var m32 = new Money(-200.0m, Money.Currencies.EUR);
            var expected3 = new Money(0m, Money.Currencies.EUR);

            var m41 = new Money(0.0m, Money.Currencies.EUR);
            var m42 = new Money(1467.13m, Money.Currencies.EUR);
            var expected4 = new Money(1467.13m, Money.Currencies.EUR);

            var m51 = new Money(200.0m, Money.Currencies.USD);
            var m52 = new Money(-200.0m, Money.Currencies.USD);
            var expected5 = new Money(0m, Money.Currencies.USD);

            var m61 = new Money(0.0m, Money.Currencies.USD);
            var m62 = new Money(1467.13m, Money.Currencies.USD);
            var expected6 = new Money(1467.13m, Money.Currencies.USD);

            // Assert
            Assert.True(m11 + m12 == expected1);
            Assert.True(m12 + m11 == expected1);
            Assert.True(m21 + m22 == expected2);
            Assert.True(m22 + m21 == expected2);
            Assert.True(m31 + m32 == expected3);
            Assert.True(m32 + m31 == expected3);
            Assert.True(m41 + m42 == expected4);
            Assert.True(m42 + m41 == expected4);
            Assert.True(m51 + m52 == expected5);
            Assert.True(m52 + m51 == expected5);
            Assert.True(m61 + m62 == expected6);
            Assert.True(m62 + m61 == expected6);
        }

        [Fact]
        public void TestOperatorPlusExceptions()
        {
            // Arrange
            var m1 = new Money(200.0m, Money.Currencies.UAH);
            var m2 = new Money(-200.0m, Money.Currencies.USD);
            var m3 = new Money(0.0m, Money.Currencies.EUR);
            var m4 = new Money(1467.13m, Money.Currencies.USD);
            var m5 = new Money(200.0m, Money.Currencies.EUR);

            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => m1 + m2);
            Assert.Throws<InvalidOperationException>(() => m2 + m3);
            Assert.Throws<InvalidOperationException>(() => m3 + m4);
            Assert.Throws<InvalidOperationException>(() => m4 + m5);
        }

        [Fact]
        public void TestOperatorMinus()
        {
            // Arrange, Act
            var m11 = new Money(200.0m, Money.Currencies.UAH);
            var m12 = new Money(-200.0m, Money.Currencies.UAH);
            var expected11 = new Money(400.0m, Money.Currencies.UAH);
            var expected12 = new Money(-400.0m, Money.Currencies.UAH);

            var m21 = new Money(0.0m, Money.Currencies.UAH);
            var m22 = new Money(1467.13m, Money.Currencies.UAH);
            var expected21 = new Money(-1467.13m, Money.Currencies.UAH);
            var expected22 = new Money(1467.13m, Money.Currencies.UAH);

            var m31 = new Money(200.0m, Money.Currencies.EUR);
            var m32 = new Money(-200.0m, Money.Currencies.EUR);
            var expected31 = new Money(400m, Money.Currencies.EUR);
            var expected32 = new Money(-400m, Money.Currencies.EUR);

            var m41 = new Money(0.0m, Money.Currencies.EUR);
            var m42 = new Money(1467.13m, Money.Currencies.EUR);
            var expected41 = new Money(-1467.13m, Money.Currencies.EUR);
            var expected42 = new Money(1467.13m, Money.Currencies.EUR);

            var m51 = new Money(200.0m, Money.Currencies.USD);
            var m52 = new Money(-200.0m, Money.Currencies.USD);
            var expected51 = new Money(400m, Money.Currencies.USD);
            var expected52 = new Money(-400m, Money.Currencies.USD);

            var m61 = new Money(0.0m, Money.Currencies.USD);
            var m62 = new Money(1467.13m, Money.Currencies.USD);
            var expected61 = new Money(-1467.13m, Money.Currencies.USD);
            var expected62 = new Money(1467.13m, Money.Currencies.USD);

            // Assert
            Assert.True(m11 - m12 == expected11);
            Assert.True(m12 - m11 == expected12);
            Assert.True(m21 - m22 == expected21);
            Assert.True(m22 - m21 == expected22);
            Assert.True(m31 - m32 == expected31);
            Assert.True(m32 - m31 == expected32);
            Assert.True(m41 - m42 == expected41);
            Assert.True(m42 - m41 == expected42);
            Assert.True(m51 - m52 == expected51);
            Assert.True(m52 - m51 == expected52);
            Assert.True(m61 - m62 == expected61);
            Assert.True(m62 - m61 == expected62);
        }

        [Fact]
        public void TestOperatorMinusExceptions()
        {
            // Arrange
            var m1 = new Money(200.0m, Money.Currencies.UAH);
            var m2 = new Money(-200.0m, Money.Currencies.USD);
            var m3 = new Money(0.0m, Money.Currencies.EUR);
            var m4 = new Money(1467.13m, Money.Currencies.USD);
            var m5 = new Money(200.0m, Money.Currencies.EUR);

            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => m1 - m2);
            Assert.Throws<InvalidOperationException>(() => m2 - m3);
            Assert.Throws<InvalidOperationException>(() => m3 - m4);
            Assert.Throws<InvalidOperationException>(() => m4 - m5);
        }

        [Fact]
        public void TestToString()
        {
            //Arrange
            var expected1 = "200,0 UAH";
            var expected2 = "-251,44 USD";
            var expected3 = "0,0 EUR";

            //Act
            var actual1 = new Money(200.0m, Money.Currencies.UAH).ToString();
            var actual2 = new Money(-251.44m, Money.Currencies.USD).ToString();
            var actual3 = new Money(0.0m, Money.Currencies.EUR).ToString();

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }
    }
}
