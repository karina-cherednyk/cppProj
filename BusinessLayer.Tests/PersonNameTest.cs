using g4m4nez.Models;
using Xunit;

namespace g4m4nez.BusinessLayer.Tests
{
    public class PersonNameTest
    {
        [Fact]
        public void TestName()
        {
            //Arrange
            string expected1 = "Герман";
            string expected2 = "Ася";
            string expected3 = "Elizabeth";
            string expected4 = "Катерина-Марія";
            string expected5 = "X Æ A-12";

            //Act
            string actual1 = new PersonName("Герман", "Thompson").Name;
            string actual2 = new PersonName("Ася", "Thompson").Name;
            string actual3 = new PersonName("Elizabeth", "Thompson").Name;
            string actual4 = new PersonName("Катерина-Марія", "Thompson").Name;
            string actual5 = new PersonName("X Æ A-12", "Thompson").Name;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }

        [Fact]
        public void TestSurname()
        {
            //Arrange
            string expected1 = "Федоров";
            string expected2 = "Гавриліна";
            string expected3 = "Pahomoff";
            string expected4 = "X Æ A-12";

            //Act
            string actual1 = new PersonName("Sasha", "Федоров").Surname;
            string actual2 = new PersonName("Sasha", "Гавриліна").Surname;
            string actual3 = new PersonName("Sasha", "Pahomoff").Surname;
            string actual4 = new PersonName("Sasha", "X Æ A-12").Surname;

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
        }

        [Fact]
        public void TestToString()
        {
            //Arrange
            string expected1 = "Alexander Gerasimov";
            string expected2 = "Roger Waters";
            string expected3 = "Youwont Readit";
            string expected4 = "Аліна Аліковська";
            string expected5 = "X Æ A-12 Musk";

            //Act
            string actual1 = new PersonName("Alexander", "Gerasimov").ToString();
            string actual2 = new PersonName("Roger", "Waters").ToString();
            string actual3 = new PersonName("Youwont", "Readit").ToString();
            string actual4 = new PersonName("Аліна", "Аліковська").ToString();
            string actual5 = new PersonName("X Æ A-12", "Musk").ToString();


            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }
    }
}
