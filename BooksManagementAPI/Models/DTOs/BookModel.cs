namespace BooksManagementAPI.Models.DTOs
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Discription { get; set; }
        public string Author { get; set; }

        public Decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; }
    }
}
