using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    /// <summary>
    /// Представляет резервацию книги в библиотеке.
    /// </summary>
    public class BookReservation
    {
        /// <summary>
        /// Уникальный идентификатор резервации книги.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор клиента, сделавшего резервацию.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент, сделавший резервацию.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Идентификатор книги, на которую сделана резервация.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Книга, на которую сделана резервация.
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Дата выдачи книги.
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Дата возврата книги.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Фактическая дата возврата книги.
        /// </summary>
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// Конструктор по умолчанию. Устанавливает значения для даты выдачи, даты возврата и даты возврата в минимальное значение.
        /// </summary>
        public BookReservation()
        {
            IssueDate = DateTime.Now;
            DueDate = IssueDate.AddDays(30);
            ReturnDate = DateTime.MinValue;
        }

        /// <summary>
        /// Конструктор с параметрами для инициализации объекта резервации книги.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента, сделавшего резервацию.</param>
        /// <param name="client">Клиент, сделавший резервацию.</param>
        /// <param name="bookId">Идентификатор книги, на которую сделана резервация.</param>
        /// <param name="book">Книга, на которую сделана резервация.</param>
        /// <param name="issueDate">Дата выдачи книги.</param>
        /// <param name="dueDate">Дата возврата книги.</param>
        public BookReservation(int clientId, Client client, int bookId, Book book, DateTime issueDate, DateTime dueDate)
        {
            ClientId = clientId;
            Client = client;
            BookId = bookId;
            Book = book;
            IssueDate = DateTime.Now;
            DueDate = IssueDate.AddDays(30);
            ReturnDate = DateTime.MinValue;
        }
    }
}
