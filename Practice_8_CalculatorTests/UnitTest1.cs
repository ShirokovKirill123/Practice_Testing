using Practice_8;

namespace Practice_8_CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()//позитивный сценарий
        {
            double result = _calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Subtract_ShouldReturnCorrectDifference()//позитивный сценарий
        {
            double result = _calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Multiply_ShouldReturnCorrectProduct()//позитивный сценарий
        {
            double result = _calculator.Multiply(2, 3);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Divide_ShouldReturnCorrectQuotient()//позитивный сценарий
        {
            double result = _calculator.Divide(6, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Divide_ByZero_ShouldThrowException()//негативный сценарий
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
        }

        [Test]
        public void Divide_ShouldHandleNegativeNumbers()//позитивный сценарий
        {
            double result = _calculator.Divide(-6, 3);
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void Add_ShouldHandleLargeNumbers()//позитивный сценарий
        {
            double result = _calculator.Add(10000000000, 10000000000);
            Assert.AreEqual(20000000000, result);
        }

        [Test]
        public void Multiply_ShouldHandleLargeNumbers() //позитивный сценарий
        {
            double result = _calculator.Multiply(1000000, 1000000);
            Assert.AreEqual(1000000000000, result);
        }

        [Test]
        public void InvalidOperation_ShouldThrowException() //негативный сценарий
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                double num1 = 5;
                double num2 = 3;
                string operation = "%";
                _ = operation switch
                {
                    "+" => _calculator.Add(num1, num2),
                    "-" => _calculator.Subtract(num1, num2),
                    "*" => _calculator.Multiply(num1, num2),
                    "/" => _calculator.Divide(num1, num2),
                    _ => throw new InvalidOperationException("Некорректная операция")
                };
            });
        }

        [Test]
        public void ParseError_ShouldThrowFormatException() //негативный сценарий
        {
            Assert.Throws<FormatException>(() => double.Parse("not_a_number"));
        }

        [Test]
        public void Subtract_ShouldHandleNegativeResults() //негативный сценарий
        {
            double result = _calculator.Subtract(3, 5);
            Assert.AreEqual(-2, result);
        }
    }
}
