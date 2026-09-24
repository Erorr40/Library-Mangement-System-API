using System.ComponentModel.DataAnnotations;

namespace Library_Mangement_System.DTOs.BooksDTOs
{
    public class BooksDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public int AvailableCopies { get; set; }
        public int CategoryId { get; set; }
    }
}
