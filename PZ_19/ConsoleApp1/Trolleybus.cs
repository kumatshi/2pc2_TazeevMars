using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Дочерний класс Trolleybus, наследующий PublicTransport.
    public class Trolleybus : Ferry
    {
        // Конструктор вызывает конструктор родительского класса, устанавливая измененные характеристики.
        public Trolleybus(string name) : base(name, -30, 20)
        {
        }

        // Переопределенный метод для троллейбуса с измененными характеристиками.
        public override void TransportPassengers()
        {
            Console.WriteLine($"Троллейбус перевозит пассажиров с измененной вместимостью {-capacity} и тарифом {fare}.");
        }
    }
}
