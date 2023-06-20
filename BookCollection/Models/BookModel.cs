namespace BookCollection.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int BookPublicationYear { get; set; }
        public BookCategoriesModel Category { get; set; }
        public int IdCategory { get; set; }
    }
}
