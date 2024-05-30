using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Дочерний класс Bus, также наследующий PublicTransport.
    public class Bus : Ferry
    {
        // Конструктор вызывает конструктор родительского класса, устанавливая измененные характеристики.
        public Bus(string name) : base(name, -20, 30)
        {
        }


        // Переопределенный метод для автобуса с измененными характеристиками.
        public override void TransportPassengers()
        {
            Console.WriteLine($"Автобус перевозит пассажиров с измененной вместимостью {-capacity} и тарифом {fare}.");
        }
    }
}
