using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace LibraryApp
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } // Таблица авторов
        public DbSet<Book> Books { get; set; } // Таблица книг

        // Переопределяем метод для настройки базы данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Используем SQLite в качестве базы данных
            optionsBuilder.UseSqlite("Data Source=library.db");
        }

        // Переопределяем метод для настройки связей и таблиц
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настраиваем связь 1 ко многим между Author и Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}