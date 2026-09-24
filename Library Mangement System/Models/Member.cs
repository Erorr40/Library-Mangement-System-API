using System.ComponentModel.DataAnnotations;

namespace Library_Mangement_System.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [MaxLength(20), Phone]
        public string? PhoneNumber { get; set; }
        // many
        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}
