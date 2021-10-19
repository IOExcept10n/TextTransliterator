using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransliterator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ведите текст на русском для транслитерации: ");
            string toTest1 = Console.ReadLine();
            Console.Write("Ведите текст для проверки и обратной транслитерации: ");
            string toCheck1 = Console.ReadLine();
            string test1 = Transliterator.RUTranslit(toTest1);
            bool passed1 = test1 == toCheck1;
            Console.ForegroundColor = passed1 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Результат транслитерации: {test1}. Статус совпадения: {passed1}");
            string test2 = Transliterator.ENTranslit(toCheck1);
            bool passed2 = test2 == toTest1;
            Console.ForegroundColor = passed2 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Результат обратной транслитерации: {test2}. Статус совпадения с исходным текстом: {passed2}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ведите текст с английской раскладкой: ");
            string toTest2 = Console.ReadLine();
            Console.Write("Ведите текст для проверки и обратного перевода: ");
            string toCheck2 = Console.ReadLine();
            string test3 = Transliterator.ReplaceLayoutToRU(toTest2);
            bool passed3 = test3 == toCheck2;
            Console.ForegroundColor = passed3 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Результат перевода: {test3}. Статус проверки: {passed3}");
            string test4 = Transliterator.ReplaceLayoutToEN(toCheck2);
            bool passed4 = test4 == toTest2;
            Console.ForegroundColor = passed4 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Результат обратного перевода: {test4}. Статус проверки исходным текстом: {passed4}");
        }
    }
}
