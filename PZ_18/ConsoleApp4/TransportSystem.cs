using pz_18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportSystem
{
    class TransportSystem
    {
        // Точка входа в программу
        static void Main()
        {
            // Создание объектов и демонстрация логики работы
            var trolleybus = new PublicTransport(TransportType.Trolleybus, "AB 123 CD", "Иванов Иван", new TimeOnly(8, 0), new TimeOnly(18, 0));
            var bus = new PublicTransport(TransportType.Bus, "XY 456 ZA", "", new TimeOnly(9, 30), new TimeOnly(19, 30));
            var train = new PublicTransport(TransportType.Train, "KL 789 MN", "Петров Петр", new TimeOnly(7, 45), new TimeOnly(17, 45));

            // Вывод информации по каждому объекту
            trolleybus.DisplayInfo();
            bus.DisplayInfo();
            train.DisplayInfo();

            // Проверка нахождения на маршруте и вывод общего количества созданных объектов
            Console.WriteLine($"Троллейбус на рейсе: {trolleybus.IsOnRoute()}");
            PublicTransport.DisplayTotalTransportCount();
        }
    }
}
