using ArticleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}