namespace BookNest.Models
{
    public class BorrowRecord
    {
        public int BorrowRecordId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime? DateReturned { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
