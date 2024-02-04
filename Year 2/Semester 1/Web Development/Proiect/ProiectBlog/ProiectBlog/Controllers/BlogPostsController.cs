using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectBlog.Models.Domain;
using ProiectBlog.Models.DTO;
using ProiectBlog.Repositories.Interface;

namespace ProiectBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDto request)
        {
            var blogPost = new BlogPost
            {
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsInvisible = request.IsInvisible,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                Title = request.Title,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            foreach (var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetCategoryById(categoryGuid);
                if(existingCategory != null)
                    blogPost.Categories.Add(existingCategory);
            }
            
            blogPost = await blogPostRepository.CreateAsync(blogPost);

            var response = new BlogPostDto
            {
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsInvisible = blogPost.IsInvisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await blogPostRepository.GetAllAsync();
            var response = new List<BlogPostDto>();
            foreach (var blogPost in blogPosts)
            {
                response.Add(new BlogPostDto
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    UrlHandle = blogPost.UrlHandle,
                    ShortDescription = (string)blogPost.ShortDescription,
                    Content = blogPost.Content,
                    PublishedDate = blogPost.PublishedDate,
                    Author = blogPost.Author,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    IsInvisible = blogPost.IsInvisible,
                    Categories = blogPost.Categories.Select(x => new CategoryDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UrlHandle = x.UrlHandle
                    }).ToList()
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBlogPostById(Guid id)
        {
            var existingBlogPost = await blogPostRepository.GetBlogPostById(id);

            if (existingBlogPost == null)
            {
                return NotFound();
            }

            var response = new BlogPostDto
            {
                Title = existingBlogPost.Title,
                UrlHandle = existingBlogPost.UrlHandle,
                ShortDescription = existingBlogPost.ShortDescription,
                Content = existingBlogPost.Content,
                PublishedDate = existingBlogPost.PublishedDate,
                Author = existingBlogPost.Author,
                FeaturedImageUrl = existingBlogPost.FeaturedImageUrl,
                IsInvisible = existingBlogPost.IsInvisible,
                Categories = existingBlogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);

        }

        [HttpGet]
        [Route("{urlHandle}")]
        public async Task<IActionResult> GetBlogPostByUrlHandle(string urlHandle)
        {
            var existingBlogPost = await blogPostRepository.GetBlogPostByUrlHandle(urlHandle);

            if (existingBlogPost == null)
            {
                return NotFound();
            }

            var response = new BlogPostDto
            {
                Title = existingBlogPost.Title,
                UrlHandle = existingBlogPost.UrlHandle,
                ShortDescription = existingBlogPost.ShortDescription,
                Content = existingBlogPost.Content,
                PublishedDate = existingBlogPost.PublishedDate,
                Author = existingBlogPost.Author,
                FeaturedImageUrl = existingBlogPost.FeaturedImageUrl,
                IsInvisible = existingBlogPost.IsInvisible,
                Categories = existingBlogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateBlogPost(Guid id, UpdateBlogPostRequestDto request)
        {
            var blogPost = new BlogPost
            {
                Id = id,
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsInvisible = request.IsInvisible,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                Title = request.Title,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            foreach (var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetCategoryById(categoryGuid);

                if(existingCategory != null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }

            var updatedBlogPost = await blogPostRepository.UpdateAsync(blogPost);

            if(updatedBlogPost == null) 
            {
                return NotFound();
            }

            var response = new BlogPostDto
            {
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsInvisible = blogPost.IsInvisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] Guid id)
        {
            var deletedBlogPost = await blogPostRepository.DeleteAsync(id);

            if(deletedBlogPost == null)
            {
                return NotFound();
            }

            var blogPost = new BlogPostDto
            {
                Id = deletedBlogPost.Id,
                Author = deletedBlogPost.Author,
                Content = deletedBlogPost.Content,
                FeaturedImageUrl = deletedBlogPost.FeaturedImageUrl,
                IsInvisible = deletedBlogPost.IsInvisible,
                PublishedDate = deletedBlogPost.PublishedDate,
                ShortDescription = deletedBlogPost.ShortDescription,
                Title = deletedBlogPost.Title,
                UrlHandle = deletedBlogPost.UrlHandle
            };

            return Ok(blogPost);
        }
    }
}
