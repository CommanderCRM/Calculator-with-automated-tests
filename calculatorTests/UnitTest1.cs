using calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace calculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum_10_5_return15()
        {
            //arrange
            string str = "10+5";
            double expected = 15;
            //act
            Form1 f = new Form1();
            double asserted = f.method_for_tests(str);
            //assert
            Assert.AreEqual(expected, asserted);
        }

        [TestMethod]
        public void Minus_10_5_return5()
        {
            //arrange
            string str = "10-5";
            double expected = 5;
            //act
            Form1 f = new Form1();
            double asserted = f.method_for_tests(str);
            //assert
            Assert.AreEqual(expected, asserted);
        }

        [TestMethod]
        public void Dec_10_5_return2()
        {
            //arrange
            string str = "10/5";
            double expected = 2;
            //act
            Form1 f = new Form1();
            double asserted = f.method_for_tests(str);
            //assert
            Assert.AreEqual(expected, asserted);
        }

        [TestMethod]
        public void Multiplication_10_5_return50()
        {
            //arrange
            string str = "10*5";
            double expected = 50;
            //act
            Form1 f = new Form1();
            double asserted = f.method_for_tests(str);
            //assert
            Assert.AreEqual(expected, asserted);
        }

        [TestMethod]
        public void Parenthesis_Test()
        {
            //arrange
            string str = "3*(3+3*3)";
            double expected = 36;
            //act
            Form1 f = new Form1();
            double asserted = f.method_for_tests(str);
            //assert
            Assert.AreEqual(expected, asserted);
        }

        [TestMethod]
        public void Factorial_Test()
        {
            //arrange
            string str = "10!";
            double expected = 3628800;
            //act
            Form1 f = new Form1();
            double asserted = f.method_for_tests(str);
            //assert
            Assert.AreEqual(expected, asserted);
        }

        [TestMethod]
        public void Parenthesis_Test_2()
        {
            //arrange
            string str = "5*(3+3*3)*(5+3*5)";
            double expected = 1200;
            //act
            Form1 f = new Form1();
            double asserted = f.method_for_tests(str);
            //assert
            Assert.AreEqual(expected, asserted);
        }
    }
}
