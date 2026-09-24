using System.ComponentModel.DataAnnotations;

namespace Library_Mangement_System.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }    
        // Relation
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
