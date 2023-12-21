namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный путь к каталогу:");
            string directoryPath = Console.ReadLine();
            if (Directory.Exists(directoryPath))
            {
                string[] fileNames = Directory.GetFiles(directoryPath);
                Console.WriteLine("Информация о файлах до записи данных:");
                PrintFileInfo(fileNames);
                WriteDataToFiles(directoryPath, fileNames);
                string[] updatedFileNames = Directory.GetFiles(directoryPath);
                Console.WriteLine("\nИнформация о файлах после записи данных:");
                PrintFileInfo(updatedFileNames);
            }
            else
            {
                Console.WriteLine("Указанный каталог не существует.");
            }
        }
        static void PrintFileInfo(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                Console.WriteLine($"Файл: {fileInfo.Name}, Размер: {fileInfo.Length} байт");
            }
        }

        static void WriteDataToFiles(string directoryPath, string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);

                // Проверка размера файла (меньше 10 Кб)
                if (fileInfo.Length < 10 * 1024)
                {
                    
                    string data = $"Произвольные данные для файла {fileInfo.Name}";

                    // Запись данных в файл
                    File.WriteAllText(fileName, data);

                    Console.WriteLine($"Данные записаны в файл {fileInfo.Name}");
                }
            }
        }

    }
}