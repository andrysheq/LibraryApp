using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Models;

namespace LibraryApp.db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> BookReservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=libraryapp6.db");
        }

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
