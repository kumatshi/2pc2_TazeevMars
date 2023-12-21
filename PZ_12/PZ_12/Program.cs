namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double perimeter = double.Parse(Console.ReadLine()); // периметр комнаты в метрах
            double wallHeight = double.Parse(Console.ReadLine()); // высота стен в метрах

            int rolls = Rolls(perimeter, wallHeight);

            Console.WriteLine($"Для оклейки комнаты потребуется {rolls} рулонов обоев.");

           
        }

        static int Rolls(double perimeter, double wallHeight)
        {
            // Размер рулона обоев
            double rollWidth = 1; // ширина рулона в метрах
            double rollLength = 10; // длина рулона в метрах

            // Площадь стен комнаты
            double wallArea = perimeter * wallHeight;

            // Площадь одного рулона обоев
            double rollArea = rollWidth * rollLength;

            // Вычисляем количество рулонов, необходимых для оклейки комнаты
            int rollsNeeded = (int)Math.Ceiling(wallArea / rollArea);

            return rollsNeeded;
        }
    }
    
}