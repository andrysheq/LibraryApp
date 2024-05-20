using System;
using Newtonsoft.Json;

namespace LibraryApp.Models
{
    /// <summary>
    /// Представляет собой модель книги.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Автор книги.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Уникальный идентификатор книги.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Год издания книги.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Количество страниц в книге.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Резервация книги.
        /// </summary>
        [JsonIgnore]
        public BookReservation BookReservation { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Book() { }

        /// <summary>
        /// Конструктор с параметрами для инициализации объекта книги.
        /// </summary>
        /// <param name="title">Название книги.</param>
        /// <param name="author">Автор книги.</param>
        /// <param name="year">Год издания книги.</param>
        /// <param name="pageCount">Количество страниц в книге.</param>
        /// <param name="id">Уникальный идентификатор книги.</param>
        public Book(string title, string author, int year, int pageCount, int id)
        {
            Title = title;
            Author = author;
            Year = year;
            PageCount = pageCount;
            Id = id;
            BookReservation = new BookReservation();
        }

        /// <summary>
        /// Переопределение метода ToString() для удобного отображения информации о книге.
        /// </summary>
        /// <returns>Строка, представляющая информацию о книге.</returns>
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Year: {Year}, Pages: {PageCount}";
        }
    }
}
