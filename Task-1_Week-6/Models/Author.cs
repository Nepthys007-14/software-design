using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_1_Week_6.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [NotMapped]
        public string FullName => FirstName;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
