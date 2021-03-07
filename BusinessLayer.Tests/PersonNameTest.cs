using System;
using Xunit;

namespace BusinessLayer.Tests
{
    public class PersonNameTest
    {
        [Fact]
        public void TestName()
        {
            //Arrange
            var expected1 = "Герман";
            var expected2 = "Ася";
            var expected3 = "Elizabeth";
            var expected4 = "Катерина-Марія";
            var expected5 = "X Æ A-12";

            //Act
            var actual1 = new PersonName("Герман", "Thompson").Name;
            var actual2 = new PersonName("Ася", "Thompson").Name;
            var actual3 = new PersonName("Elizabeth", "Thompson").Name;
            var actual4 = new PersonName("Катерина-Марія", "Thompson").Name;
            var actual5 = new PersonName("X Æ A-12", "Thompson").Name;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }

        [Fact]
        public void TestNameExceptions()
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => new PersonName("", "Thompson").Name);
            Assert.Throws<ArgumentException>(() => new PersonName(" ", "Thompson").Name);
            Assert.Throws<ArgumentException>(() => new PersonName(",", "Thompson").Name);
            Assert.Throws<ArgumentException>(() => new PersonName("+bl", "Thompson").Name);
            Assert.Throws<ArgumentException>(() => new PersonName("%$", "Thompson").Name);
        }

        [Fact]
        public void TestSurname()
        {
            //Arrange
            var expected1 = "Федоров";
            var expected2 = "Гавриліна";
            var expected3 = "Pahomoff";
            var expected4 = "X Æ A-12";

            //Act
            var actual1 = new PersonName("Sasha", "Федоров").Surname;
            var actual2 = new PersonName("Sasha", "Гавриліна").Surname;
            var actual3 = new PersonName("Sasha", "Pahomoff").Surname;
            var actual4 = new PersonName("Sasha", "X Æ A-12").Surname;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }

        [Fact]
        public void TestSurnameExceptions()
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => new PersonName("Alexandra", "").Name);
            Assert.Throws<ArgumentException>(() => new PersonName("Alexandra", " ").Name);
            Assert.Throws<ArgumentException>(() => new PersonName("Alexandra", ",").Name);
            Assert.Throws<ArgumentException>(() => new PersonName("Alexandra", "+bl").Name);
            Assert.Throws<ArgumentException>(() => new PersonName("Alexandra", "%$").Name);
        }

        [Fact]
        public void TestToString()
        {
            //Arrange
            var expected1 = "Alexander Gerasimov";
            var expected2 = "Roger Waters";
            var expected3 = "Youwont Readit";
            var expected4 = "Аліна Аліковська";
            var expected5 = "X Æ A-12 Musk";

            //Act
            var actual1 = new PersonName("Alexander", "Gerasimov").ToString();
            var actual2 = new PersonName("Roger", "Waters").ToString();
            var actual3 = new PersonName("Youwont", "Readit").ToString();
            var actual4 = new PersonName("Аліна", "Аліковська").ToString();
            var actual5 = new PersonName("X Æ A-12", "Musk").ToString();


            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }
    }
}
