namespace Practice_6
{
    internal class Program
    {
        //Ctrl+Alt+V, L - Locals
        //Ctrl+Alt+W, 1 - Watch
        //Ctrl+Alt+C - Call Stack

        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            int number1 = int.Parse(Console.ReadLine()); // Точка останова 1

            Console.Write("Введите второе число: ");
            int number2 = int.Parse(Console.ReadLine()); // Точка останова 2

            int sum = number1 + number2; // Точка останова 3
            int difference = number1 - number2; // Точка останова 4

            bool isEven = sum % 2 == 0; // Точка останова 5
            Console.WriteLine($"Сумма чисел: {sum}");
            Console.WriteLine($"Разность чисел: {difference}");
            Console.WriteLine($"Сумма четная? {isEven}");

            LogToFile(number1, number2, sum, difference, isEven);
        }

        static void LogToFile(int number1, int number2, int sum, int difference, bool isEven)
        {
            string logFilePath = "log.txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Время выполнения: {DateTime.Now}");
                writer.WriteLine($"Первое число: {number1}");
                writer.WriteLine($"Второе число: {number2}");
                writer.WriteLine($"Сумма: {sum}");
                writer.WriteLine($"Разность: {difference}");
                writer.WriteLine($"Сумма четная? {isEven}");
                writer.WriteLine(new string('-', 30));
            }
        }
    }
}