using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем базу данных, если она не существует
            using (var context = new LibraryContext())
            {
                context.Database.EnsureCreated(); // Создает базу данных, если ее нет

                // Добавляем автора и книги
                var author = new Author { Name = "J.K. Rowling" };
                author.Books.Add(new Book { Title = "Harry Potter and the Philosopher's Stone" });
                author.Books.Add(new Book { Title = "Harry Potter and the Chamber of Secrets" });

                context.Authors.Add(author);
                context.SaveChanges(); // Сохраняем изменения в базе данных
            }

            // Выводим данные из базы данных
            using (var context = new LibraryContext())
            {
                var authors = context.Authors.Include(a => a.Books).ToList();

                foreach (var author in authors)
                {
                    Console.WriteLine($"Author: {author.Name}");
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine($" - Book: {book.Title}");
                    }
                }
            }
        }
    }
}