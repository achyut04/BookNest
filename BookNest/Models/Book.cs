namespace BookNest.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }

        public string ISBN { get; set; } 
        public int CopiesAvailable { get; set; }
        public int TotalCopies { get; set; } 
    }
}
