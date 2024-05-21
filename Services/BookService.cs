using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.db;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    /// <summary>
    /// Предоставляет сервис для работы с книгами.
    /// </summary>
    public class BookService
    {
        private readonly db.ApplicationContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса BookService с заданным контекстом базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public BookService(db.ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет новую книгу.
        /// </summary>
        /// <param name="book">Книга для добавления.</param>
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет информацию о книге.
        /// </summary>
        /// <param name="book">Книга для обновления.</param>
        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет книгу по идентификатору.
        /// </summary>
        /// <param name="bookId">Идентификатор книги.</param>
        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Получает все книги.
        /// </summary>
        /// <returns>Список всех книг.</returns>
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        /// <summary>
        /// Получает книгу по идентификатору.
        /// </summary>
        /// <param name="bookId">Идентификатор книги.</param>
        /// <returns>Книга, если найдена; в противном случае — null.</returns>
        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        /// <summary>
        /// Поиск книг по автору.
        /// </summary>
        /// <param name="query">Поисковой запрос.</param>
        /// <returns>Список книг, удовлетворяющих поисковому запросу по автору.</returns>
        public List<Book> SearchBooksByAuthor(string query)
        {
            return _context.Books.ToList().Where(book => book.Author.ToLower().Contains(query.ToLower())).ToList();
        }

        /// <summary>
        /// Поиск книг по названию.
        /// </summary>
        /// <param name="query">Поисковой запрос.</param>
        /// <returns>Список книг, удовлетворяющих поисковому запросу по названию.</returns>
        public List<Book> SearchBooksByTitle(string query)
        {
            return _context.Books.ToList().Where(book => book.Title.ToLower().Contains(query.ToLower())).ToList();
        }
    }
}
