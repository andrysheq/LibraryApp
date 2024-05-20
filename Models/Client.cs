using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibraryApp.Models
{
    public class Client
    {
        // Автосвойства для хранения информации о клиенте
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore] public ICollection<BookReservation> BookReservations { get; set; }

        // Конструктор по умолчанию
        public Client()
        {
            BookReservations = new List<BookReservation>();
        }

        // Конструктор с параметрами для инициализации объекта клиента
        public Client(string name, string phoneNumber, string surname, string middleName)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Surname = surname;
            MiddleName = middleName;
            BookReservations = new List<BookReservation>();
        }

        // Метод для добавления книги к списку взятых книг
        //public void BorrowBook(int bookId)
        //{
        //    BorrowedBooks.Add(bookId);
        //}

        //// Метод для возврата книги
        //public void ReturnBook(int bookId)
        //{
        //    BorrowedBooks.Remove(bookId);
        //}

        // Переопределение метода ToString() для удобного отображения информации о клиенте
        public override string ToString()
        {
            //string borrowedBooks = string.Join(", ", BorrowedBooks.Select(b => b.Title));
            //return $"Name: {Name}, Phone: {PhoneNumber}, Is Debtor: {IsDebtor}, Borrowed Books: {borrowedBooks}";
            return $"Name: {Name}, Phone: {PhoneNumber}";
        }
    }
}
