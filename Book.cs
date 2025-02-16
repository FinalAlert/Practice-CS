namespace LibraryApp
{
    public class Book
    {
        public int BookId { get; set; } // Первичный ключ
        public string Title { get; set; } // Название книги
        public int AuthorId { get; set; } // Внешний ключ

        // Навигационное свойство для связи многие к 1
        public Author Author { get; set; }
    }
}