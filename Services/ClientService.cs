using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.db;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    public class ClientService
    {
        private readonly db.ApplicationContext _context;

        public ClientService(db.ApplicationContext context)
        {
            _context = context;
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void DeleteClient(int clientId)
        {
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientById(int clientId)
        {
            return _context.Clients.Find(clientId);
        }

        public List<Client> GetDebtors()
        {
            // Загружаем всех клиентов вместе с их резервациями книг
            var clientsWithReservations = _context.Clients.Include(c => c.BookReservations).ToList();

            // Фильтрация должников
            var debtors = clientsWithReservations.Where(client =>
                client.BookReservations != null && // Проверка наличия резерваций
                client.BookReservations.Any(reservation =>
                    reservation.DueDate < DateTime.Now &&
                    reservation.ReturnDate == DateTime.MinValue || reservation.ReturnDate > reservation.DueDate
                )
            ).ToList();

            return debtors;
        }

        public List<Client> GetNewComers()
        {
            // Загружаем всех клиентов вместе с их резервациями книг
            var clientsWithReservations = _context.Clients.Include(c => c.BookReservations).ToList();

            // Фильтрация должников
            var newComers = clientsWithReservations.Where(client =>
                client.BookReservations.Count==0
                ).ToList();

            return newComers;
        }
    }
}
