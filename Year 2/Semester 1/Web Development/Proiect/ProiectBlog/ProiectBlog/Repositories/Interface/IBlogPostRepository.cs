using ProiectBlog.Models.Domain;

namespace ProiectBlog.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetBlogPostById(Guid id);
        Task<BlogPost?> GetBlogPostByUrlHandle(string urlHandle);
        Task<BlogPost?> UpdateAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteAsync(Guid id);
    }
}
