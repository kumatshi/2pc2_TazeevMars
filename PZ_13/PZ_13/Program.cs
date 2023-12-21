namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            double a1 = 1;//первое число
            double d = 2;//шаг прогрессии
            int n = int.Parse(Console.ReadLine());// член прогрессии
            double result = ArifmProg(a1, d, n);//результат
            Console.WriteLine($"задание 1: {n} член арифметической прогрессии равен: {result}");

            ////Задание 2
            double b1 = 6;//первое число
            double q = -5;//шаг прогрессии
            int n1 = int.Parse(Console.ReadLine());//член прогрессии
            double result1 = GeomProg(b1, q, n1); //результат
            Console.WriteLine($"Задание 2: {n1} член геометрической прогрессии равен: {result1}");
            Console.WriteLine("");

            //Задание 3
            int A = 64;//первое число
            int B = 54;//второе число
            Console.WriteLine("Задание 3");
            Output(A, B);
            Console.WriteLine(" ");

            //Задание на 5 
            /*С помощью рекурсии Summ(int x) для введенного числа n вычислить сумму чисел от 1 до n
            Например: Summ(2) = 2 + 1 = 3
            Summ(5) = 5 + 4 + 3 + 2 + 1 = 15*/
            int x = int.Parse(Console.ReadLine());
            int result2 = Summ(x);
            Console.WriteLine($"Задание 4: Сумма всех чисел от {x} до 0: {result2}");


        }
        public static double ArifmProg(double a1, double d, int n)  // Задаине 1
        {
            if (n == 1)
            {
                return a1;
            }
            else
            {
                return ArifmProg(a1, d, n - 1) + d;//формула прогрессии

            }
        }


        public static double GeomProg(double b1, double q, int n) //задание 2
        {
            if (n == 1)
            {
                return b1;
                Console.WriteLine(b1);
            }
            else
            {
                return GeomProg(b1, q, n - 1) * q;//формула прогрессии

            }

        }


        public static int Output(int A, int B)//задание 3
        {
            if (A == B - 1)
            {
                return A;
            }
            else
            {
                Console.Write(A + " ");
                return Output(A - 1, B);
            }
        }
        public static int Summ(int x)//задание на 5
        {

            if (x == 1)
            {
                return x;
            }
            else
            {
                return x + Summ(x - 1);//сумма всех чисел от x до 0

            }

        }



    }
}