using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuessNumber.Classes
{
    public class Game
    {
        private Random _random = new();

        public void Start()
        {
            while (true)
            {
                Console.WriteLine($"Введите количество попыток:");
                int attemptCount = GetValue(CheckValue(Console.ReadLine()));
                Console.WriteLine($"Введите минимальное значение диапазона:");
                int minValue = GetValue(CheckValue(Console.ReadLine()));
                Console.WriteLine($"Введите максимальное значение диапазона:");
                int maxValue = GetValue(CheckValue(Console.ReadLine()));



                // Генерация хода компьютера
                int computerChoice = GetNumber(minValue, maxValue);

                Console.WriteLine($"Введите число от {minValue} до {maxValue}. Количество попыток: {attemptCount}");

                while (attemptCount > 0)
                {
                    int userChoice = GetValue(CheckValue(Console.ReadLine()));
                    if (userChoice > computerChoice)
                    {
                        Console.WriteLine("Больше");
                    }
                    if (userChoice < computerChoice)
                    {
                        Console.WriteLine("Меньше");
                    }
                    if (userChoice == computerChoice)
                    {
                        Console.WriteLine("Угадали!");
                        break;
                    }
                    attemptCount--;
                }

                Console.WriteLine("Сыграем ещё раз? (да/нет)");
                if (Console.ReadLine().ToLower() != "да")
                {
                    break;
                }
            }
        }

        private int GetNumber(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue); ;
        }
        private int? CheckValue(string value)
        {
            if (!Int32.TryParse(value, out int result))
                return null;
            else
                return result;
        }
        private int GetValue(int? value)
        {
            if (value.HasValue)
                return value.Value;
            else
                throw new Exception("Введено некорректное значение");
        }
    }
}
