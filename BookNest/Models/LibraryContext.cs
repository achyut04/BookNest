using Microsoft.EntityFrameworkCore;

namespace BookNest.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    YearPublished = 1960,
                    ISBN = "9780060935467",
                    TotalCopies = 10,
                    CopiesAvailable = 7
                },
                new Book
                {
                    BookId = 2,
                    Title = "1984",
                    Author = "George Orwell",
                    YearPublished = 1949,
                    ISBN = "9780451524935",
                    TotalCopies = 8,
                    CopiesAvailable = 5
                },
                new Book
                {
                    BookId = 3,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    YearPublished = 1925,
                    ISBN = "9780743273565",
                    TotalCopies = 6,
                    CopiesAvailable = 3
                },
                new Book
                {
                    BookId = 4,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    YearPublished = 1951,
                    ISBN = "9780316769488",
                    TotalCopies = 12,
                    CopiesAvailable = 8
                },
                new Book
                {
                    BookId = 5,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    YearPublished = 1813,
                    ISBN = "9780141439518",
                    TotalCopies = 9,
                    CopiesAvailable = 6
                },
                new Book
                {
                    BookId = 6,
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    YearPublished = 1954,
                    ISBN = "9780618640157",
                    TotalCopies = 5,
                    CopiesAvailable = 3
                },
                new Book
                {
                    BookId = 7,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Author = "J.K. Rowling",
                    YearPublished = 1997,
                    ISBN = "9780439708180",
                    TotalCopies = 20,
                    CopiesAvailable = 15
                },
                new Book
                {
                    BookId = 8,
                    Title = "Moby-Dick",
                    Author = "Herman Melville",
                    YearPublished = 1851,
                    ISBN = "9781503280786",
                    TotalCopies = 7,
                    CopiesAvailable = 4
                },
                new Book
                {
                    BookId = 9,
                    Title = "War and Peace",
                    Author = "Leo Tolstoy",
                    YearPublished = 1869,
                    ISBN = "9780199232765",
                    TotalCopies = 4,
                    CopiesAvailable = 2
                },
                new Book
                {
                    BookId = 10,
                    Title = "Crime and Punishment",
                    Author = "Fyodor Dostoevsky",
                    YearPublished = 1866,
                    ISBN = "9780143107637",
                    TotalCopies = 6,
                    CopiesAvailable = 3
                }
            );
        }

    }


}
