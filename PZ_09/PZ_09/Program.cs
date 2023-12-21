using System.Text.RegularExpressions;

namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вводим строку
            Console.Write("Введите строку: ");
            string inputStr = Console.ReadLine();

            // Проверяем наличие однострочного комментария
            if (inputStr.Contains("//"))
            {
                // Находим позицию начала комментария
                int indexSingleLine = inputStr.IndexOf("//");

                // Выводим текст до начала комментария
                Console.WriteLine(inputStr.Substring(0, indexSingleLine));
            }
            else
            {
                // Если однострочного комментария нет, выводим всю строку
                Console.WriteLine(inputStr);
            }

            // Проверяем наличие многострочного комментария
            if (inputStr.Contains("/*"))
            {
                // Находим позицию начала многострочного комментария
                int indexMultiLineStart = inputStr.IndexOf("/*");

                // Находим позицию конца многострочного комментария
                int indexMultiLineEnd = inputStr.IndexOf("*/");

                // Выводим текст до начала многострочного комментария
                Console.WriteLine(inputStr.Substring(0, indexMultiLineStart));

                // Выводим полезный текст после многострочного комментария
                Console.WriteLine(inputStr.Substring(indexMultiLineEnd + 2));
            }
            else
            {
                // Если многострочного комментария нет, выводим всю строку
                Console.WriteLine(inputStr);
            }
        }

    }
}