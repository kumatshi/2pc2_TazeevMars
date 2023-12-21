namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите код города (905 - Москва, 194 - Ростов, 491 - Краснодар, 800 - Киров):");
            int Code = int.Parse(Console.ReadLine());
            
                double MinuteCena;

                // Определяем стоимость разговора в зависимости от кода города
                switch (Code)
                {
                    case 905:
                        MinuteCena = 4.15;
                        break;
                    case 194:
                        MinuteCena = 1.98;
                        break;
                    case 491:
                        MinuteCena = 2.69;
                        break;
                    case 800:
                        MinuteCena = 3.15; // Например, для Кирова
                        break;
                    default:
                        Console.WriteLine("Город с указанным кодом не найден.");
                        return;
                }

                // Вычисляем стоимость 10-минутного разговора
                double totalCost = MinuteCena * 10;

                Console.WriteLine($"Стоимость 10-минутного разговора в городе с кодом {Code}: {totalCost} руб.");
            
        }
    }
}