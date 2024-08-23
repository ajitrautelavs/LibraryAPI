namespace LibraryAPI.Models.Domain
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
