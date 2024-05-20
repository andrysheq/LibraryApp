using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class BookReservation
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime IssueDate { get; set; } // Дата выдачи книги
        public DateTime DueDate { get; set; } // Дата возврата книги
        public DateTime ReturnDate { get; set; } // Дата фактического возврата книги

        public BookReservation() {
            IssueDate = DateTime.Now;
            DueDate = IssueDate.AddDays(30);
            ReturnDate = DateTime.MinValue;
        }

        public BookReservation(int clientId, Client client, int bookId, Book book, DateTime issueDate, DateTime dueDate)
        {
            ClientId = clientId;
            Client = client;
            BookId = bookId;
            Book = book;
            IssueDate = DateTime.Now;
            DueDate = IssueDate.AddDays(30);
            ReturnDate = DateTime.MinValue; // Устанавливаем дату возврата в минимальное значение даты (означает, что книга еще не возвращена)
        }
    }
}
