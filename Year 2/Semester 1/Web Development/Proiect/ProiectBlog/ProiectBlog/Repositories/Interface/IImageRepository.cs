using ProiectBlog.Models.Domain;

namespace ProiectBlog.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
        Task<IEnumerable<BlogImage>> GetAll();
    }
}
