using System.Collections.Generic;

namespace LibraryApp
{
    public class Author
    {
        public int AuthorId { get; set; } // Первичный ключ
        public string Name { get; set; } // Имя автора

        // Навигационное свойство для связи 1 ко многим
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}