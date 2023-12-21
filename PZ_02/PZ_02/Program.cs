namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int y = int.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double s;
            double t;
            if (y < 2)
            {
                 s = y * Math.Pow(x, 2) / (x + 1);
            }
            else 
            {
                 s = -10.6 * x * y;
            }
            if( s <= 0)
            {
                t = y * s + Math.Sin(x) + y;
            }
            else
            {
                t=s - Math.Pow(Math.Cos(s/x), 2);
            }
            double v =2*y*x + 3*y *s - s*t;
            Console.WriteLine("Результат " + v);
        }
    }
}