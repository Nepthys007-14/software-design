using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_1_Week_6.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author? Author { get; set; }
    }
}
