using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.db;
using LibraryApp.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp.Services
{
    public class BookService
    {
        private readonly db.ApplicationContext _context;

        public BookService(db.ApplicationContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public List<Book> SearchBooksByAuthor(string query)
        {
            return _context.Books.ToList().Where(book => book.Author.Contains(query)).ToList();
        }

        public List<Book> SearchBooksByTitle(string query)
        {
            return _context.Books.ToList().Where(book => book.Title.Contains(query)).ToList();
        }
    }
}
