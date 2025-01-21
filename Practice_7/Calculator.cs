namespace Practice_7
{
    public class Calculator
    {
        public event Action<string> OnCalculationPerformed;

        public int Add(int a, int b)
        {
            int result = a + b;
            OnCalculationPerformed?.Invoke($"Сложение: {a} + {b} = {result}");
            return result;
        }

        public int Subtract(int a, int b)
        {
            int result = a - b;
            OnCalculationPerformed?.Invoke($"Вычитание: {a} - {b} = {result}");
            return result;
        }

        public int Multiply(int a, int b)
        {
            int result = a * b;
            OnCalculationPerformed?.Invoke($"Умножение: {a} * {b} = {result}");
            return result;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно");
            }
            int result = a / b;
            OnCalculationPerformed?.Invoke($"Деление: {a} / {b} = {result}");
            return result;
        }
    }
}