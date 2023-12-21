namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы (n): ");
            int n = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, n];
            Console.WriteLine("Введите элементы матрицы:");
            //Заполнение матрицы с клав
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // Вывод  матрицы
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }

            // Замена дигоналйе
            for (int i = 0; i < n / 2; i++)
            {
                double temp = matrix[i, i];
                matrix[i, i] = matrix[n - 1 - i, n - 1 - i];
                matrix[n - 1 - i, n - 1 - i] = temp;

                temp = matrix[i, n - 1 - i];
                matrix[i, n - 1 - i] = matrix[n - 1 - i, i];
                matrix[n - 1 - i, i] = temp;
            }

            // Перевернутая матрица
            Console.WriteLine("Матрица после переворота диагоналей:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}