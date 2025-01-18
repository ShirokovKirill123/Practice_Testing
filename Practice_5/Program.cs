namespace Practice_5
{
     //Ctrl+Alt+V, L - Locals
     //Ctrl+Alt+W, 1 - Watch

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                List<string> strings = new List<string> { "hello", "underwater", "probably" };

                Console.Write("Введите число для фильтрации списка (удаление кратных этому числу): ");
                int divisor = int.Parse(Console.ReadLine());

                List<int> filteredNumbers = FilterNumbers(numbers, divisor);
                Console.WriteLine("Отфильтрованный список чисел: " + string.Join(", ", filteredNumbers));  // условная точка останова(сработает если в списке есть число 10)
              
                string longestString = FindLongestString(strings);
                Console.WriteLine("Самая длинная строка: " + longestString);
       
                Console.Write("Введите строку для проверки на палиндром: ");
                string inputString = Console.ReadLine();
                bool isPalindrome = IsPalindrome(inputString);
                Console.WriteLine($"Строка \"{inputString}\" {(isPalindrome ? "является" : "не является")} палиндромом");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
        
        static List<int> FilterNumbers(List<int> numbers, int divisor)
        {
            return numbers.Where(n => n % divisor != 0).ToList();
        }

        static string FindLongestString(List<string> strings)
        {
            return strings.OrderByDescending(s => s.Length).FirstOrDefault();  //точка останова 
        }

        static bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))   //точка останова 
                return false;

            string upper = input.ToUpper();
            string reversed = new string(upper.Reverse().ToArray()); 
            return upper == reversed;
        }
    }
}