namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем ступенчатый массив
            int[][] jaggedArray = new int[5][];
            Random random = new Random();

            // Заполняем массив случайными значениями и разной длиной второго измерения
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int length = random.Next(5, 16);
                jaggedArray[i] = new int[length];

                for (int j = 0; j < length; j++)
                {
                    jaggedArray[i][j] = random.Next(1, 101); 
                }
            }

            //  Выводим сгенерированный массив в консоль
            Console.WriteLine("Сгенерированный массив:");
            foreach (var row in jaggedArray)
            {
                foreach (var element in row)
                {
                    Console.Write($"{element,-4}");
                }
                Console.WriteLine();
            }

            // 3. Создаем новый одномерный массив и записываем в него последние элементы каждой строки
            int[] lastElementsArray = new int[jaggedArray.Length];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                lastElementsArray[i] = jaggedArray[i][jaggedArray[i].Length - 1];
            }

            // Выводим данный массив
            Console.WriteLine("\nМассив последних элементов:");
            foreach (var element in lastElementsArray)
            {
                Console.Write($"{element,-4}");
            }
            Console.WriteLine();

            // 4. В каждой строке ступенчатого находим максимальный элемент и записываем их в новый массив
            int[] maxElementsArray = new int[jaggedArray.Length];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int maxElement = jaggedArray[i][0];
                foreach (var element in jaggedArray[i])
                {
                    if (element > maxElement)
                    {
                        maxElement = element;
                    }
                }
                maxElementsArray[i] = maxElement;
            }

            // Выводим содержимое нового массива
            Console.WriteLine("\nМассив максимальных элементов:");
            foreach (var element in maxElementsArray)
            {
                Console.Write($"{element,-4}");
            }
            Console.WriteLine();

            // В каждой строке меняем местами первый элемент и максимальный
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int maxIndex = Array.IndexOf(jaggedArray[i], maxElementsArray[i]);
                int temp = jaggedArray[i][0];
                jaggedArray[i][0] = jaggedArray[i][maxIndex];
                jaggedArray[i][maxIndex] = temp;
            }

            // Выводим обновленный массив
            Console.WriteLine("\nОбновленный массив после замены:");
            foreach (var row in jaggedArray)
            {
                foreach (var element in row)
                {
                    Console.Write($"{element,-4}");
                }
                Console.WriteLine();
            }

            //  Реверс каждой строки ступенчатого массива
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Array.Reverse(jaggedArray[i]);
            }

            // Выводим массив после реверса каждой строки
            Console.WriteLine("\nМассив после реверса каждой строки:");
            foreach (var row in jaggedArray)
            {
                foreach (var element in row)
                {
                    Console.Write($"{element,-4}");
                }
                Console.WriteLine();
            }

            
            //  Среднее значение в каждой строке
            Console.WriteLine("\nСредние значения в каждой строке:");
            foreach (var row in jaggedArray)
            {
                int sum = 0;
                foreach (var element in row)
                {
                    sum += element;
                }
                double average = (double)sum / row.Length;
                Console.Write($"{average,-10:F2}");
            }
            Console.WriteLine();

            // Общее количество символов в строках каждой строки массива (для строк)
            Console.WriteLine("\nОбщее количество символов в каждой строке:");
            foreach (var row in jaggedArray)
            {
                int totalChars = 0;
                foreach (var element in row)
                {
                    totalChars += element.ToString().Length;
                }
                Console.Write($"{totalChars,-10}");
            }
            Console.WriteLine();

            //  Наиболее встречающиеся символы в каждой строке
            Console.WriteLine("\nНаиболее встречающиеся символы в каждой строке:");
            foreach (var row in jaggedArray)
            {
                int[] charCount = new int[256]; // предполагаем, что символы ASCII
                foreach (var element in row)
                {
                    foreach (char c in element.ToString())
                    {
                        charCount[c]++;
                    }
                }

                int maxCount = 0;
                char mostFrequentChar = '\0';
                for (int i = 0; i < charCount.Length; i++)
                {
                    if (charCount[i] > maxCount)
                    {
                        maxCount = charCount[i];
                        mostFrequentChar = (char)i;
                    }
                }

                Console.Write($"{mostFrequentChar,-4}");
            }
        }
    }
}