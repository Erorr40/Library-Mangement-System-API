using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library_Mangement_System.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }
        [Required, Range(1900, 2026)]
        public int PublicationYear { get; set; }
        [Required, Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int AvailableCopies { get; set; }
        //FK
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        // many
        [JsonIgnore]
        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    }
}
