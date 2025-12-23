using Microsoft.EntityFrameworkCore;
using NewsCategory.EF.Models;

namespace NewsCategory.EF
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
       : base(options) { }

        public DbSet<News> Newss { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}
