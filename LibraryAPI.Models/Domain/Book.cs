using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Domain
{
    public class Book
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
