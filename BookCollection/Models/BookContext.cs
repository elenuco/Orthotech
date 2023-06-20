using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookCollection.Models
{
    public class BookContext : DbContext
    {
        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<BookCategoriesModel> BookCategoriesModels { get; set; }
        public BookContext(DbContextOptions options):base(options)
        {
            
        }


    }
}
