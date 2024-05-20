using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LibraryApp.Models
{
    /// <summary>
    /// Представляет модель клиента библиотеки.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия клиента.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество клиента.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер телефона клиента.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Список резерваций книг для данного клиента.
        /// </summary>
        [JsonIgnore]
        public ICollection<BookReservation> BookReservations { get; set; }

        /// <summary>
        /// Конструктор по умолчанию. Инициализирует список резерваций книг.
        /// </summary>
        public Client()
        {
            BookReservations = new List<BookReservation>();
        }

        /// <summary>
        /// Конструктор с параметрами для инициализации объекта клиента.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        /// <param name="phoneNumber">Номер телефона клиента.</param>
        /// <param name="surname">Фамилия клиента.</param>
        /// <param name="middleName">Отчество клиента.</param>
        public Client(string name, string phoneNumber, string surname, string middleName)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Surname = surname;
            MiddleName = middleName;
            BookReservations = new List<BookReservation>();
        }

        /// <summary>
        /// Переопределение метода ToString() для удобного отображения информации о клиенте.
        /// </summary>
        /// <returns>Строка, представляющая информацию о клиенте.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, Phone: {PhoneNumber}";
        }
    }
}
