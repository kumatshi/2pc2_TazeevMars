using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Родительский класс, представляющий общественный транспорт.
    public class Ferry
    {
        // Защищенные поля, представляющие характеристики транспорта.
        protected string transportName;
        protected int capacity;
        protected double fare;
        private string v;

        public Ferry(string v)
        {
            this.v = v;
        }

        // Конструктор инициализирует характеристики транспорта.
        public Ferry (string name, int capacity, double fare)
        {
            this.transportName = name;
            this.capacity = capacity;
            this.fare = fare;
        }

        // Виртуальный метод для перевозки пассажиров, который может быть переопределен в дочерних классах.
        public virtual void TransportPassengers()
        {
            Console.WriteLine($"Перевозка пассажиров на {transportName} с вместимостью {capacity} и тарифом {fare}.");
        }
    }
}
