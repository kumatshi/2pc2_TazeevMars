using System.Globalization;
using System.IO;

namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "C:\\C#\\2pk2_TazeevMars\\PZ_14\\PZ_14\\f1.txt";
            string outputFilePath = "C:\\C#\\2pk2_TazeevMars\\PZ_14\\PZ_14\\f2.txt";

            Delete(inputFilePath, outputFilePath);

            Console.WriteLine("Пустые строки удалены и сохранены в новый файл.");

            // Ждем ввода перед завершением программы
            Console.ReadLine();
        }
        static void Delete(string inputFilePath, string outputFilePath)
        {
            // Чтение содержимого файла
            string[] lines = File.ReadAllLines(inputFilePath);

            // Фильтрация пустых строк
            string[] nonEmptyLines = Array.FindAll(lines, line => !string.IsNullOrWhiteSpace(line));

            // Сохранение в новый файл без пустых строк
            File.WriteAllLines(outputFilePath, nonEmptyLines);
        }



    }
    
}