using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.db
{
    /// <summary>
    /// Контекст базы данных приложения.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Набор данных о клиентах.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Набор данных о книгах.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Набор данных о бронировании книг.
        /// </summary>
        public DbSet<BookReservation> BookReservations { get; set; }

        /// <summary>
        /// Конфигурация контекста базы данных.
        /// </summary>
        /// <param name="optionsBuilder">Построитель опций контекста.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=libraryapp6.db");
        }

        /// <summary>
        /// Настройка отношений между сущностями в базе данных.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели базы данных.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookReservation>()
                .HasKey(br => br.Id);

            modelBuilder.Entity<BookReservation>()
                .HasOne(br => br.Client)
                .WithMany(c => c.BookReservations)
                .HasForeignKey(br => br.ClientId);

            modelBuilder.Entity<BookReservation>()
                .HasOne(br => br.Book)
                .WithOne(b => b.BookReservation)
                .HasForeignKey<BookReservation>(br => br.BookId);
        }
    }
}
