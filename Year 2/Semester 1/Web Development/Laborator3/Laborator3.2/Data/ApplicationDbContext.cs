using Laborator3._2.Model;
using Microsoft.EntityFrameworkCore;

namespace Laborator3._2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
