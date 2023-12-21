namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            for (int i = n1;i<=n2;i++)
            {
                n1 *= i;
                Console.WriteLine(n1);
            }

            
        }
    }
}