using System;

namespace Laba01OOP
{
    // Клас "Слово" для роботи з текстовими даними
    class Slovo
    {
        // Властивість для зберігання тексту слова
        public string Text { get; set; }

        // Конструктор
        public Slovo(string text)
        {
            Text = text;
            Console.WriteLine($"Створено об'єкт Слово: {Text}");
        }

        // Деструктор
        ~Slovo()
        {
            Console.WriteLine($"Знищено об'єкт Слово: {Text}");
        }

        // Метод для підрахунку кількості цифр у слові
        public int CountDigits()
        {
            int count = 0;
            foreach (char symbol in Text)
            {
                if (char.IsDigit(symbol))
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // --- Введення масиву слів ---
            int n = 5;
            Slovo[] words = new Slovo[n];

            Console.WriteLine("Введіть 5 слів (можна з цифрами):");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Слово {i + 1}: ");
                string input = Console.ReadLine();
                words[i] = new Slovo(input);
            }

            // --- Пошук слова з найбільшою кількістю цифр ---
            int maxDigits = -1;
            int indexMaxDigits = -1;

            for (int i = 0; i < n; i++)
            {
                int digitCount = words[i].CountDigits();
                Console.WriteLine($"Слово '{words[i].Text}' містить {digitCount} цифр.");

                if (digitCount > maxDigits)
                {
                    maxDigits = digitCount;
                    indexMaxDigits = i;
                }
            }

            if (indexMaxDigits != -1)
            {
                Console.WriteLine($"Слово з найбільшою кількістю цифр: '{words[indexMaxDigits].Text}' ({maxDigits} цифр)");
            }
            else
            {
                Console.WriteLine("Жодне слово не містить цифр.");
            }

            // --- Демонстрація Garbage Collection ---
            Console.WriteLine();
            Console.WriteLine("Видаляємо посилання на об'єкти...");
            for (int i = 0; i < n; i++)
            {
                words[i] = null;
            }

            Console.WriteLine("Викликаємо GC.Collect()...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Готово. Натисніть Enter, щоб завершити.");
            Console.ReadLine();
        }
    }
}
