namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double h = Math.Pow(10, -3) * Math.Tan(-8);
            double z = (a-c)*(Math.Pow(a,2)+Math.Pow(b,2));
            double u = (3 * (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2.2 * c)));
            double zu = z / u;
            double j = Math.Cos(2*a)/Math.Sin(5);
            double result = h - zu - j ;
            Console.WriteLine(result);
        }
    }
}