namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Задание 1");
            for (int i = 20; i <= 70; i += 4)
            {
                Console.WriteLine(i);
            }

            //Задание 2
            Console.WriteLine("Задание 2");
            int n = 0;
            for (char i = 'и'; n < 7; i++, n++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");

            //Задание 3
            Console.WriteLine("Задание 3");
            for (int i = 0; i < 8; i++)
            {
                
                for (int j = 0; j < 5; j++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }

            //Задание 4
            Console.WriteLine("Задание 4");
            int a = 0;  
            for(int i = -500; i < -300; i++)
            {
                if(i % 15==0)
                {
                    Console.Write(i + " ");
                    a++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество чисел кратных 15: " + a);
        }
    }
}