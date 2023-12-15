using Microsoft.EntityFrameworkCore;
using ProiectBlog.Data;
using ProiectBlog.Models.Domain;
using ProiectBlog.Repositories.Interface;

namespace ProiectBlog.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
    }
}
