using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.db;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class BookReservationService
    {
        private readonly db.ApplicationContext _context;

        public BookReservationService(db.ApplicationContext context)
        {
            _context = context;
        }

        public void AddBookReservation(BookReservation reservation)
        {
            _context.BookReservations.Add(reservation);
            _context.SaveChanges();
        }

        public void UpdateBookReservation(BookReservation reservation)
        {
            _context.BookReservations.Update(reservation);
            _context.SaveChanges();
        }

        public void DeleteBookReservation(int clientId, int bookId)
        {
            var reservation = _context.BookReservations.Find(clientId, bookId);
            if (reservation != null)
            {
                _context.BookReservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        public void DeleteBookReservation(int Id)
        {
            var reservation = _context.BookReservations.Find(Id);
            if (reservation != null)
            {
                _context.BookReservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        public List<BookReservation> GetAllBookReservations()
        {
            return _context.BookReservations.ToList();
        }

        public BookReservation GetBookReservationById(int clientId, int bookId)
        {
            return _context.BookReservations.Find(clientId, bookId);
        }

        public BookReservation GetBookReservationById(int Id)
        {
            return _context.BookReservations.Find(Id);
        }
    }
}
