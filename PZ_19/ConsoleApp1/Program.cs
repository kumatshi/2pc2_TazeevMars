using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Создание объектов классов
        Trolleybus trolleybus = new Trolleybus("City Trolley");
        Bus bus = new Bus("Express Bus");

        Ferry publicTransport = new Ferry("PublicTransport");

        // Вызов методов демонстрирующих логику работы
        trolleybus.TransportPassengers();
        bus.TransportPassengers();
        publicTransport.TransportPassengers();
    }
}