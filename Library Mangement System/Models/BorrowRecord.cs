using System.ComponentModel.DataAnnotations;

namespace Library_Mangement_System.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Relations
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public IEnumerable<Member> Members { get; set; } = new List<Member>();
    }
}
