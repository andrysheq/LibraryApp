using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Book
    {
        // Автосвойства для хранения информации о книге
        public string Title { get; set; }
        public string Author { get; set; }
        public int Id { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }
        public BookReservation BookReservation { get; set; }

        // Конструктор по умолчанию
        public Book() { }

        // Конструктор с параметрами для инициализации объекта книги
        public Book(string title, string author, int year, int pageCount, int id)
        {
            Title = title;
            Author = author;
            Year = year;
            PageCount = pageCount;
            Id = id;
            BookReservation = new BookReservation();   
        }

        // Переопределение метода ToString() для удобного отображения информации о книге
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Year: {Year}, Pages: {PageCount}";
        }
    }
}
