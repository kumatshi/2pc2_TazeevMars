using System;

namespace pz_18
{
    // Перечисление для представления типов транспорта
    public enum TransportType { Trolleybus, Bus, Train }

    // Класс, представляющий общественный транспорт
    public class PublicTransport
    {
        private static int totalTransportCount = 0;

        // Свойства транспорта
        public TransportType TransportType { get; set; }
        public string LicensePlate { get; set; }
        public string AssignedDriver { get; set; }
        public TimeOnly DepartureTime { get; set; }
        public TimeOnly EndOfWorkTime { get; set; }

        // Конструктор класса PublicTransport
        public PublicTransport(TransportType type, string licensePlate, string assignedDriver, TimeOnly departureTime, TimeOnly endOfWorkTime)
        {
            TransportType = type;
            // Валидация номера лицензии
            LicensePlate = IsValidLicensePlate(licensePlate) ? licensePlate : throw new ArgumentException("Invalid license plate format");
            AssignedDriver = string.IsNullOrEmpty(assignedDriver) ? "не назначен" : assignedDriver;
            DepartureTime = departureTime;
            EndOfWorkTime = endOfWorkTime;

            totalTransportCount++;
        }

        // Приватный метод для валидации номера лицензии
        private bool IsValidLicensePlate(string licensePlate) => true;

        // Метод определения нахождения на маршруте
        public bool IsOnRoute() => TimeOnly.FromDateTime(DateTime.Now) >= DepartureTime && TimeOnly.FromDateTime(DateTime.Now) <= EndOfWorkTime;

        // Метод отображения информации о транспорте
        public void DisplayInfo() => Console.WriteLine($"Госномер: {LicensePlate}, Водитель: {AssignedDriver}, Тип транспорта: {TransportType}, Состояние: {(IsOnRoute() ? "в рейсе" : "в парке")}");

        // Статический метод для отображения общего количества транспортных средств
        public static void DisplayTotalTransportCount() => Console.WriteLine($"Общее количество транспортных средств: {totalTransportCount}");
    }
}