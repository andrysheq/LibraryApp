using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.db;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    /// <summary>
    /// Предоставляет сервис для работы с резервациями книг.
    /// </summary>
    public class BookReservationService
    {
        private readonly db.ApplicationContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса BookReservationService с заданным контекстом базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public BookReservationService(db.ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет новую резервацию книги.
        /// </summary>
        /// <param name="reservation">Резервация книги для добавления.</param>
        public void AddBookReservation(BookReservation reservation)
        {
            _context.BookReservations.Add(reservation);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет информацию о резервации книги.
        /// </summary>
        /// <param name="reservation">Резервация книги для обновления.</param>
        public void UpdateBookReservation(BookReservation reservation)
        {
            _context.BookReservations.Update(reservation);
            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет резервацию книги по идентификаторам клиента и книги.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <param name="bookId">Идентификатор книги.</param>
        public void DeleteBookReservation(int clientId, int bookId)
        {
            var reservation = _context.BookReservations.Find(clientId, bookId);
            if (reservation != null)
            {
                _context.BookReservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет резервацию книги по идентификатору.
        /// </summary>
        /// <param name="Id">Идентификатор резервации книги.</param>
        public void DeleteBookReservation(int Id)
        {
            var reservation = _context.BookReservations.Find(Id);
            if (reservation != null)
            {
                _context.BookReservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Получает все резервации книг.
        /// </summary>
        /// <returns>Список всех резерваций книг.</returns>
        public List<BookReservation> GetAllBookReservations()
        {
            return _context.BookReservations.ToList();
        }

        /// <summary>
        /// Получает резервацию книги по идентификаторам клиента и книги.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <param name="bookId">Идентификатор книги.</param>
        /// <returns>Резервация книги, если найдена; в противном случае — null.</returns>
        public BookReservation GetBookReservationById(int clientId, int bookId)
        {
            return _context.BookReservations.Find(clientId, bookId);
        }

        /// <summary>
        /// Получает резервацию книги по идентификатору.
        /// </summary>
        /// <param name="Id">Идентификатор резервации книги.</param>
        /// <returns>Резервация книги, если найдена; в противном случае — null.</returns>
        public BookReservation GetBookReservationById(int Id)
        {
            return _context.BookReservations.Find(Id);
        }
    }
}
