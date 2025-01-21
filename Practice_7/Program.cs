using System.IO;

namespace Practice_7
{
    public class Program
    {
        static void Main(string[] args)
        {
            EventLogger logger = new EventLogger();
            Calculator calculator = new Calculator();

            calculator.OnCalculationPerformed += logger.Log;
            calculator.OnCalculationPerformed += Console.WriteLine;

            try
            {
                Console.WriteLine("Введите первое число:");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите второе число:");
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Выберите операцию (+, -, *, /):");
                string operation = Console.ReadLine();

                int result = operation switch
                {
                    "+" => calculator.Add(num1, num2),
                    "-" => calculator.Subtract(num1, num2),
                    "*" => calculator.Multiply(num1, num2),
                    "/" => calculator.Divide(num1, num2),
                    _ => throw new InvalidOperationException("Некорректная операция")
                };

                Console.WriteLine($"Результат: {result}");
            }
            catch (FormatException ex)
            {
                logger.Log($"Ошибка ввода: {ex.Message}");
                Console.WriteLine("Некорректный ввод. Введите числа заново");
            }
            catch (Exception ex)
            {
                logger.Log($"Ошибка: {ex.Message}");
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }      
}
