namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //Стороны треугольников
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine()); 
            double c = double.Parse(Console.ReadLine()); 
            //Вычисления площади и мериметра
            double perimeter1, area1;
            TrianglePS(a, out perimeter1, out area1);

            double perimeter2, area2;
            TrianglePS(b, out perimeter2, out area2);

            double perimeter3, area3;
            TrianglePS(c, out perimeter3, out area3);

            Console.WriteLine($"Периметр: {perimeter1}, Площадь: {area1}");
            Console.WriteLine($"Периметр: {perimeter2}, Площадь: {area2}");
            Console.WriteLine($"Периметр: {perimeter3}, Площадь: {area3}");   
        }

        static void TrianglePS(double a, out double P, out double S)
        {
            P = 3 * a;//Перимтр
            S = (a * a * Math.Sqrt(3)) / 4;//Площадб
        }
    }
}