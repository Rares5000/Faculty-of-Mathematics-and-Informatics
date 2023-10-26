using Laborator3._2.Model;

namespace Laborator3._2.Repositories.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
