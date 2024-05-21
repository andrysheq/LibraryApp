using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.db;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    /// <summary>
    /// Предоставляет сервис для работы с клиентами библиотеки.
    /// </summary>
    public class ClientService
    {
        private readonly db.ApplicationContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса ClientService с заданным контекстом базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public ClientService(db.ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет нового клиента.
        /// </summary>
        /// <param name="client">Клиент для добавления.</param>
        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет информацию о клиенте.
        /// </summary>
        /// <param name="client">Клиент для обновления.</param>
        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет клиента по идентификатору.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        public void DeleteClient(int clientId)
        {
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Получает всех клиентов.
        /// </summary>
        /// <returns>Список всех клиентов.</returns>
        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        /// <summary>
        /// Получает клиента по идентификатору.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <returns>Клиент, если найден; в противном случае — null.</returns>
        public Client GetClientById(int clientId)
        {
            return _context.Clients.Find(clientId);
        }

        /// <summary>
        /// Получает список клиентов-должников.
        /// </summary>
        /// <returns>Список клиентов-должников.</returns>
        public List<Client> GetDebtors()
        {
            // Загружаем всех клиентов вместе с их резервациями книг
            var clientsWithReservations = _context.Clients.Include(c => c.BookReservations).ToList();

            // Фильтрация должников
            var debtors = clientsWithReservations.Where(client =>
                client.BookReservations != null && // Проверка наличия резерваций
                client.BookReservations.Any(reservation =>
                    reservation.DueDate < DateTime.Now &&
                    (reservation.ReturnDate == DateTime.MinValue || reservation.ReturnDate > reservation.DueDate)
                )
            ).ToList();

            return debtors;
        }

        /// <summary>
        /// Получает список новых клиентов (клиентов без резерваций).
        /// </summary>
        /// <returns>Список новых клиентов.</returns>
        public List<Client> GetNewComers()
        {
            // Загружаем всех клиентов вместе с их резервациями книг
            var clientsWithReservations = _context.Clients.Include(c => c.BookReservations).ToList();

            // Фильтрация новых клиентов
            var newComers = clientsWithReservations.Where(client =>
                client.BookReservations.Count == 0
            ).ToList();

            return newComers;
        }

        /// <summary>
        /// Проверяет существует ли номер телефона уже у кого-то.
        /// </summary>
        public bool IsPhoneNumberExists(string phoneNumber)
        {
            return _context.Clients.Any(c => c.PhoneNumber == phoneNumber);
        }
    }
}
