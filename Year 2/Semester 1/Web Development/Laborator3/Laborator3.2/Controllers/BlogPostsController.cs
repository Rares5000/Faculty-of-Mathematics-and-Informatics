using Laborator3._2.Model.DTO;
using Laborator3._2.Model;
using Laborator3._2.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laborator3._2.Repositories.Interfaces;

namespace Laborator3._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
        {
            
            var blogPost = new BlogPost
            {
                Author = request.Author,
                Title = request.Title,
                Content = request.Content,
                FeatureImageUrl = request.FeatureImageUrl,
                IsVisible = request.IsVisible,
                PublishedData = request.PublishedData,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
            };

            blogPost = await blogPostRepository.CreateAsync(blogPost);

            
            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeatureImageUrl = blogPost.FeatureImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedData = blogPost.PublishedData,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
            };

            return Ok(response);
        }
    }
}
