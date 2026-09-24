using Library_Mangement_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Library_Mangement_System.DTOs.BooksDTOs
{
    public class CreateBooksDTO
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
        public int CategoryId { get; set; }
    }
}
